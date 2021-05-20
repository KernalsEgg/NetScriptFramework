namespace Eggstensions
{
	public class NiObject : VirtualObject
	{
		public NiObject(System.IntPtr address) : base(address)
		{
		}



		public NiNode AsNode()
		{
			var asNode = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.NiObject.AsNode>(this[0x3]);

			return asNode(this);
		}
	}
}
