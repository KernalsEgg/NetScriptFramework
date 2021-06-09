using Eggstensions;



namespace Eggstensions
{
	namespace Immutable
	{
		public class Union<T> : NativeObject
			where T : unmanaged
		{
			public Union(System.IntPtr address) : base(address)
			{
			}

			public Union(System.IntPtr address, System.Int32 offset) : this(address + offset)
			{
			}



			public T Value
			{
				get
				{
					return Memory.Read<T>(this);
				}
			}



			static public implicit operator Union<T>(System.IntPtr address)
			{
				return new Union<T>(address);
			}
		}
	}

	namespace Mutable
	{
		public class Union<T> : NativeObject
			where T : unmanaged
		{
			public Union(System.IntPtr address) : base(address)
			{
			}

			public Union(System.IntPtr address, System.Int32 offset) : this(address + offset)
			{
			}


			
			public T Value
			{
				get
				{
					return Memory.Read<T>(this);
				}
				set
				{
					Memory.Write<T>(this, value);
				}
			}



			static public implicit operator Union<T>(System.IntPtr address)
			{
				return new Union<T>(address);
			}
		}
	}
}
