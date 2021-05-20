using Eggstensions.Interoperability.Managed; // Memory



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
				return Memory.ReadIntPtr(this, 0x28);
			}
		}

		public bhkWorld HavokWorld
		{
			get
			{
				return Memory.ReadIntPtr(this, 0x30);
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
