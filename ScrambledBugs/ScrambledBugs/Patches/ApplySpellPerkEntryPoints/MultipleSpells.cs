using Eggstensions;

using static Eggstensions.ExtensionMethods.IntPtr;

using Marshal = Eggstensions.Marshal;



namespace ScrambledBugs.Patches.ApplySpellPerkEntryPoints
{
	internal class MultipleSpells
	{
		static MultipleSpells()
		{
			Memory.Write<System.IntPtr>(Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.SelectSpell, System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(MultipleSpells.NewSelectSpell));
		}
		
		public MultipleSpells(System.Boolean castSpells)
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address			= Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyBashingSpell + 0x40E,
				Pattern			= "E8 ?? ?? ?? ??",
				ReplaceLength	= 5,
				IncludeLength	= 0,
				Before			= registers =>
				{
					// perkOwner	!= System.IntPtr.Zero
					// target		!= System.IntPtr.Zero
					
					var entryPoint	= (EntryPoint)registers.CX.ToInt32Safe();
					Actor perkOwner	= registers.DX;
					Actor target	= registers.R8;

					using (var results = new Marshal.BSTArray.IntPtr())
					{
						Marshal.BGSEntryPointPerkEntry.HandleEntryPoints(entryPoint, perkOwner, target, results);

						foreach (SpellItem result in results)
						{
							if (result)
							{
								result.Apply(castSpells ? perkOwner : target, target);
							}
						}
					}
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address			= Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyCombatHitSpell + 0x61,
				Pattern			= "E8 ?? ?? ?? ??",
				ReplaceLength	= 5,
				IncludeLength	= 0,
				Before			= registers =>
				{
					// perkOwner	!= System.IntPtr.Zero
					// weapon		!= System.IntPtr.Zero
					// target		!= System.IntPtr.Zero

					var entryPoint			= (EntryPoint)registers.CX.ToInt32Safe();
					Actor perkOwner			= registers.DX;
					TESObjectWEAP weapon	= registers.R8;
					Actor target			= registers.R9;

					using (var results = new Marshal.BSTArray.IntPtr())
					{
						Marshal.BGSEntryPointPerkEntry.HandleEntryPoints(entryPoint, perkOwner, weapon, target, results);

						foreach (SpellItem result in results)
						{
							if (result)
							{
								result.Apply(castSpells ? perkOwner : target, target);
							}
						}
					}
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address			= Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyCombatHitSpellArrowProjectile + 0x28B,
				Pattern			= "E8 ?? ?? ?? ??",
				ReplaceLength	= 5,
				IncludeLength	= 0,
				Before			= registers =>
				{
					// arrow		!= System.IntPtr.Zero
					// perkOwner	!= System.IntPtr.Zero
					// weapon		!= System.IntPtr.Zero
					// target		!= System.IntPtr.Zero

					ArrowProjectile arrow = registers.DI;

					if ((arrow.Flags & ProjectileFlags.Is3DLoaded) != 0)
					{
						var entryPoint			= (EntryPoint)registers.CX.ToInt32Safe();
						Actor perkOwner			= registers.DX;
						TESObjectWEAP weapon	= registers.R8;
						Actor target			= registers.R9;

						using (var results = new Marshal.BSTArray.IntPtr())
						{
							Marshal.BGSEntryPointPerkEntry.HandleEntryPoints(entryPoint, perkOwner, weapon, target, results);

							foreach (SpellItem result in results)
							{
								if (result)
								{
									result.Apply(castSpells ? perkOwner : target, target);
								}
							}
						}
					}
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address			= Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyReanimateSpell + 0xBA,
				Pattern			= "E8 ?? ?? ?? ??",
				ReplaceLength	= 5,
				IncludeLength	= 0,
				Before			= registers =>
				{
					// perkOwner	!= System.IntPtr.Zero
					// spell		!= System.IntPtr.Zero
					// target		!= System.IntPtr.Zero

					var entryPoint	= (EntryPoint)registers.CX.ToInt32Safe();
					Actor perkOwner	= registers.DX;
					SpellItem spell	= registers.R8;
					Actor target	= registers.R9;

					using (var results = new Marshal.BSTArray.IntPtr())
					{
						Marshal.BGSEntryPointPerkEntry.HandleEntryPoints(entryPoint, perkOwner, spell, target, results);

						foreach (SpellItem result in results)
						{
							if (result)
							{
								result.Apply(castSpells ? perkOwner : target, target);
							}
						}
					}
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address			= Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplySneakingSpell + 0xB6,
				Pattern			= "E8 ?? ?? ?? ??",
				ReplaceLength	= 5,
				IncludeLength	= 0,
				Before			= registers =>
				{
					// perkOwner != System.IntPtr.Zero
					
					var entryPoint	= (EntryPoint)registers.CX.ToInt32Safe();
					Actor perkOwner	= registers.DX;

					using (var results = new Marshal.BSTArray.IntPtr())
					{
						Marshal.BGSEntryPointPerkEntry.HandleEntryPoints(entryPoint, perkOwner, results);

						foreach (SpellItem result in results)
						{
							if (result)
							{
								result.Apply(perkOwner, perkOwner);
							}
						}
					}
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address			= Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.ApplyWeaponSwingSpell + 0xAB,
				Pattern			= "E8 ?? ?? ?? ??",
				ReplaceLength	= 5,
				IncludeLength	= 0,
				Before			= registers =>
				{
					// perkOwner		!= System.IntPtr.Zero
					// attacker			!= System.IntPtr.Zero
					// attackerWeapon	!= System.IntPtr.Zero
					
					var entryPoint					= (EntryPoint)registers.CX.ToInt32Safe();
					Actor perkOwner					= registers.DX;
					Actor attacker					= registers.R8;
					TESObjectWEAP attackerWeapon	= registers.R9;

					using (var results = new Marshal.BSTArray.IntPtr())
					{
						Marshal.BGSEntryPointPerkEntry.HandleEntryPoints(entryPoint, perkOwner, attacker, attackerWeapon, results);

						foreach (SpellItem result in results)
						{
							if (result)
							{
								result.Apply(castSpells ? attacker : perkOwner, perkOwner);
							}
						}
					}
				}
			});
		}



		static public Delegates.Types.Patches.ApplySpellPerkEntryPoints.MultipleSpells.EntryPointFunction NewSelectSpell { get; } = MultipleSpells.SelectSpell;



		/// <param name="perkOwnerAddress">Actor</param>
		/// <param name="result">EntryPointFunctionResult</param>
		/// <param name="resultsAddress">ref BSTArray.IntPtr</param>
		/// <param name="entryPointFunctionDataSpellItemAddress">BGSEntryPointFunctionDataSpellItem</param>
		static public void SelectSpell(System.IntPtr perkOwnerAddress, System.Int32 result, System.Byte resultCount, System.IntPtr resultsAddress, System.IntPtr entryPointFunctionDataSpellItemAddress)
		{
			// resultsAddress							!= System.IntPtr.Zero
			// entryPointFunctionDataSpellItemAddress	!= System.IntPtr.Zero

			if ((EntryPointFunctionResult)result != EntryPointFunctionResult.SpellItem)
			{
				return;
			}

			if (resultCount != Memory.Read<System.UInt32>(Offsets.Patches.ApplySpellPerkEntryPoints.MultipleSpells.SelectSpellResultCount))
			{
				return;
			}

			BGSEntryPointFunctionDataSpellItem entryPointFunctionDataSpellItem = entryPointFunctionDataSpellItemAddress;

			if (entryPointFunctionDataSpellItem.GetType() != EntryPointFunctionDataType.SpellItem)
			{
				return;
			}

			BSTArray.IntPtr spells = Memory.Read<System.IntPtr>(resultsAddress);
			System.IntPtr spell = entryPointFunctionDataSpellItem.Spell;
			spells.Push(ref spell);
		}
	}
}
