namespace Eggstensions.Bethesda
{
	/// <summary>Offsets_NiRTTI.h</summary>
	public class NiRTTI : System.Collections.Generic.IEnumerable<System.IntPtr>
	{
		public System.IntPtr Address { get; }



		public NiRTTI(System.IntPtr niRTTI)
		{
			if (niRTTI == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("niRTTI"); }

			Address = niRTTI;
		}



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
			_bsDismemberSkinInstance =	NetScriptFramework.Main.GameInfo.GetAddressOf(523941);
			_bsGeometry =				NetScriptFramework.Main.GameInfo.GetAddressOf(523951);
			_bsParticleShaderProperty =	NetScriptFramework.Main.GameInfo.GetAddressOf(527992);
			_bsTriShape =				NetScriptFramework.Main.GameInfo.GetAddressOf(523928);
			_niAVObject =				NetScriptFramework.Main.GameInfo.GetAddressOf(523895);
			_niNode =					NetScriptFramework.Main.GameInfo.GetAddressOf(523900);
			_niObject =					NetScriptFramework.Main.GameInfo.GetAddressOf(523891);
			_niProperty =				NetScriptFramework.Main.GameInfo.GetAddressOf(523929);
			_niSkinInstance =			NetScriptFramework.Main.GameInfo.GetAddressOf(523976);
		}



		readonly static private System.IntPtr _bsDismemberSkinInstance;

		readonly static private System.IntPtr _bsGeometry;

		readonly static private System.IntPtr _bsParticleShaderProperty;

		readonly static private System.IntPtr _bsTriShape;

		readonly static private System.IntPtr _niAVObject;

		readonly static private System.IntPtr _niNode;

		readonly static private System.IntPtr _niObject;

		readonly static private System.IntPtr _niProperty;

		readonly static private System.IntPtr _niSkinInstance;



		/// <summary>&lt;SkyrimSE.exe&gt; + 0x3013660 (VID523941)</summary>
		static public System.IntPtr BSDismemberSkinInstance		{ get { return _bsDismemberSkinInstance; } }

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x30136C8 (VID523951)</summary>
		static public System.IntPtr BSGeometry					{ get { return _bsGeometry; } }

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x32331B8 (VID527992)</summary>
		static public System.IntPtr BSParticleShaderProperty	{ get { return _bsParticleShaderProperty; } }

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x30125B0 (VID523928)</summary>
		static public System.IntPtr BSTriShape					{ get { return _bsTriShape; } }

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x30123C0 (VID523895)</summary>
		static public System.IntPtr NiAVObject					{ get { return _niAVObject; } }

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x30123E0 (VID523900)</summary>
		static public System.IntPtr NiNode						{ get { return _niNode; } }

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x3012388 (VID523891)</summary>
		static public System.IntPtr NiObject					{ get { return _niObject; } }

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x30125C0 (VID523929)</summary>
		static public System.IntPtr NiProperty					{ get { return _niProperty; } }

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x30138D0 (VID523976)</summary>
		static public System.IntPtr NiSkinInstance				{ get { return _niSkinInstance; } }



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
