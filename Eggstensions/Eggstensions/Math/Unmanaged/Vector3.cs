namespace Eggstensions.Math.Unmanaged
{
	public class Vector3 : Vector
	{
		new public Managed.Vector3 Elements
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

				return new Managed.Vector3(elements);
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



		public Vector3() : base(3) { }

		public Vector3(Managed.Vector3 vector3) : base(vector3, 3) { }

		public Vector3(System.IntPtr address) : base(address, 3) { }



		/// <summary>The x-coordinate of this Vector3.</summary>
		public System.Single X
		{
			get
			{
				return this[0, 0];
			}
			set
			{
				this[0, 0] = value;
			}
		}

		/// <summary>The y-coordinate of this Vector3.</summary>
		public System.Single Y
		{
			get
			{
				return this[0, 1];
			}
			set
			{
				this[0, 1] = value;
			}
		}

		/// <summary>The z-coordinate of this Vector3.</summary>
		public System.Single Z
		{
			get
			{
				return this[0, 2];
			}
			set
			{
				this[0, 2] = value;
			}
		}
	}
}
