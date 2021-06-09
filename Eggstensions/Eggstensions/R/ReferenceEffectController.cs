namespace Eggstensions
{
	public class ReferenceEffectController : VirtualObject
	{
		public ReferenceEffectController(System.IntPtr address) : base(address)
		{
		}



		virtual public NiAVObject GetAttachRoot()
		{
			var getAttachRoot = System.Runtime.InteropServices.Marshal.GetDelegateForFunctionPointer<Delegates.Types.ReferenceEffectController.GetAttachRoot>(this[0xF]);

			return getAttachRoot(this);
		}



		static public implicit operator ReferenceEffectController(System.IntPtr address)
		{
			return new ReferenceEffectController(address);
		}
	}
}
