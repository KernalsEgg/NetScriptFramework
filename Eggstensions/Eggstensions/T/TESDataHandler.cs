namespace Eggstensions
{
	public class TESDataHandler
	{
		/// <param name="formID">FormID</param>
		/// <returns>TESForm</returns>
		static public TESForm GetForm(System.UInt32 formID)
		{
			return Delegates.Instances.TESDataHandler.GetForm(formID);
		}
	}
}
