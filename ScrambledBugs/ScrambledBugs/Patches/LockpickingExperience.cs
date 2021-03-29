namespace ScrambledBugs.Patches
{
	internal class LockpickingExperience
	{
		static internal class Offsets
		{
			static Offsets()
			{
				Offsets.HasBeenUnlocked = NetScriptFramework.Main.GameInfo.GetAddressOf(51088, 0x2C, 0, "75 50"); // SkyrimSE.exe + 0x1E5050
			}



			static internal System.IntPtr HasBeenUnlocked { get; }
		}



		internal LockpickingExperience()
		{
			NetScriptFramework.Memory.WriteNop(LockpickingExperience.Offsets.HasBeenUnlocked, 2);
		}
	}
}
