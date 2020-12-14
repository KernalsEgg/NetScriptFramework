namespace ElapsedSecondsPatch
{
	public class Plugin : NetScriptFramework.Plugin
	{
		override public System.String Author
		{
			get
			{
				return "meh321 and KernalsEgg";
			}
		}

		override public System.String Key
		{
			get
			{
				return "ElapsedSecondsPatch";
			}
		}

		override public System.String Name
		{
			get
			{
				return "Elapsed Seconds Patch";
			}
		}

		override public System.Int32 RequiredLibraryVersion
		{
			get
			{
				return 10;
			}
		}

		override public System.Int32 Version
		{
			get
			{
				return 1;
			}
		}



		override protected System.Boolean Initialize(System.Boolean loadedAny)
		{
			// loadedAny

			Plugin._settings = new Settings();
			Plugin._settings.Load();

			Plugin.WriteHook();

			return true;
		}



		static private System.Collections.Generic.Dictionary<System.IntPtr, (System.Int32 previousTick, System.Int64 elapsedTicks)> _activeEffects;
		static private System.Object _lock;
		static private Settings _settings;
		static private System.IntPtr _hookAddress;
		static private System.IntPtr _skipUpdateAddress;
		static private System.IntPtr _updateFrequencyAddress; // <SkyrimSE.exe> + 0x2F25CE8 (VID516661)
//		static private System.IntPtr _updateIntervalAddress; // <SkyrimSE.exe> + 0x1DE5258 (VID506258), fActiveEffectConditionUpdateInterval



		static private void WriteHook()
		{
			Plugin._activeEffects = new System.Collections.Generic.Dictionary<System.IntPtr, (System.Int32 previousTick, System.Int64 elapsedTicks)>();
			Plugin._lock = new System.Object();

			// <SkyrimSE.exe> + 0x53E3E0 (VID33287)
			Plugin._hookAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(33287, 0xDD, 0, "F3 0F 10 4F 70");
			Plugin._skipUpdateAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(33287, 0x1DD, 0, "48 8B 5C 24 58");
			Plugin._updateFrequencyAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(516661);
//			Plugin._updateIntervalAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(506258);

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Plugin._hookAddress,
				ReplaceLength = 0x79,
				IncludeLength = 0,
				Before = ctx =>
				{
					/*
					Constant Effect =	0
					Fire and Forget =	1
					Concentration =		2
					Scroll =			3
					*/
					if (Plugin._settings.AlwaysIncreaseAccuracy && GetCastingType(ctx) == 0)
					{
						Plugin.SkipUpdateAccurate(ctx);
					}
					else
					{
						Plugin.SkipUpdate(ctx);
					}
				}
			});
		}

		static private System.Int32 GetCastingType(NetScriptFramework.CPURegisters ctx)
		{
			if (ctx == null) { throw new System.ArgumentNullException("ctx"); }

			var activeEffect = ctx.DI;
			if (activeEffect == System.IntPtr.Zero) { throw new System.NullReferenceException("activeEffect"); }

			var magicItem = NetScriptFramework.Memory.ReadPointer(activeEffect + 0x40);
			if (magicItem == System.IntPtr.Zero) { throw new System.NullReferenceException("magicItem"); }

			var magicItemVTable = NetScriptFramework.Memory.ReadPointer(magicItem);
			if (magicItemVTable == System.IntPtr.Zero) { throw new System.NullReferenceException("magicItemVTable"); }

			var getCastingTypeAddress = NetScriptFramework.Memory.ReadPointer(magicItemVTable + 0x2A8);
			if (getCastingTypeAddress == System.IntPtr.Zero) { throw new System.NullReferenceException("getCastingTypeAddress"); }

			return NetScriptFramework.Memory.InvokeThisCall(magicItem, getCastingTypeAddress).ToInt32();
		}

		static private void SkipUpdate(NetScriptFramework.CPURegisters ctx)
		{
			if (ctx == null) { throw new System.ArgumentNullException("ctx"); }

			var elapsedSeconds = (System.Double)NetScriptFramework.Memory.ReadFloat(ctx.DI + 0x70); // ActiveEffect + 0x70

			// No floating-point inaccuracy is expected in this range
			if (elapsedSeconds <= 86400.0f) // 1 day = 86,400 seconds
			{
				var frameTime = ctx.XMM6f;

				if (frameTime <= 0.0f)
				{
					ctx.IP = Plugin._skipUpdateAddress;
					return;
				}

				var updateFrequency = (System.Double)NetScriptFramework.Memory.ReadFloat(Plugin._updateFrequencyAddress);
				var previousSecond = (System.Int64)(elapsedSeconds * updateFrequency);
				var currentSecond = (System.Int64)((elapsedSeconds + frameTime) * updateFrequency);
				/*
				var updateInterval = (System.Double)NetScriptFramework.Memory.ReadFloat(Plugin._updateIntervalAddress);
				var previousSecond = (System.Int64)(elapsedSeconds / updateInterval);
				var currentSecond = (System.Int64)((elapsedSeconds + frameTime) / updateInterval);
				*/
				if (currentSecond == previousSecond)
				{
					ctx.IP = Plugin._skipUpdateAddress;
					return;
				}
			}
			else
			{
				Plugin.SkipUpdateAccurate(ctx);
				return;
			}
		}

		static private void SkipUpdateAccurate(NetScriptFramework.CPURegisters ctx)
		{
			if (ctx == null) { throw new System.ArgumentNullException("ctx"); }

			lock (Plugin._lock)
			{
				var activeEffect = ctx.DI;

				if (Plugin._activeEffects.ContainsKey(activeEffect))
				{
					var currentTick = System.Environment.TickCount;
					(var previousTick, var elapsedTicks) = Plugin._activeEffects[activeEffect];
					var frameTime = unchecked(currentTick - previousTick);

					if (frameTime <= 0)
					{
						ctx.IP = Plugin._skipUpdateAddress;
						return;
					}

					Plugin._activeEffects[activeEffect] = (currentTick, elapsedTicks + frameTime);

					var updateFrequency = (System.Double)NetScriptFramework.Memory.ReadFloat(Plugin._updateFrequencyAddress);
					var previousSecond = (System.Int64)((elapsedTicks * updateFrequency) / 1000.0d);
					var currentSecond = (System.Int64)(((elapsedTicks + frameTime) * updateFrequency) / 1000.0d);
					/*
					var updateInterval = (System.Double)NetScriptFramework.Memory.ReadFloat(Plugin._updateIntervalAddress);
					var previousSecond = (System.Int64)((Plugin._elapsedTicks / updateFrequency) / 1000);
					var currentSecond = (System.Int64)(((Plugin._elapsedTicks + frameTime) / updateFrequency) / 1000);
					*/
					if (currentSecond == previousSecond)
					{
						ctx.IP = Plugin._skipUpdateAddress;
						return;
					}
				}
				else
				{
					Plugin._activeEffects[activeEffect] = (System.Environment.TickCount, 0);

					ctx.IP = Plugin._skipUpdateAddress;
					return;
				}
			}
		}
	}
}
