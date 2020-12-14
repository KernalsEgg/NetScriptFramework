namespace Eggstensions.Math.Unmanaged
{
	public class Vector : Matrix
	{
		new public Managed.Vector Elements
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

				return new Managed.Vector(elements);
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



		public Vector(System.Int32 columns) : base(1, columns) { }

		public Vector(Managed.Vector vector, System.Int32? columns = null) : base(vector, 1, columns) { }

		public Vector(System.IntPtr address, System.Int32 columns) : base(address, 1, columns) { }
	}
}
