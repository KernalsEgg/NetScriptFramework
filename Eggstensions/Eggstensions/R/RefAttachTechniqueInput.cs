namespace Eggstensions
{
	public class RefAttachTechniqueInput : BSAttachTechniques.AttachTechniqueInput
	{
		public RefAttachTechniqueInput(System.IntPtr address) : base(address)
		{
		}



		public TESRace Race
		{
			get
			{
				return Memory.Read<System.IntPtr>(this, 0x28);
			}
		}

		public bhkWorld HavokWorld
		{
			get
			{
				return Memory.Read<System.IntPtr>(this, 0x30);
			}
		}

		public BSFixedString NodeName
		{
			get
			{
				return this + 0x40;
			}
		}



		static public implicit operator RefAttachTechniqueInput(System.IntPtr address)
		{
			return new RefAttachTechniqueInput(address);
		}
	}
}
