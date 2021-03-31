namespace ScrambledBugs.Fixes
{
	internal class ModArmorWeightPerkEntryPoints
	{
		static protected class Offsets
		{
			static Offsets()
			{
				Offsets.ApplyPerkEntryPoints =	NetScriptFramework.Main.GameInfo.GetAddressOf(23073);
				Offsets.GetTotalItemWeight =	NetScriptFramework.Main.GameInfo.GetAddressOf(15883);
			}



			/// <summary> SkyrimSE.exe + 0x32ECE0 </summary>
			static internal System.IntPtr ApplyPerkEntryPoints { get; }

			/// <summary> SkyrimSE.exe + 0x1E9130 </summary>
			static internal System.IntPtr GetTotalItemWeight { get; }
		}



		internal ModArmorWeightPerkEntryPoints()
		{
			NetScriptFramework.Memory.WriteHook(new NetScriptFramework.HookParameters()
			{
				Address = ModArmorWeightPerkEntryPoints.Offsets.GetTotalItemWeight + 0x29F,
				Pattern = "E8 ?? ?? ?? ??" + "F3 0F10 8C 24 B0000000" + "F3 0F58 F1",
				ReplaceLength = 5 + 9 + 4,
				IncludeLength = 0,
				Before = cpuRegisters =>
				{
					cpuRegisters.XMM1f = NetScriptFramework.Memory.ReadFloat(cpuRegisters.R9);
					NetScriptFramework.Memory.InvokeCdecl(ModArmorWeightPerkEntryPoints.Offsets.ApplyPerkEntryPoints, cpuRegisters.CX, cpuRegisters.DX, cpuRegisters.R8, cpuRegisters.R9);
					cpuRegisters.XMM6f += NetScriptFramework.Memory.ReadFloat(cpuRegisters.R9);
				}
			});
		}
	}
}
