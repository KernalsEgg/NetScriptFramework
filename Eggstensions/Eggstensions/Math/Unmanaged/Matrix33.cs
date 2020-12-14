namespace Eggstensions.Math.Unmanaged
{
	public class Matrix33 : Matrix
	{
		new public Managed.Matrix33 Elements
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

				return new Managed.Matrix33(elements);
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



		public Matrix33() : base(3, 3) { }

		public Matrix33(Managed.Matrix33 matrix33) : base(matrix33, 3, 3) { }

		public Matrix33(System.IntPtr address) : base(address, 3, 3) { }
	}
}
