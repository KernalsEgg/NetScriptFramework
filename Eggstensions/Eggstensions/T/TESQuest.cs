namespace Eggstensions
{
	public class TESQuest : TESForm
	{
		public TESQuest(System.IntPtr address) : base(address)
		{
		}



		static public explicit operator TESFullName(TESQuest quest)
		{
			return new TESFullName(quest, 0x28);
		}



		static public implicit operator TESQuest(System.IntPtr address)
		{
			return new TESQuest(address);
		}
	}
}
