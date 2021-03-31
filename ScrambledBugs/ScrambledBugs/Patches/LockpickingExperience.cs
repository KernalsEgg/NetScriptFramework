namespace ScrambledBugs.Patches
{
	internal class LockpickingExperience
	{
		static protected class Offsets
		{
			static Offsets()
			{
				Offsets.HasBeenUnlocked = NetScriptFramework.Main.GameInfo.GetAddressOf(51088, 0x2C, 0, "75 50");
			}



			/// <summary> SkyrimSE.exe + 0x1E5050 </summary>
			static internal System.IntPtr HasBeenUnlocked { get; }
		}



		internal LockpickingExperience()
		{
			NetScriptFramework.Memory.WriteNop(LockpickingExperience.Offsets.HasBeenUnlocked, 2);
		}
	}
}
