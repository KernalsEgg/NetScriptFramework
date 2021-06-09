namespace Eggstensions
{
	namespace Immutable
	{
		public class SequentialArray<T> : NativeObject, System.Collections.Generic.IEnumerable<T>
			where T : unmanaged
		{
			public SequentialArray(System.IntPtr address, System.Int32 length) : base(address)
			{
				Length = length;
			}



			public T this[System.Int32 index]
			{
				get
				{
					return Memory.Read<T>(this, Memory<T>.Size * index);
				}
			}



			public System.Collections.Generic.IEnumerator<T> GetEnumerator()
			{
				for (System.Int32 index = 0; index < Length; index++)
				{
					yield return this[index];
				}
			}

			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}



			public System.Int32 Length { get; }
		}
	}

	namespace Mutable
	{
		public class SequentialArray<T> : NativeObject, System.Collections.Generic.IEnumerable<T>
			where T : unmanaged
		{
			public SequentialArray(System.IntPtr address, System.Int32 length) : base(address)
			{
				Length = length;
			}



			public T this[System.Int32 index]
			{
				get
				{
					return Memory.Read<T>(this, Memory<T>.Size * index);
				}
				set
				{
					Memory.Write<T>(this, Memory<T>.Size * index, value);
				}
			}



			public System.Collections.Generic.IEnumerator<T> GetEnumerator()
			{
				for (System.Int32 index = 0; index < Length; index++)
				{
					yield return this[index];
				}
			}

			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}



			public System.Int32 Length { get; }
		}
	}
}
