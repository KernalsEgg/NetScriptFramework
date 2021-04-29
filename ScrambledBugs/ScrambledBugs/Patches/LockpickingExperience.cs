namespace ScrambledBugs.Patches
{
	internal class LockpickingExperience
	{
		static protected class Offsets
		{
			static Offsets()
			{
				Offsets.HasNotBeenUnlocked = NetScriptFramework.Main.GameInfo.GetAddressOf(51088, 0x2C, 0, "75 50"); // 2
			}



			/// <summary> SkyrimSE.exe + 0x897E10 </summary>
			static internal System.IntPtr HasNotBeenUnlocked { get; }
		}



		internal LockpickingExperience()
		{
			NetScriptFramework.Memory.WriteNop(LockpickingExperience.Offsets.HasNotBeenUnlocked, 2);
		}
	}
}
