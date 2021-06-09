namespace Eggstensions
{
	namespace BSAttachTechniques
	{
		public class AttachTechniqueInput : VirtualObject
		{
			public AttachTechniqueInput(System.IntPtr address) : base(address)
			{
			}



			public NiNode AttachRoot
			{
				get
				{
					return Memory.Read<System.IntPtr>(this, 0x8);
				}
			}

			public NiNode EffectRoot
			{
				get
				{
					return Memory.Read<System.IntPtr>(this, 0x10);
				}
			}
		}
	}
}
