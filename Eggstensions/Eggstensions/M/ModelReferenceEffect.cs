namespace Eggstensions
{
	public class ModelReferenceEffect : ReferenceEffect
	{
		public ModelReferenceEffect(System.IntPtr address) : base(address)
		{
		}



		public RefAttachTechniqueInput HitEffectArtData
		{
			get
			{
				return this + 0x68;
			}
		}



		static public implicit operator ModelReferenceEffect(System.IntPtr address)
		{
			return new ModelReferenceEffect(address);
		}
	}
}
