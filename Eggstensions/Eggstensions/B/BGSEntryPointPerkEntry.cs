namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x30)]
	unsafe public struct BGSEntryPointPerkEntry
	{
		[System.Runtime.InteropServices.FieldOffset(0x0)] public BGSPerkEntry BGSPerkEntry;
		[System.Runtime.InteropServices.FieldOffset(0x10)] public EntryPoint EntryPoint;
		[System.Runtime.InteropServices.FieldOffset(0x11)] public EntryPointFunction Function;
		[System.Runtime.InteropServices.FieldOffset(0x12)] public System.Byte ArgumentCount;



		// Static
		static public void HandleEntryPoints(EntryPoint entryPoint, Actor* perkOwner, void* result1)
		{
			Eggstensions.Delegates.Instances.BGSEntryPointPerkEntry.HandleEntryPoints1((System.Int32)entryPoint, perkOwner, result1);
		}

		static public void HandleEntryPoints(EntryPoint entryPoint, Actor* perkOwner, void* argument2, void* result1)
		{
			Eggstensions.Delegates.Instances.BGSEntryPointPerkEntry.HandleEntryPoints2((System.Int32)entryPoint, perkOwner, argument2, result1);
		}

		static public void HandleEntryPoints(EntryPoint entryPoint, Actor* perkOwner, void* argument2, void* argument3, void* result1)
		{
			Eggstensions.Delegates.Instances.BGSEntryPointPerkEntry.HandleEntryPoints3((System.Int32)entryPoint, perkOwner, argument2, argument3, result1);
		}
	}
}
