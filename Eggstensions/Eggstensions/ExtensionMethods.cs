namespace Eggstensions
{
	namespace ExtensionMethods
	{
		static public class IntPtr
		{
			static public System.Boolean ToBoolean(this System.IntPtr value)
			{
				return value.ToByte() != 0;
			}

			static public System.Byte ToByte(this System.IntPtr value)
			{
				return (System.Byte)(0xFF & value.ToUInt64());
			}

			static public System.Double ToDouble(this System.IntPtr value)
			{
				var bytes = System.BitConverter.GetBytes(value.ToUInt64());

				return System.BitConverter.ToDouble(bytes, 0);
			}

			static public System.Int16 ToInt16(this System.IntPtr value)
			{
				return unchecked((System.Int16)value.ToUInt16());
			}

			static public System.Int32 ToInt32Safe(this System.IntPtr value)
			{
				return unchecked((System.Int32)value.ToUInt32());
			}

			static public System.SByte ToSByte(this System.IntPtr value)
			{
				return unchecked((System.SByte)value.ToByte());
			}

			static public System.Single ToSingle(this System.IntPtr value)
			{
				var bytes = System.BitConverter.GetBytes(value.ToUInt32());

				return System.BitConverter.ToSingle(bytes, 0);
			}

			static public System.UInt16 ToUInt16(this System.IntPtr value)
			{
				return (System.UInt16)(0xFFFF & value.ToUInt64());
			}

			static public System.UInt32 ToUInt32(this System.IntPtr value)
			{
				return (System.UInt32)(0xFFFFFFFF & value.ToUInt64());
			}

			static public System.UInt64 ToUInt64(this System.IntPtr value)
			{
				return unchecked((System.UInt64)value.ToInt64());
			}
		}
	}
}
