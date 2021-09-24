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



	public interface IBGSEntryPointFunctionData : IVirtualObject
	{
	}

	public struct BGSEntryPointFunctionData : IBGSEntryPointFunctionData
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class IBGSEntryPointFunctionData
		{
			// Virtual
			static public EntryPointFunctionDataType GetDataType<TBGSEntryPointFunctionData>(this ref TBGSEntryPointFunctionData entryPointFunctionData)
				where TBGSEntryPointFunctionData : unmanaged, Eggstensions.IBGSEntryPointFunctionData
			{
				var getDataType = (delegate* unmanaged[Cdecl]<TBGSEntryPointFunctionData*, System.Int32>)entryPointFunctionData.VirtualFunction(0x1);

				return (EntryPointFunctionDataType)GetDataType(entryPointFunctionData.AsPointer());



				[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
				System.Int32 GetDataType(TBGSEntryPointFunctionData* entryPointFunctionData)
				{
					return getDataType(entryPointFunctionData);
				}
			}
		}
	}
}
