using Eggstensions;



namespace ScrambledBugs.Fixes
{
	namespace Offsets
	{
		static internal class HarvestedFlags
		{
			/// <summary> SkyrimSE.exe + 0x278920 </summary>
			static public System.IntPtr Respawn { get; } = NetScriptFramework.Main.GameInfo.GetAddressOf(18843);
		}
	}


	
	internal class HarvestedFlags
	{
		public HarvestedFlags()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = Offsets.HarvestedFlags.Respawn + 0x31C,
				Pattern = "E8 ?? ?? ?? ??",
				ReplaceLength = 5,
				IncludeLength = 5,
				Before = registers =>
				{
					// reference != System.IntPtr.Zero
					
					TESObjectREFR reference = registers.CX;

					var baseObject = reference.BaseObject;
					var formType = baseObject.FormType;

					if (formType == FormType.Flora || formType == FormType.Tree)
					{
						reference.RemoveChanges((System.UInt32)TESObjectREFR.ChangeFlags.Empty);
					}
				}
			});
		}
	}
}
