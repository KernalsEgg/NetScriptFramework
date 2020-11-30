namespace Eggstensions.Math.Unmanaged
{
	public class Matrix33 : Matrix
	{
		public Matrix33() : base(3, 3) { }

		public Matrix33(System.Single[,] elements) : base(elements, 3, 3) { }

		public Matrix33(Managed.Matrix matrix) : base(matrix, 3, 3) { }

		public Matrix33(System.IntPtr address) : base(address, 3, 3) { }



		/// <summary>The interpolated Matrix33 at the specified ratio between this Matrix33 and another Matrix33.</summary>
		/// <returns>Matrix33</returns>
		public Managed.Matrix Interpolate(Matrix33 other, System.Single ratio)
		{
			if (other == null) { throw new Eggceptions.ArgumentNullException("other"); }
			// ratio

			return new Managed.Matrix(Library.Matrix33.Interpolate(Elements, other.Elements, ratio));
		}

		/// <summary>Rotate this Matrix33 about the x-axis.</summary>
		/// <param name="angle">Radians</param>
		/// <returns>Matrix33</returns>
		public Managed.Matrix RotateX(System.Single angle)
		{
			// angle

			return new Managed.Matrix(Library.Matrix33.RotateX(Elements, angle));
		}

		/// <summary>Rotate this Matrix33 about the y-axis.</summary>
		/// <param name="angle">Radians</param>
		/// <returns>Matrix33</returns>
		public Managed.Matrix RotateY(System.Single angle)
		{
			// angle

			return new Managed.Matrix(Library.Matrix33.RotateY(Elements, angle));
		}

		/// <summary>Rotate this Matrix33 about the z-axis.</summary>
		/// <param name="angle">Radians</param>
		/// <returns>Matrix33</returns>
		public Managed.Matrix RotateZ(System.Single angle)
		{
			// angle

			return new Managed.Matrix(Library.Matrix33.RotateZ(Elements, angle));
		}

		/// <summary>Convert this Matrix33 rotation matrix to axis-angle representation.</summary>
		/// <returns>Vector3 axis, Radians angle</returns>
		public (Managed.Matrix axis, System.Single angle) RotationMatrixToAxisAngle()
		{
			(var axis, var angle) = Library.Matrix33.RotationMatrixToAxisAngle(Elements);

			return (new Managed.Matrix(axis), angle);
		}

		/// <summary>Convert this Matrix33 rotation matrix to Euler angle representation (Rx, Ry, Rz).</summary>
		/// <returns>Vector3</returns>
		public Managed.Matrix RotationMatrixToEulerAngles()
		{
			return new Managed.Matrix(Library.Matrix33.RotationMatrixToEulerAngles(Elements));
		}
	}
}
