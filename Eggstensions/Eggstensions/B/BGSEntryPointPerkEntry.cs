namespace Eggstensions
{
	namespace Marshal
	{
		public class BGSEntryPointPerkEntry
		{
			static public void HandleEntryPoints(EntryPoint entryPoint, Actor perkOwner, Marshal.BSTArray result1)
			{
				Delegates.Instances.BGSEntryPointPerkEntry.HandleEntryPoints1BSTArray((System.Int32)entryPoint, perkOwner, result1);
			}

			static public void HandleEntryPoints(EntryPoint entryPoint, Actor perkOwner, System.IntPtr argument2, Marshal.BSTArray result1)
			{
				Delegates.Instances.BGSEntryPointPerkEntry.HandleEntryPoints2BSTArray((System.Int32)entryPoint, perkOwner, argument2, result1);
			}

			static public void HandleEntryPoints(EntryPoint entryPoint, Actor perkOwner, System.IntPtr argument2, System.IntPtr argument3, Marshal.BSTArray result1)
			{
				Delegates.Instances.BGSEntryPointPerkEntry.HandleEntryPoints3BSTArray((System.Int32)entryPoint, perkOwner, argument2, argument3, result1);
			}
		}
	}



	public class BGSEntryPointPerkEntry : BGSPerkEntry
	{
		public BGSEntryPointPerkEntry(System.IntPtr address) : base(address)
		{
		}



		public EntryPoint EntryPoint
		{
			get
			{
				return (EntryPoint)Memory.Read<System.Byte>(this, 0x10);
			}
		}

		public EntryPointFunction Function
		{
			get
			{
				return (EntryPointFunction)Memory.Read<System.Byte>(this, 0x11);
			}
		}

		public System.Byte ArgumentCount
		{
			get
			{
				return Memory.Read<System.Byte>(this, 0x12);
			}
		}



		static public void HandleEntryPoints(EntryPoint entryPoint, Actor perkOwner, ref System.IntPtr result1)
		{
			Delegates.Instances.BGSEntryPointPerkEntry.HandleEntryPoints1IntPtr((System.Int32)entryPoint, perkOwner, ref result1);
		}

		static public void HandleEntryPoints(EntryPoint entryPoint, Actor perkOwner, System.IntPtr argument2, ref System.IntPtr result1)
		{
			Delegates.Instances.BGSEntryPointPerkEntry.HandleEntryPoints2IntPtr((System.Int32)entryPoint, perkOwner, argument2, ref result1);
		}

		static public void HandleEntryPoints(EntryPoint entryPoint, Actor perkOwner, System.IntPtr argument2, ref System.Single result1)
		{
			Delegates.Instances.BGSEntryPointPerkEntry.HandleEntryPoints2Single((System.Int32)entryPoint, perkOwner, argument2, ref result1);
		}

		static public void HandleEntryPoints(EntryPoint entryPoint, Actor perkOwner, System.IntPtr argument2, System.IntPtr argument3, ref System.IntPtr result1)
		{
			Delegates.Instances.BGSEntryPointPerkEntry.HandleEntryPoints3IntPtr((System.Int32)entryPoint, perkOwner, argument2, argument3, ref result1);
		}



		static public implicit operator BGSEntryPointPerkEntry(System.IntPtr address)
		{
			return new BGSEntryPointPerkEntry(address);
		}
	}
}
