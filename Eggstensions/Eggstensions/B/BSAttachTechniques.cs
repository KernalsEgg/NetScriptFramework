using Eggstensions.Interoperability.Managed; // Memory



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
					return Memory.ReadIntPtr(this, 0x8);
				}
			}

			public NiNode EffectRoot
			{
				get
				{
					return Memory.ReadIntPtr(this, 0x10);
				}
			}
		}
	}
}
