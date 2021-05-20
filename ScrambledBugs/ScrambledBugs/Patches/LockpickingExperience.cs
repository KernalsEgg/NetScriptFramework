using Eggstensions.Interoperability.Managed; // Memory



namespace ScrambledBugs.Patches
{
	namespace Offsets
	{
		static internal class LockpickingExperience
		{
			/// <summary> SkyrimSE.exe + 0x897E10 </summary>
			static public System.IntPtr HasNotBeenUnlocked { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(51088, 0x2C, 0, "75 50"); // 2
		}
	}
	


	internal class LockpickingExperience
	{
		public LockpickingExperience()
		{
			Memory.SafeWriteNopArray(Offsets.LockpickingExperience.HasNotBeenUnlocked, 2);
		}
	}
}
