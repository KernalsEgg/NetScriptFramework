using Eggstensions;



namespace ScrambledBugs.Patches
{
	namespace Offsets
	{
		static internal class ApplySpellPerkEntryPoints
		{
			/// <summary> SkyrimSE.exe + 0x628C20 </summary>
			static public System.IntPtr ApplyBashingSpell { get; }					= NetScriptFramework.Main.GameInfo.GetAddressOf(37673);

			/// <summary> SkyrimSE.exe + 0x6310A0 </summary>
			static public System.IntPtr ApplyCombatHitSpell { get; }				= NetScriptFramework.Main.GameInfo.GetAddressOf(37799);

			/// <summary> SkyrimSE.exe + 0x732400 </summary>
			static public System.IntPtr ApplyCombatHitSpellArrowProjectile { get; }	= NetScriptFramework.Main.GameInfo.GetAddressOf(42547);

			/// <summary> SkyrimSE.exe + 0x634BF0 </summary>
			static public System.IntPtr ApplyReanimateSpell { get; }				= NetScriptFramework.Main.GameInfo.GetAddressOf(37865);

			/// <summary> SkyrimSE.exe + 0x6260F0 </summary>
			static public System.IntPtr ApplyWeaponSwingSpell { get; }				= NetScriptFramework.Main.GameInfo.GetAddressOf(37628);
		}
	}
	
	
	
	internal class ApplySpellPerkEntryPoints
	{
		public ApplySpellPerkEntryPoints()
		{
			// spell != System.IntPtr.Zero
			// source != System.IntPtr.Zero
			// target != System.IntPtr.Zero

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Offsets.ApplySpellPerkEntryPoints.ApplyBashingSpell + 0x429,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = registers =>
				{
					SpellItem spell = registers.DX;
					Actor source = registers.R8;
					Actor target = registers.CX;

					spell.Apply(source, target);
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Offsets.ApplySpellPerkEntryPoints.ApplyCombatHitSpell + 0x79,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = registers =>
				{
					SpellItem spell = registers.DX;
					Actor source = registers.R8;
					Actor target = registers.CX;

					spell.Apply(source, target);
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Offsets.ApplySpellPerkEntryPoints.ApplyCombatHitSpellArrowProjectile + 0x2A7,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = registers =>
				{
					// arrow != System.IntPtr.Zero
					
					ArrowProjectile arrow = registers.DI;

					if ((arrow.Flags & ProjectileFlags.Is3DLoaded) != 0)
					{
						SpellItem spell = registers.DX;
						Actor source = registers.R8;
						Actor target = registers.CX;

						spell.Apply(source, target);
					}
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Offsets.ApplySpellPerkEntryPoints.ApplyReanimateSpell + 0xD2,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = registers =>
				{
					SpellItem spell = registers.DX;
					Actor source = registers.R8;
					Actor target = registers.CX;

					spell.Apply(source, target);
				}
			});

			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Offsets.ApplySpellPerkEntryPoints.ApplyWeaponSwingSpell + 0xC3,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 0,
				Before = registers =>
				{
					SpellItem spell = registers.DX;
					Actor source = registers.R8;
					Actor target = registers.CX;

					spell.Apply(source, target);
				}
			});
		}
	}
}
