namespace Eggstensions
{
	public class TESRace : TESForm
	{
		public TESRace(System.IntPtr address) : base(address)
		{
		}



		static public implicit operator TESRace(System.IntPtr address)
		{
			return new TESRace(address);
		}
	}
}
