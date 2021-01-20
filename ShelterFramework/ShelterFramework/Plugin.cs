using Eggstensions.SkyrimSE;



namespace ShelterFramework
{
    public class Plugin : NetScriptFramework.Plugin
	{
		override public System.Int32 RequiredLibraryVersion	{ get { return 10; } }

		override public System.Int32 Version				{ get { return 1; } }

		override public System.String Author				{ get { return "meh321 and KernalsEgg"; } }

		override public System.String Key					{ get { return "ShelterFramework"; } }

		override public System.String Name					{ get { return "Shelter Framework"; } }



		override protected System.Boolean Initialize(System.Boolean loadedAny)
		{
			// loadedAny

			Plugin._settings = new Settings();
			Plugin._settings.Load();

			Plugin._lock = new System.Object();

			Events.GetIsCreatureTypeEvent.Register(OnGetIsCreatureType);

			return true;
		}



		readonly static private BGSCollisionLayer.CollisionLayerTypes _collisionLayerType = BGSCollisionLayer.CollisionLayerTypes.LOS;

		readonly static private System.String _messageBox =
			"Shelter Framework has thrown an exception." +
			"\nLogs are written to Data\\NetScriptFramework\\NetScriptFramework.log.txt.";



		static private Settings _settings;
		
		static private System.Collections.Generic.Dictionary<System.IntPtr, (System.Single lastUpdate, System.Boolean isSheltered)> _isShelteredCache =
			new System.Collections.Generic.Dictionary<System.IntPtr, (System.Single, System.Boolean)>();

		static private System.Object _lock;



		static private void OnGetIsCreatureType(Events.GetIsCreatureTypeEventArguments arguments)
		{
			if (arguments == null) { throw new Eggceptions.ArgumentNullException(nameof(arguments)); }

			try
			{
				var detectShelter = System.Convert.ToBoolean(arguments.Argument1);
				var isSheltered = Plugin.IsSheltered(arguments.Subject);

				arguments.Result = (isSheltered == detectShelter) ? 1.0d : 0.0d;
				arguments.Text = detectShelter ? "Is Sheltered >> %0.2f" : "Is Exposed >> %0.2f";
			}
			catch (Eggceptions.Eggception eggception)
			{
				if (Plugin._settings.LogHandledExceptions) { NetScriptFramework.Main.Log.Append(eggception); }
				if (Plugin._settings.ShowHandledExceptions) { UI.ShowMessageBox(Plugin._messageBox); }
			}
		}



		/// <param name="reference">TESObjectREFR</param>
		static private System.Boolean IsSheltered(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			switch (TESForm.GetFormType(reference))
			{
				case TESForm.FormTypes.Character:
					return Plugin.IsShelteredCharacter(reference);
				case TESForm.FormTypes.TESObjectREFR:
					return Plugin.IsShelteredReference(reference);
				default:
					throw new Eggceptions.SkyrimSE.FormTypeException(nameof(reference));
			}
		}

		/// <param name="character">Character</param>
		static private System.Boolean IsShelteredCharacter(System.IntPtr character)
		{
			if (character == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(character)); }

			lock (Plugin._lock)
			{
				var lastUpdate = Actor.GetLastUpdate(character);

				if (!Plugin._isShelteredCache.TryGetValue(character, out var isShelteredCache) || lastUpdate != isShelteredCache.lastUpdate)
				{
					isShelteredCache = (lastUpdate, Actor.IsHitAlong(character, TESObjectREFR.GetLookAtPosition(character), Plugin.GetRay(), Plugin._collisionLayerType));
					Plugin._isShelteredCache[character] = isShelteredCache;

					return isShelteredCache.isSheltered;
				}
				else
				{
					return isShelteredCache.isSheltered;
				}
			}
		}

		/// <param name="reference">TESObjectREFR</param>
		static private System.Boolean IsShelteredReference(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			return TESObjectREFR.IsHitAlong(reference, TESObjectREFR.GetLookAtPosition(reference), Plugin.GetRay(), Plugin._collisionLayerType);
		}

		static private (System.Single x, System.Single y, System.Single z) GetRay()
		{
			var currentPrecipitationObject = Precipitation.GetCurrentPrecipitationObject(Sky.GetPrecipitation(Sky.Instance));

			if (currentPrecipitationObject != System.IntPtr.Zero && !NiAVObject.IsHidden(currentPrecipitationObject))
			{
				var bsParticleShaderProperty = BSGeometry.GetProperties(currentPrecipitationObject, BSGeometry.States.Effect);

				if (bsParticleShaderProperty != System.IntPtr.Zero)
				{
					var bsParticleShaderCubeEmitter = BSParticleShaderProperty.GetParticleShaderEmitter(bsParticleShaderProperty);

					if (bsParticleShaderCubeEmitter != System.IntPtr.Zero)
					{
						var precipitationVelocity = BSParticleShaderCubeEmitter.GetVelocity(bsParticleShaderCubeEmitter);

						if (precipitationVelocity != (0.0f, 0.0f, 0.0f))
						{
							return Plugin.Negate(Plugin.SetLength(precipitationVelocity, Plugin._settings.RaycastDistance));
						}
					}
				}
			}

			return (0.0f, 0.0f, Plugin._settings.RaycastDistance);
		}

		static private (System.Single x, System.Single y, System.Single z) SetLength((System.Single x, System.Single y, System.Single z) vector, System.Single length)
		{
			// vector
			// length

			var multiplier = (System.Single)System.Math.Sqrt((length * length) / ((vector.x * vector.x) + (vector.y * vector.y) + (vector.z * vector.z)));

			return (vector.x * multiplier, vector.y * multiplier, vector.z * multiplier);
		}

		static private (System.Single x, System.Single y, System.Single z) Negate((System.Single x, System.Single y, System.Single z) vector)
		{
			// vector

			return (-vector.x, -vector.y, -vector.z);
		}
	}
}
