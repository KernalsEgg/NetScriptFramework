namespace Eggstensions.SkyrimSE
{
	/// <summary>NetScriptFramework.SkyrimSE.StringRefHolder</summary>
	public class BSFixedString : TemporaryObject
	{
		public BSFixedString(System.String text)
		{
			if (System.String.IsNullOrWhiteSpace(text)) { throw new Eggceptions.ArgumentNullOrWhiteSpaceException(nameof(text)); }

			_allocation = BSFixedString.Initialize(text);
			_allocation.Pin();
		}

		override protected void Free()
		{
			BSFixedString.Release(Address);
			_allocation.Unpin();
			_allocation.Dispose();
		}



		private NetScriptFramework.MemoryAllocation _allocation;



		public System.IntPtr Address
		{
			get
			{
				return _allocation.Address;
			}
		}



		static public NetScriptFramework.MemoryAllocation Initialize(System.String text)
		{
			if (System.String.IsNullOrWhiteSpace(text)) { throw new Eggceptions.ArgumentNullOrWhiteSpaceException(nameof(text)); }

			var bytes = System.Text.Encoding.UTF8.GetBytes(text);
			var padding = 0x8 - (bytes.Length % 0x8);

			var allocation = NetScriptFramework.Memory.Allocate(0x10 + bytes.Length + padding);
			allocation.Zero();
			NetScriptFramework.Memory.WriteBytes(allocation.Address + 0x10, bytes);
			NetScriptFramework.Memory.InvokeCdecl(VIDS.BSFixedString.Initialize, allocation.Address, allocation.Address + 0x10);

			return allocation;
		}

		/// <param name = "bsFixedString">BSFixedString</param>
		static public void Release(System.IntPtr bsFixedString)
		{
			if (bsFixedString == null) { throw new Eggceptions.ArgumentNullException(nameof(bsFixedString)); }

			NetScriptFramework.Memory.InvokeCdecl(VIDS.BSFixedString.Release, bsFixedString);
		}

		/// <param name = "bsFixedString">BSFixedString</param>
		static public System.String Text(System.IntPtr bsFixedString)
		{
			if (bsFixedString == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(bsFixedString)); }

			return NetScriptFramework.Memory.ReadString(NetScriptFramework.Memory.ReadPointer(bsFixedString), false);
		}
	}
}
