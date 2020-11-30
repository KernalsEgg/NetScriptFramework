namespace Eggstensions.Math.Unmanaged
{
	public class Vector3 : Vector
	{
		public Vector3() : base(3) { }

		public Vector3(System.Single[,] elements) : base(elements, 3) { }

		public Vector3(Managed.Matrix matrix) : base(matrix, 3) { }

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



		/// <summary>Convert this Vector3 from axis-angle representation to a rotation matrix.</summary>
		/// <param name="angle">Radians</param>
		/// <returns>Matrix33</returns>
		public Managed.Matrix AxisAngleToRotationMatrix(System.Single angle)
		{
			// angle

			return new Managed.Matrix(Library.Vector3.AxisAngleToRotationMatrix(Elements, angle));
		}

		/// <summary>Convert this Vector3 from Euler angle representation to a rotation matrix.</summary>
		/// <returns>Matrix33</returns>
		public Managed.Matrix EulerAnglesToRotationMatrix()
		{
			return new Managed.Matrix(Library.Vector3.EulerAnglesToRotationMatrix(Elements));
		}

		/// <summary>Rotate this Vector3 about the x-axis.</summary>
		/// <param name="angle">Radians</param>
		/// <returns>Vector3</returns>
		public Managed.Matrix RotateX(System.Single angle)
		{
			// angle

			return new Managed.Matrix(Library.Matrix33.RotateX(Elements, angle));
		}

		/// <summary>Rotate this Vector3 about the y-axis.</summary>
		/// <param name="angle">Radians</param>
		/// <returns>Vector3</returns>
		public Managed.Matrix RotateY(System.Single angle)
		{
			// angle

			return new Managed.Matrix(Library.Matrix33.RotateY(Elements, angle));
		}

		/// <summary>Rotate this Vector3 about the z-axis.</summary>
		/// <param name="angle">Radians</param>
		/// <returns>Vector3</returns>
		public Managed.Matrix RotateZ(System.Single angle)
		{
			// angle

			return new Managed.Matrix(Library.Matrix33.RotateZ(Elements, angle));
		}

		/// <summary>The rotation matrix necessary to rotate this Vector3 onto another Vector3.</summary>
		/// <returns>Matrix33</returns>
		public Managed.Matrix RotationMatrixBetween(Vector3 other)
		{
			if (other == null) { throw new Eggceptions.ArgumentNullException("other"); }

			return new Managed.Matrix(Library.Vector3.RotationMatrixBetween(Elements, other.Elements));
		}
	}
}
