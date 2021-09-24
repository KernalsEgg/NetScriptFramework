using Eggstensions.ExtensionMethods;



namespace Eggstensions
{
	[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit, Size = 0x58)]
	unsafe public struct BSTEventSource
	{
		// Member
		public void AddEventSink(System.IntPtr eventSink)
		{
			var addEventSink = (delegate* unmanaged[Cdecl]<BSTEventSource*, System.IntPtr, void>)Eggstensions.Offsets.BSTEventSource.AddEventSink;

			AddEventSink(this.AsPointer(), eventSink);



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			void AddEventSink(BSTEventSource* eventSource, System.IntPtr eventSink)
			{
				addEventSink(eventSource, eventSink);
			}
		}

		public void RemoveEventSink(System.IntPtr eventSink)
		{
			var removeEventSink = (delegate* unmanaged[Cdecl]<Eggstensions.BSTEventSource*, System.IntPtr, void>)Eggstensions.Offsets.BSTEventSource.RemoveEventSink;

			RemoveEventSink(this.AsPointer(), eventSink);



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			void RemoveEventSink(BSTEventSource* eventSource, System.IntPtr eventSink)
			{
				removeEventSink(eventSource, eventSink);
			}
		}
	}
}
