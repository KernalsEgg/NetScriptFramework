namespace Eggstensions.Bethesda
{
	/// <summary>NetScriptFramework.SkyrimSE.StringRefHolder</summary>
	public class BSFixedString : TemporaryObject
	{
		private NetScriptFramework.MemoryAllocation _allocation;



		public System.IntPtr Address
		{
			get
			{
				return _allocation.Address;
			}
		}



		public BSFixedString(System.String text)
		{
			if (System.String.IsNullOrWhiteSpace(text)) { throw new Eggceptions.ArgumentNullOrWhiteSpaceException("text"); }

			_allocation = BSFixedString.Initialize(text);
			_allocation.Pin();
		}

		override protected void Free()
		{
			BSFixedString.Release(Address);
			_allocation.Unpin();
			_allocation.Dispose();
		}



		/// <summary>&lt;SkyrimSE.exe&gt; + 0xC28BF0 (VID67819)</summary>
		static public NetScriptFramework.MemoryAllocation Initialize(System.String text)
		{
			if (System.String.IsNullOrWhiteSpace(text)) { throw new Eggceptions.ArgumentNullOrWhiteSpaceException("text"); }

			var bytes = System.Text.Encoding.UTF8.GetBytes(text);
			var padding = 0x8 - (bytes.Length % 0x8);

			var functionAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(67819);
			if (functionAddress == System.IntPtr.Zero) { throw new Eggceptions.NullException("functionAddress"); }

			var allocation = NetScriptFramework.Memory.Allocate(0x10 + bytes.Length + padding);
			allocation.Zero();
			NetScriptFramework.Memory.WriteBytes(allocation.Address + 0x10, bytes);

			NetScriptFramework.Memory.InvokeCdecl(functionAddress, allocation.Address, allocation.Address + 0x10);

			return allocation;
		}

		/// <summary>&lt;SkyrimSE.exe&gt; + 0xC28D40 (VID67822)</summary>
		/// <param name = "bsFixedString">BSFixedString</param>
		static public void Release(System.IntPtr bsFixedString)
		{
			if (bsFixedString == null) { throw new Eggceptions.ArgumentNullException("bsFixedString"); }

			var functionAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(67822);
			if (functionAddress == System.IntPtr.Zero) { throw new Eggceptions.NullException("functionAddress"); }

			NetScriptFramework.Memory.InvokeCdecl(functionAddress, bsFixedString);
		}

		/// <param name = "bsFixedString">BSFixedString</param>
		static public System.String Text(System.IntPtr bsFixedString)
		{
			if (bsFixedString == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("bsFixedString"); }

			return NetScriptFramework.Memory.ReadString(NetScriptFramework.Memory.ReadPointer(bsFixedString), false);
		}
	}
}
