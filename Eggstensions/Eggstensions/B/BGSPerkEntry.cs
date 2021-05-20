using Eggstensions.Interoperability.Managed; // Memory



namespace Eggstensions
{
	public enum PerkEntryPoint : System.Int32
	{
		ModArmorWeight			= 32,
		ApplyCombatHitSpell		= 51,
		ApplyBashingSpell		= 52,
		ApplyReanimateSpell		= 53,
		ApplyWeaponSwingSpell	= 67,
		ApplySneakingSpell		= 69
	}
	


	static public class BGSPerkEntry
	{
		static public System.IntPtr HandleEntryPoint(PerkEntryPoint perkEntryPoint, Actor perkOwner, System.IntPtr argument1)
		{
			using (var result = Memory.InitializeIntPtr(argument1))
			{
				Delegates.Instances.BGSPerkEntry.HandleEntryPoint1((System.Int32)perkEntryPoint, perkOwner, result.Address);

				return result.Value;
			}
		}

		static public System.IntPtr HandleEntryPoint(PerkEntryPoint perkEntryPoint, Actor perkOwner, System.IntPtr argument1, System.IntPtr argument2)
		{
			using (var result = Memory.InitializeIntPtr(argument2))
			{
				Delegates.Instances.BGSPerkEntry.HandleEntryPoint2((System.Int32)perkEntryPoint, perkOwner, argument1, result.Address);

				return result.Value;
			}
		}

		static public System.Single HandleEntryPoint(PerkEntryPoint perkEntryPoint, Actor perkOwner, System.IntPtr argument1, System.Single argument2)
		{
			using (var result = Memory.InitializeSingle(argument2))
			{
				Delegates.Instances.BGSPerkEntry.HandleEntryPoint2((System.Int32)perkEntryPoint, perkOwner, argument1, result.Address);

				return result.Value;
			}
		}

		static public System.IntPtr HandleEntryPoint(PerkEntryPoint perkEntryPoint, Actor perkOwner, System.IntPtr argument1, System.IntPtr argument2, System.IntPtr argument3)
		{
			using (var result = Memory.InitializeIntPtr(argument3))
			{
				Delegates.Instances.BGSPerkEntry.HandleEntryPoint3((System.Int32)perkEntryPoint, perkOwner, argument1, argument2, result.Address);

				return result.Value;
			}
		}
	}
}
