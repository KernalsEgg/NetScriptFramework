using Eggstensions.ExtensionMethods;



namespace Eggstensions.Math.Unmanaged
{
	public class Matrix : TemporaryObject
	{
		virtual public System.Int32 Size { get; } = 0x4; // > 0

		virtual public System.Int32? Padding { get; } = null; // >= Size * (Rows * Columns)



		virtual public System.Int32 Index(System.Int32 row, System.Int32 column)
		{
			return Columns * row + column;
		}



		public Matrix(System.Int32 rows, System.Int32 columns)
		{
			if (rows < 0) { throw new Eggceptions.ArgumentOutOfRangeException("rows"); }
			if (columns < 0) { throw new Eggceptions.ArgumentOutOfRangeException("columns"); }

			Rows = rows;
			Columns = columns;

			_allocation = NetScriptFramework.Memory.Allocate(Padding.HasValue ? Padding.Value : Size * Rows * Columns);
			_allocation.Pin();
			_allocation.Zero();
		}

		public Matrix(Managed.Matrix matrix, System.Int32? rows = null, System.Int32? columns = null)
			: this(rows.HasValue ? rows.Value : matrix.Rows, columns.HasValue ? columns.Value : matrix.Columns)
		{
			// matrix
			// rows
			// columns

			Elements = matrix;
		}

		public Matrix(System.IntPtr address, System.Int32 rows, System.Int32 columns)
		{
			if (address == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("address"); }
			if (rows < 0) { throw new Eggceptions.ArgumentOutOfRangeException("rows"); }
			if (columns < 0) { throw new Eggceptions.ArgumentOutOfRangeException("columns"); }

			Rows = rows;
			Columns = columns;

			_instance = address;
		}

		override protected void Free()
		{
			if (_allocation != null)
			{
				_allocation.Unpin();
				_allocation.Dispose();
			}
		}



		readonly private NetScriptFramework.MemoryAllocation _allocation;

		readonly private System.IntPtr _instance;



		/// <summary>The elements of this Matrix.</summary>
		public Managed.Matrix Elements
		{
			get
			{
				var elements = new System.Single[Rows, Columns];

				for (var row = 0; row < Rows; row++)
				{
					for (var column = 0; column < Columns; column++)
					{
						elements[row, column] = this[row, column];
					}
				}

				return new Managed.Matrix(elements);
			}
			set
			{
				if (value == null) { throw new Eggceptions.NullException("value"); }
				if (!value.HasDimensions(Rows, Columns)) { throw new Eggceptions.Math.Matrix.MatrixDimensionsException("this, value"); }

				var elements = value.Elements;

				for (var row = 0; row < Rows; row++)
				{
					for (var column = 0; column < Columns; column++)
					{
						this[row, column] = elements[row, column];
					}
				}
			}
		}

		/// <summary>The number of rows in this Matrix.</summary>
		public System.Int32 Rows { get; }

		/// <summary>The number of columns in this Matrix.</summary>
		public System.Int32 Columns { get; }

		public System.IntPtr Address
		{
			get
			{
				var address = _allocation?.Address ?? _instance;
				if (address == System.IntPtr.Zero) { throw new Eggceptions.NullException("address"); }

				return address;
			}
		}



		/// <summary>The specified element of this Matrix.</summary>
		public System.Single this[System.Int32 row, System.Int32 column]
		{
			get
			{
				if (row < 0 || row >= Rows) { throw new Eggceptions.ArgumentOutOfRangeException("row"); }
				if (column < 0 || column >= Columns) { throw new Eggceptions.ArgumentOutOfRangeException("column"); }

				return NetScriptFramework.Memory.ReadFloat(Address + Size * Index(row, column));
			}
			set
			{
				if (row < 0 || row >= Rows) { throw new Eggceptions.ArgumentOutOfRangeException("row"); }
				if (column < 0 || column >= Columns) { throw new Eggceptions.ArgumentOutOfRangeException("column"); }

				NetScriptFramework.Memory.WriteFloat(Address + Size * Index(row, column), value);
			}
		}
	}
}
