namespace Eggstensions.Math.Managed
{
	public class Quaternion : Vector
	{
		#region New methods
		// The cross product is only valid in 3D and 7D

		/// <summary>The normalization of this Vector.</summary>
		new public Quaternion Normalize()
		{
			return new Quaternion(Library.Vector.Normalize(Elements));
		}

		/// <summary>The zero Quaternion.</summary>
		public Quaternion Zero()
		{
			return new Quaternion(Library.Matrix.Zero(Rows, Columns));
		}
		#endregion



		public Quaternion(System.Single[,] elements)
			: base(elements)
		{
			if (Columns != 4) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException("elements"); }
		}



		#region Properties
		/// <summary>The w-coordinate of this Vector4.</summary>
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

		/// <summary>The x-coordinate of this Vector4.</summary>
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

		/// <summary>The y-coordinate of this VVector4ector3.</summary>
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

		/// <summary>The z-coordinate of this Vector4.</summary>
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
		#endregion



		#region Methods
		public Matrix33 QuaternionToMatrix33()
		{
			return new Matrix33(Library.Quaternion.QuaternionToMatrix33(Elements));
		}
		#endregion



		#region Operator overloading
		// Quaternion + Quaternion
		static public Quaternion operator +(Quaternion left, Quaternion right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Quaternion(Library.Matrix.Add(left.Elements, right.Elements));
		}

		// Quaternion + System.Single
		static public Quaternion operator +(Quaternion quaternion, System.Single scalar)
		{
			if (quaternion == null) { throw new Eggceptions.ArgumentNullException("quaternion"); }
			// scalar

			return new Quaternion(Library.Matrix.Add(quaternion.Elements, scalar));
		}

		// System.Single + Quaternion
		static public Quaternion operator +(System.Single scalar, Quaternion quaternion)
		{
			// scalar
			if (quaternion == null) { throw new Eggceptions.ArgumentNullException("quaternion"); }

			return new Quaternion(Library.Matrix.Add(quaternion.Elements, scalar));
		}

		// Quaternion + System.Single[,]
		static public Quaternion operator +(Quaternion left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Quaternion(Library.Matrix.Add(left.Elements, right));
		}

		// System.Single[,] + QuaternionQuaternion
		static public Quaternion operator +(System.Single[,] left, Quaternion right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Quaternion(Library.Matrix.Add(left, right.Elements));
		}

		// -Quaternion
		static public Quaternion operator -(Quaternion quaternion)
		{
			if (quaternion == null) { throw new Eggceptions.ArgumentNullException("quaternion"); }

			return new Quaternion(Library.Matrix.Negate(quaternion.Elements));
		}

		// Quaternion - Quaternion
		static public Quaternion operator -(Quaternion left, Quaternion right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Quaternion(Library.Matrix.Subtract(left.Elements, right.Elements));
		}

		// Quaternion - System.Single
		static public Quaternion operator -(Quaternion quaternion, System.Single scalar)
		{
			if (quaternion == null) { throw new Eggceptions.ArgumentNullException("quaternion"); }
			// scalar

			return new Quaternion(Library.Matrix.Subtract(quaternion.Elements, scalar));
		}

		// System.Single - Quaternion
		static public Quaternion operator -(System.Single scalar, Quaternion quaternion)
		{
			// scalar
			if (quaternion == null) { throw new Eggceptions.ArgumentNullException("quaternion"); }

			return new Quaternion(Library.Matrix.Subtract(scalar, quaternion.Elements));
		}

		// Quaternion - System.Single[,]
		static public Quaternion operator -(Quaternion left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Quaternion(Library.Matrix.Subtract(left.Elements, right));
		}

		// System.Single[,] - Quaternion
		static public Quaternion operator -(System.Single[,] left, Quaternion right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException("left"); }
			if (right == null) { throw new Eggceptions.ArgumentNullException("right"); }

			return new Quaternion(Library.Matrix.Subtract(left, right.Elements));
		}

		// Quaternion * Quaternion

		// Quaternion * System.Single
		static public Quaternion operator *(Quaternion quaternion, System.Single scalar)
		{
			if (quaternion == null) { throw new Eggceptions.ArgumentNullException("quaternion"); }
			// scalar

			return new Quaternion(Library.Matrix.Multiply(quaternion.Elements, scalar));
		}

		// System.Single * Quaternion
		static public Quaternion operator *(System.Single scalar, Quaternion quaternion)
		{
			// scalar
			if (quaternion == null) { throw new Eggceptions.ArgumentNullException("quaternion"); }

			return new Quaternion(Library.Matrix.Multiply(quaternion.Elements, scalar));
		}

		// Quaternion * System.Single[,]

		// System.Single[,] * Quaternion
		#endregion
	}
}
