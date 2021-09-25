namespace Eggstensions
{
	public interface IBSHandleRefObject : INiRefObject
	{
	}
	
	public struct BSHandleRefObject : IBSHandleRefObject
	{
	}



	namespace ExtensionMethods
	{
		unsafe static public class IBSHandleRefObject
		{
			// Member
			static public void DecrementReferenceCount<TBSHandleRefObject>(this ref TBSHandleRefObject handleReferenceObject)
				where TBSHandleRefObject : unmanaged, Eggstensions.IBSHandleRefObject
			{
				if (System.Threading.Interlocked.Decrement(ref *handleReferenceObject.ReferenceCount()) == 0)
				{
					handleReferenceObject.Delete();
				}
			}

			static public void IncrementReferenceCount<TBSHandleRefObject>(this ref TBSHandleRefObject handleReferenceObject)
				where TBSHandleRefObject : unmanaged, Eggstensions.IBSHandleRefObject
			{
				System.Threading.Interlocked.Increment(ref *handleReferenceObject.ReferenceCount());
			}
		}
	}
}
