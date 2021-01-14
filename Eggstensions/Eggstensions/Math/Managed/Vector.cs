using Eggstensions.ExtensionMethods;



namespace Eggstensions.Math.Managed
{
	public class Vector : Matrix
	{
		#region New methods
		/// <summary>The zero Vector with the specified columns.</summary>
		public Vector Zero(System.Int32 columns)
		{
			return new Vector(Library.Matrix.Zero(Rows, columns));
		}
		#endregion



		public Vector(System.Single[,] elements)
			: base(elements)
		{
			if (Rows != 1) { throw new Eggceptions.Math.Matrix.ArgumentMatrixDimensionsException(nameof(elements)); }
		}



		#region Properties
		/// <summary>If this Vector is normalized.</summary>
		public System.Boolean IsNormalized
		{
			get
			{
				return Library.Vector.IsNormalized(Elements);
			}
		}

		/// <summary>The magnitude of this Vector.</summary>
		public System.Single Magnitude
		{
			get
			{
				return Library.Vector.Magnitude(Elements);
			}
		}
		#endregion



		#region Methods
		/// <summary>The angle between this Vector and another Vector.</summary>
		/// <returns>Radians</returns>
		public System.Single AngleBetween(Vector other)
		{
			if (other == null) { throw new Eggceptions.ArgumentNullException(nameof(other)); }

			return Library.Vector.AngleBetween(Elements, other.Elements);
		}

		/// <summary>If the cross product of this Vector and other Vector's can be calculated. Valid only in 3D and 7D.</summary>
		public System.Boolean CanCrossProduct(params Vector[] others)
		{
			if (others.IsNullOrSparse(1)) { throw new Eggceptions.ArgumentNullOrSparseException(nameof(others)); }

			var elements = others.Convert(other => other.Elements).Unshift(Elements);

			return Library.Vector.CanCrossProduct(elements);
		}

		/// <summary>If the dot product of this Vector and another Vector can be calculated.</summary>
		public System.Boolean CanDotProduct(Vector other)
		{
			if (other == null) { throw new Eggceptions.ArgumentNullException(nameof(other)); }

			return Library.Vector.CanDotProduct(Elements, other.Elements);
		}

		/// <summary>The cross product of this Vector and other Vector's.</summary>
		public Vector CrossProduct(params Vector[] others)
		{
			if (others.IsNullOrSparse(1)) { throw new Eggceptions.ArgumentNullOrSparseException(nameof(others)); }

			var elements = others.Convert(other => other.Elements).Unshift(Elements);

			return new Vector(Library.Vector.CrossProduct(elements));
		}

		/// <summary>The distance between this Vector and another Vector.</summary>
		public System.Single DistanceBetween(Vector other)
		{
			if (other == null) { throw new Eggceptions.ArgumentNullException(nameof(other)); }

			return Library.Vector.DistanceBetween(Elements, other.Elements);
		}

		/// <summary>The dot product of this Vector and another Vector.</summary>
		public System.Single DotProduct(Vector other)
		{
			if (other == null) { throw new Eggceptions.ArgumentNullException(nameof(other)); }

			return Library.Vector.DotProduct(Elements, other.Elements);
		}

		/// <summary>The normalization of this Vector.</summary>
		public Vector Normalize()
		{
			return new Vector(Library.Vector.Normalize(Elements));
		}
		#endregion



		#region Operator overloading
		// Vector + Vector
		static public Vector operator +(Vector left, Vector right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Vector(Library.Matrix.Add(left.Elements, right.Elements));
		}

		// Vector + System.Single
		static public Vector operator +(Vector vector, System.Single scalar)
		{
			if (vector == null) { throw new Eggceptions.ArgumentNullException(nameof(vector)); }
			// scalar

			return new Vector(Library.Matrix.Add(vector.Elements, scalar));
		}

		// System.Single + Vector
		static public Vector operator +(System.Single scalar, Vector vector)
		{
			// scalar
			if (vector == null) { throw new Eggceptions.ArgumentNullException(nameof(vector)); }

			return new Vector(Library.Matrix.Add(vector.Elements, scalar));
		}

		// Vector + System.Single[,]
		static public Vector operator +(Vector left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Vector(Library.Matrix.Add(left.Elements, right));
		}

		// System.Single[,] + Vector
		static public Vector operator +(System.Single[,] left, Vector right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Vector(Library.Matrix.Add(left, right.Elements));
		}

		// -Vector
		static public Vector operator -(Vector vector)
		{
			if (vector == null) { throw new Eggceptions.ArgumentNullException(nameof(vector)); }

			return new Vector(Library.Matrix.Negate(vector.Elements));
		}

		// Vector - Vector
		static public Vector operator -(Vector left, Vector right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Vector(Library.Matrix.Subtract(left.Elements, right.Elements));
		}

		// Vector - System.Single
		static public Vector operator -(Vector vector, System.Single scalar)
		{
			if (vector == null) { throw new Eggceptions.ArgumentNullException(nameof(vector)); }
			// scalar

			return new Vector(Library.Matrix.Subtract(vector.Elements, scalar));
		}

		// System.Single - Vector
		static public Vector operator -(System.Single scalar, Vector vector)
		{
			// scalar
			if (vector == null) { throw new Eggceptions.ArgumentNullException(nameof(vector)); }

			return new Vector(Library.Matrix.Subtract(scalar, vector.Elements));
		}

		// Vector - System.Single[,]
		static public Vector operator -(Vector left, System.Single[,] right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Vector(Library.Matrix.Subtract(left.Elements, right));
		}

		// System.Single[,] - Vector
		static public Vector operator -(System.Single[,] left, Vector right)
		{
			if (left == null) { throw new Eggceptions.ArgumentNullException(nameof(left)); }
			if (right == null) { throw new Eggceptions.ArgumentNullException(nameof(right)); }

			return new Vector(Library.Matrix.Subtract(left, right.Elements));
		}

		// Vector * Vector

		// Vector * System.Single
		static public Vector operator *(Vector vector, System.Single scalar)
		{
			if (vector == null) { throw new Eggceptions.ArgumentNullException(nameof(vector)); }
			// scalar

			return new Vector(Library.Matrix.Multiply(vector.Elements, scalar));
		}

		// System.Single * Vector
		static public Vector operator *(System.Single scalar, Vector vector)
		{
			// scalar
			if (vector == null) { throw new Eggceptions.ArgumentNullException(nameof(vector)); }

			return new Vector(Library.Matrix.Multiply(vector.Elements, scalar));
		}

		// Vector * System.Single[,]

		// System.Single[,] * Vector
		#endregion
	}
}
