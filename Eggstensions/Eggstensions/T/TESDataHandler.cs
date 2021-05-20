namespace Eggstensions
{
	public class TESDataHandler
	{
		/// <param name="formID">FormID</param>
		static public TESForm GetForm(System.UInt32 formID)
		{
			return Delegates.Instances.TESDataHandler.GetForm(formID);
		}
	}
}
