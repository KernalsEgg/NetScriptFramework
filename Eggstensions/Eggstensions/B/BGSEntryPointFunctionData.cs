namespace Eggstensions
{
	public enum EntryPointFunctionDataType : System.Int32
	{
		Invalid					= 0,
		OneValue				= 1,
		TwoValue				= 2,
		LeveledList				= 3,
		ActivateChoice			= 4,
		SpellItem				= 5,
		BooleanGraphVariable	= 6,
		Text					= 7
	}



	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x8)]
	unsafe public struct BGSEntryPointFunctionData
	{
		// Virtual
		static public EntryPointFunctionDataType GetType(BGSEntryPointFunctionData* entryPointFunctionData)
		{
			var getType = Memory.ReadVirtualFunction<Eggstensions.Delegates.Types.BGSEntryPointFunctionData.GetType>(*(System.IntPtr*)entryPointFunctionData, 0x1);

			return (EntryPointFunctionDataType)getType(entryPointFunctionData);
		}
	}
}
