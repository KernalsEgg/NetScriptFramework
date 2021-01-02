namespace Eggstensions.Math.Unmanaged
{
	public class Quaternion : Vector
	{
		new public Managed.Quaternion Elements
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

				return new Managed.Quaternion(elements);
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



		public Quaternion() : base(4) { }

		public Quaternion(Managed.Quaternion quaternion) : base(quaternion, 4) { }

		public Quaternion(System.IntPtr address) : base(address, 4) { }



		/// <summary>The w-coordinate of this Quaternion.</summary>
		public System.Single W
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

		/// <summary>The x-coordinate of this Quaternion.</summary>
		public System.Single X
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

		/// <summary>The y-coordinate of this Quaternion.</summary>
		public System.Single Y
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

		/// <summary>The z-coordinate of this Quaternion.</summary>
		public System.Single Z
		{
			get
			{
				return this[0, 3];
			}
			set
			{
				this[0, 3] = value;
			}
		}
	}
}
