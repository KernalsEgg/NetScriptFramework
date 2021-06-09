namespace Eggstensions
{
	public class HandleEntryPointVisitor : VirtualObject
	{
		public HandleEntryPointVisitor(System.IntPtr address) : base(address)
		{
		}



		public EntryPointFunctionResult Result
		{
			get
			{
				return (EntryPointFunctionResult)Memory.Read<System.Int32>(this, 0x8);
			}
		}

		public Immutable.SequentialArray<System.IntPtr> Arguments
		{
			get
			{
				return new Immutable.SequentialArray<System.IntPtr>(Memory.Read<System.IntPtr>(this, 0x10), ArgumentCount);
			}
		}

		public Mutable.SequentialArray<System.IntPtr> Results
		{
			get
			{
				return new Mutable.SequentialArray<System.IntPtr>(Memory.Read<System.IntPtr>(this, 0x18), ResultCount);
			}
		}

		public Actor PerkOwner
		{
			get
			{
				return Memory.Read<System.IntPtr>(this, 0x20);
			}
		}

		public System.Byte ArgumentCount
		{
			get
			{
				return Memory.Read<System.Byte>(this, 0x28);
			}
		}

		public System.Byte ResultCount
		{
			get
			{
				return Memory.Read<System.Byte>(this, 0x29);
			}
		}



		static public implicit operator HandleEntryPointVisitor(System.IntPtr address)
		{
			return new HandleEntryPointVisitor(address);
		}
	}
}
