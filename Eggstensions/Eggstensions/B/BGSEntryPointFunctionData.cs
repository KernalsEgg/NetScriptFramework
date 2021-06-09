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



	public class BGSEntryPointFunctionData : VirtualObject
	{
		public BGSEntryPointFunctionData(System.IntPtr address) : base(address)
		{
		}



		new virtual public EntryPointFunctionDataType GetType()
		{
			var getType = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.BGSEntryPointFunctionData.GetType>(this[0x1]);

			return (EntryPointFunctionDataType)getType(this);
		}
	}
}
