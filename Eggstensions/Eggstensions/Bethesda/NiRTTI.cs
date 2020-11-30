namespace Eggstensions.Bethesda
{
	/// <summary>Offsets_NiRTTI.h</summary>
	static public class NiRTTI
	{
		/// <summary>&lt;SkyrimSE.exe&gt; + 0x3013660 (VID523941)</summary>
		static public System.IntPtr BSDismemberSkinInstance { get { return NetScriptFramework.Main.GameInfo.GetAddressOf(523941); } }

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x30136C8 (VID523951)</summary>
		static public System.IntPtr BSGeometry { get { return NetScriptFramework.Main.GameInfo.GetAddressOf(523951); } }

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x30123C0 (VID523895)</summary>
		static public System.IntPtr NiAVObject { get { return NetScriptFramework.Main.GameInfo.GetAddressOf(523895); } }

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x30123E0 (VID523900)</summary>
		static public System.IntPtr NiNode { get { return NetScriptFramework.Main.GameInfo.GetAddressOf(523900); } }

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x3012388 (VID523891)</summary>
		static public System.IntPtr NiObject { get { return NetScriptFramework.Main.GameInfo.GetAddressOf(523891); } }

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x30138D0 (VID523976)</summary>
		static public System.IntPtr NiSkinInstance { get { return NetScriptFramework.Main.GameInfo.GetAddressOf(523976); } }
	}
}
