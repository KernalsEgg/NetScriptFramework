using Eggstensions.ExtensionMethods;



namespace Eggstensions.Math.Unmanaged
{
	public class Vector : Matrix
	{
		public Vector(System.Int32 columns) : base(1, columns) { }

		public Vector(System.Single[,] elements, System.Int32? columns = null) : base(elements, 1, columns) { }

		public Vector(Managed.Matrix matrix, System.Int32? columns = null) : base(matrix, 1, columns) { }

		public Vector(System.IntPtr address, System.Int32 columns) : base(address, 1, columns) { }



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



		/// <summary>The angle between this Vector and another Vector.</summary>
		/// <returns>Radians</returns>
		public System.Single AngleBetween(Vector other)
		{
			if (other == null) { throw new Eggceptions.ArgumentNullException("other"); }

			return Library.Vector.AngleBetween(Elements, other.Elements);
		}

		/// <summary>If the cross product of this Vector and other Vector's can be calculated. Valid only in 3D and 7D.</summary>
		public System.Boolean CanCrossProduct(params Vector[] others)
		{
			if (others.IsNullOrSparse(1)) { throw new Eggceptions.ArgumentNullOrSparseException("others"); }

			var elements = others.Convert(other => other.Elements).Unshift(Elements);

			return Library.Vector.CanCrossProduct(elements);
		}

		/// <summary>If the dot product of this Vector and another Vector can be calculated.</summary>
		public System.Boolean CanDotProduct(Vector other)
		{
			if (other == null) { throw new Eggceptions.ArgumentNullException("other"); }

			return Library.Vector.CanDotProduct(Elements, other.Elements);
		}

		/// <summary>The cross product of this Vector and other Vector's.</summary>
		/// <returns>Vector</returns>
		public Managed.Matrix CrossProduct(params Vector[] others)
		{
			if (others.IsNullOrSparse(1)) { throw new Eggceptions.ArgumentNullOrSparseException("others"); }

			var elements = others.Convert(other => other.Elements).Unshift(Elements);

			return new Managed.Matrix(Library.Vector.CrossProduct(elements));
		}

		/// <summary>The distance between this Vector and another Vector.</summary>
		public System.Single DistanceBetween(Vector other)
		{
			if (other == null) { throw new Eggceptions.ArgumentNullException("other"); }

			return Library.Vector.DistanceBetween(Elements, other.Elements);
		}

		/// <summary>The dot product of this Vector and another Vector.</summary>
		public System.Single DotProduct(Vector other)
		{
			if (other == null) { throw new Eggceptions.ArgumentNullException("other"); }

			return Library.Vector.DotProduct(Elements, other.Elements);
		}

		/// <summary>The normalization of this Vector.</summary>
		/// <returns>Vector</returns>
		public Managed.Matrix Normalize()
		{
			return new Managed.Matrix(Library.Vector.Normalize(Elements));
		}
	}
}
