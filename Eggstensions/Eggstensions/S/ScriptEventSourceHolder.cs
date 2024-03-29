﻿namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x1290)]
	unsafe public struct ScriptEventSourceHolder
	{
		[System.Runtime.InteropServices.FieldOffset(0x5D8)] public BSTEventSource TESHitEvent;



		static public ScriptEventSourceHolder* Instance
		{
			get
			{
				var getInstance = (delegate* unmanaged[Cdecl]<ScriptEventSourceHolder*>)Eggstensions.Offsets.ScriptEventSourceHolder.GetInstance;

				return getInstance();
			}
		}
	}
}
