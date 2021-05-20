namespace Eggstensions
{
	public class NativeObject
	{
		public NativeObject(System.IntPtr address)
		{
			Address = address;
		}



		public System.IntPtr Address { get; }



		public override System.Boolean Equals(System.Object other)
		{
			return (other is NativeObject) ? Address == ((NativeObject)other).Address : false;
		}

		public override System.Int32 GetHashCode()
		{
			return Address.GetHashCode();
		}



		static public System.Boolean operator !=(NativeObject left, NativeObject right)
		{
			return left.Address != right.Address;
		}

		static public System.Boolean operator ==(NativeObject left, NativeObject right)
		{
			return left.Address == right.Address;
		}

		static public System.IntPtr operator +(NativeObject left, System.Int32 right)
		{
			return left.Address + right;
		}



		static public implicit operator System.Boolean(NativeObject nativeObject)
		{
			return nativeObject.Address != System.IntPtr.Zero;
		}

		static public implicit operator System.IntPtr(NativeObject nativeObject)
		{
			return nativeObject.Address;
		}

		static public implicit operator NativeObject(System.IntPtr address)
		{
			return new NativeObject(address);
		}
	}
}
