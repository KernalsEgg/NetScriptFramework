namespace Eggstensions
{
	public class UnmanagedArray<TDestination> : System.Collections.Generic.ICollection<TDestination>, System.Collections.Generic.IEnumerable<TDestination>, System.Collections.Generic.IList<TDestination>, System.Collections.Generic.IReadOnlyCollection<TDestination>, System.Collections.Generic.IReadOnlyList<TDestination>
		where TDestination : unmanaged, System.IEquatable<TDestination>
	{
		private TDestination[] elements = new TDestination[0];



		public TDestination this[System.Int32 index]
		{
			get
			{
				return this.elements[index];
			}
			set
			{
				this.Insert(index, value);
			}
		}
		


		public System.Int32 Count
		{
			get
			{
				return this.elements.Length;
			}
		}

		public System.Boolean IsReadOnly
		{
			get
			{
				return false;
			}
		}



		static public UnmanagedArray<TDestination> CreateInstance(TDestination element)
		{
			var array = new UnmanagedArray<TDestination>();
			array.Add(element);

			return array;
		}

		static public UnmanagedArray<TDestination> CreateInstance(TDestination[] elements)
		{
			var array = new UnmanagedArray<TDestination>();
			array.Add(elements);

			return array;
		}

		static public UnmanagedArray<TDestination> CreateInstance<TSource>(TSource element)
			where TSource : unmanaged
		{
			var array = new UnmanagedArray<TDestination>();
			array.Add(element);

			return array;
		}

		static public UnmanagedArray<TDestination> CreateInstance<TSource>(TSource[] elements)
			where TSource : unmanaged
		{
			var array = new UnmanagedArray<TDestination>();
			array.Add(elements);

			return array;
		}



		public void Add(TDestination element)
		{
			var copy = new TDestination[this.elements.Length + 1];

			for (var index = 0; index < this.elements.Length; index++)
			{
				copy[index] = this.elements[index];
			}

			copy[this.elements.Length + 1] = element;

			this.elements = copy;
		}

		public void Add(TDestination[] elements)
		{
			var copy = new TDestination[this.elements.Length + elements.Length];

			for (var index = 0; index < this.elements.Length; index++)
			{
				copy[index] = this.elements[index];
			}

			for (var index = 0; index < elements.Length; index++)
			{
				copy[this.elements.Length + index] = elements[index];
			}

			this.elements = copy;
		}

		public void Add<TSource>(TSource element)
			where TSource : unmanaged
		{
			this.Add(Memory.ConvertToArray<TSource, TDestination>(element));
		}

		public void Add<TSource>(TSource[] elements)
			where TSource : unmanaged
		{
			this.Add(Memory.ConvertToArray<TSource, TDestination>(elements));
		}

		public void Clear()
		{
			this.elements = new TDestination[0];
		}

		public System.Boolean Contains(TDestination element)
		{
			for (var index = 0; index < this.elements.Length; index++)
			{
				if (this.elements[index].Equals(element))
				{
					return true;
				}
			}

			return false;
		}

		public TDestination[] Copy()
		{
			var copy = new TDestination[this.elements.Length];

			for (var index = 0; index < this.elements.Length; index++)
			{
				copy[index] = this.elements[index];
			}

			return copy;
		}

		public void CopyTo(TDestination[] array, System.Int32 destinationIndex)
		{
			for (var index = 0; index < this.elements.Length; index++)
			{
				array[destinationIndex + index] = this.elements[index];
			}
		}

		public System.Collections.Generic.IEnumerator<TDestination> GetEnumerator()
		{
			for (var index = 0; index < this.elements.Length; index++)
			{
				yield return this.elements[index];
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public System.Int32 IndexOf(TDestination element)
		{
			for (var index = 0; index < this.elements.Length; index++)
			{
				if (this.elements[index].Equals(element))
				{
					return index;
				}
			}

			return -1;
		}

		public void Insert(System.Int32 destinationIndex, TDestination element)
		{
			var copy = new TDestination[this.elements.Length + 1];

			for (var index = 0; index < destinationIndex; index++)
			{
				copy[index] = this.elements[index];
			}

			copy[destinationIndex] = element;

			for (var index = destinationIndex; index < this.elements.Length; index++)
			{
				copy[index + 1] = this.elements[index];
			}

			this.elements = copy;
		}

		public System.Boolean Remove(TDestination element)
		{
			var index = this.IndexOf(element);

			if (index >= 0)
			{
				this.RemoveAt(index);

				return true;
			}

			return false;
		}

		public void RemoveAt(System.Int32 destinationIndex)
		{
			var copy = new TDestination[this.elements.Length - 1];

			for (var index = 0; index < destinationIndex; index++)
			{
				copy[index] = this.elements[index];
			}

			for (var index = destinationIndex; index + 1 < this.elements.Length; index++)
			{
				copy[index] = this.elements[index + 1];
			}

			this.elements = copy;
		}



		static public implicit operator TDestination[](UnmanagedArray<TDestination> array)
		{
			return array.Copy();
		}
	}
}
