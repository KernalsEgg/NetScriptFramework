namespace Eggstensions.SkyrimSE
{
	/// <summary>Offsets_NiRTTI.h</summary>
	public class NiRTTI : System.Collections.Generic.IEnumerable<System.IntPtr>
	{
		public NiRTTI(System.IntPtr niRTTI)
		{
			if (niRTTI == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(niRTTI)); }

			Address = niRTTI;
		}



		public System.IntPtr Address { get; }



		public System.Collections.Generic.IEnumerator<System.IntPtr> GetEnumerator()
		{
			for (var niRTTI = Address; niRTTI != System.IntPtr.Zero; niRTTI = NetScriptFramework.Memory.ReadPointer(niRTTI + 0x8))
			{
				yield return niRTTI;
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}



		static NiRTTI()
		{
			BSDismemberSkinInstance =	NetScriptFramework.Main.GameInfo.GetAddressOf(523941);
			BSGeometry =				NetScriptFramework.Main.GameInfo.GetAddressOf(523951);
			BSParticleShaderProperty =	NetScriptFramework.Main.GameInfo.GetAddressOf(527992);
			BSTriShape =				NetScriptFramework.Main.GameInfo.GetAddressOf(523928);
			NiAVObject =				NetScriptFramework.Main.GameInfo.GetAddressOf(523895);
			NiNode =					NetScriptFramework.Main.GameInfo.GetAddressOf(523900);
			NiObject =					NetScriptFramework.Main.GameInfo.GetAddressOf(523891);
			NiProperty =				NetScriptFramework.Main.GameInfo.GetAddressOf(523929);
			NiSkinInstance =			NetScriptFramework.Main.GameInfo.GetAddressOf(523976);
		}



		/// <summary>SkyrimSE.exe + 0x3013660 (VID 523941)</summary>
		static public System.IntPtr BSDismemberSkinInstance { get; }

		/// <summary>SkyrimSE.exe + 0x30136C8 (VID 523951)</summary>
		static public System.IntPtr BSGeometry { get; }

		/// <summary>SkyrimSE.exe + 0x32331B8 (VID 527992)</summary>
		static public System.IntPtr BSParticleShaderProperty { get; }

		/// <summary>SkyrimSE.exe + 0x30125B0 (VID 523928)</summary>
		static public System.IntPtr BSTriShape { get; }

		/// <summary>SkyrimSE.exe + 0x30123C0 (VID 523895)</summary>
		static public System.IntPtr NiAVObject { get; }

		/// <summary>SkyrimSE.exe + 0x30123E0 (VID 523900)</summary>
		static public System.IntPtr NiNode { get; }

		/// <summary>SkyrimSE.exe + 0x3012388 (VID 523891)</summary>
		static public System.IntPtr NiObject { get; }

		/// <summary>SkyrimSE.exe + 0x30125C0 (VID 523929)</summary>
		static public System.IntPtr NiProperty { get; }

		/// <summary>SkyrimSE.exe + 0x30138D0 (VID 523976)</summary>
		static public System.IntPtr NiSkinInstance { get; }



		/*
			NiObject
				BSDismemberSkinInstance
				NiObjectNET
					NiAVObject
						BSGeometry
							BSTriShape
						NiNode
					NiProperty
						NiShadeProperty
							BSShaderProperty
								BSParticleShaderProperty
				NiSkinInstance
		*/
	}
}
