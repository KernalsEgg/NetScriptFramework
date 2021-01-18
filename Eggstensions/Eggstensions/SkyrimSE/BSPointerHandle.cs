namespace Eggstensions.SkyrimSE
{
	static public class BSPointerHandle
	{
		public class ExistingReferenceFromHandle : TemporaryObject
		{
			/// <param name="reference">TESObjectREFR</param>
			public ExistingReferenceFromHandle(System.IntPtr reference)
			{
				Reference = reference;
			}

			override protected void Free()
			{
				if (Reference != System.IntPtr.Zero)
				{
					NiRefObject.DecrementReferenceCount(TESObjectREFR.GetHandleRefObject(Reference));
				}
			}



			/// <summary>TESObjectREFR, System.IntPtr.Zero</summary>
			public System.IntPtr Reference { get; }
		}

		public class HandleFromReference
		{
			/// <param name="reference">TESObjectREFR</param>
			public HandleFromReference(System.IntPtr reference)
			{
				Reference = reference;

				if (Reference != System.IntPtr.Zero)
				{
					Handle = BSPointerHandle.GetHandleFromReference(Reference);
				}
			}



			/// <summary>TESObjectREFR, System.IntPtr.Zero</summary>
			public System.IntPtr Reference { get; }

			/// <summary>BSPointerHandle</summary>
			public System.UInt32 Handle { get; }
		}

		public class ReferenceFromHandle : TemporaryObject
		{
			public ReferenceFromHandle(System.IntPtr pointerHandle)
			{
				if (pointerHandle != System.IntPtr.Zero)
				{
					Reference = BSPointerHandle.GetReferenceFromHandle(pointerHandle);
				}
			}

			override protected void Free()
			{
				if (Reference != System.IntPtr.Zero)
				{
					NiRefObject.DecrementReferenceCount(TESObjectREFR.GetHandleRefObject(Reference));
				}
			}



			/// <summary>TESObjectREFR, System.IntPtr.Zero</summary>
			public System.IntPtr Reference { get; }
		}



		static public System.IntPtr List
		{
			get
			{
				return VIDS.BSPointerHandle.List;
			}
		}

		/// <returns>BSPointerHandle</returns>
		static public System.IntPtr Null
		{
			get
			{
				return VIDS.BSPointerHandle.Null;
			}
		}



		/// <param name = "reference">TESObjectREFR</param>
		/// <returns>BSPointerHandle</returns>
		static public System.UInt32 CreateHandleFromReference(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			using (var pointerHandleAllocation = NetScriptFramework.Memory.Allocate(0x8))
			{
				pointerHandleAllocation.Zero();
				NetScriptFramework.Memory.InvokeCdecl(VIDS.BSPointerHandle.CreateHandleFromReference, pointerHandleAllocation.Address, reference);

				return NetScriptFramework.Memory.ReadUInt32(pointerHandleAllocation.Address);
			}
		}

		/// <param name = "reference">TESObjectREFR</param>
		/// <returns>BSPointerHandle</returns>
		static public System.UInt32 GetHandleFromReference(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(reference)); }

			using (var pointerHandleAllocation = NetScriptFramework.Memory.Allocate(0x8))
			{
				pointerHandleAllocation.Zero();
				NetScriptFramework.Memory.InvokeCdecl(VIDS.BSPointerHandle.GetHandleFromReference, reference, pointerHandleAllocation.Address);

				return NetScriptFramework.Memory.ReadUInt32(pointerHandleAllocation.Address);
			}
		}

		/// <param name = "pointerHandle">BSPointerHandle</param>
		/// <returns>TESObjectREFR, System.IntPtr.Zero</returns>
		static public System.IntPtr GetReferenceFromHandle(System.IntPtr pointerHandle)
		{
			if (pointerHandle == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException(nameof(pointerHandle)); }

			using (var referenceAllocation = NetScriptFramework.Memory.Allocate(0x8))
			{
				referenceAllocation.Zero();

				NetScriptFramework.Memory.InvokeCdecl(VIDS.BSPointerHandle.GetReferenceFromHandle, pointerHandle, referenceAllocation.Address);

				return NetScriptFramework.Memory.ReadPointer(referenceAllocation.Address);
			}
		}

		/// <param name = "pointerHandle">BSPointerHandle</param>
		/// <returns>TESObjectREFR, System.IntPtr.Zero</returns>
		static public System.IntPtr GetReferenceFromHandle(System.UInt32 pointerHandle)
		{
			// pointerHandle

			var reference = System.IntPtr.Zero;

			if (pointerHandle != 0)
			{
				var entry = BSPointerHandle.List + (System.Int32)((pointerHandle & 0xFFFFF) << 0x4);
				var handleRefObject = NetScriptFramework.Memory.ReadPointer(entry + 0x8);

				if (handleRefObject != System.IntPtr.Zero)
				{
					NiRefObject.IncrementReferenceCount(handleRefObject);
					reference = BSHandleRefObject.GetReferenceFromHandleRefObject(handleRefObject);

					var id = NetScriptFramework.Memory.ReadUInt32(entry);

					if
					(
						((id & (1 << 0x1A)) == 0)
						|| ((id & 0x3F00000) != (pointerHandle & 0x3F00000))
						|| ((NiRefObject.GetReferenceCount(handleRefObject) >> 0xB) != (pointerHandle & 0xFFFFF))
					)
					{
						reference = System.IntPtr.Zero;
						NiRefObject.DecrementReferenceCount(handleRefObject);
					}

				}
			}

			return reference;
		}

		/// <summary>SkyrimSE.exe + 0x62F1C0 (VID 37763)</summary>
		/// <param name = "pointerHandle">BSPointerHandle</param>
		static public System.Boolean IsHandleValid(System.UInt32 pointerHandle)
		{
			// pointerHandle

			var entry = BSPointerHandle.List + (System.Int32)((pointerHandle & 0xFFFFF) << 0x4);
			var id = NetScriptFramework.Memory.ReadUInt32(entry);

			if
			(
				((id & (1 << 0x1A)) != 0)
				&& ((id & 0x3F00000) == (pointerHandle & 0x3F00000))
			)
			{
				var handleRefObject = NetScriptFramework.Memory.ReadPointer(entry + 0x8);

				if (handleRefObject != System.IntPtr.Zero)
				{
					var referenceCount = NiRefObject.GetReferenceCount(handleRefObject);

					if ((referenceCount >> 0xB) == (pointerHandle & 0xFFFFF))
					{
						return true;
					}
				}
			}

			return false;
		}
	}
}
