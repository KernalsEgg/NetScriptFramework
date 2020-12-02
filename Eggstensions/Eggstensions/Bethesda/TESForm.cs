namespace Eggstensions.Bethesda
{
	public enum FormTypes : System.Byte
	{
		TESRace =		0xE,
		TESObjectARMO =	0x1A,
		TESObjectTREE =	0x26,
		TESFlora =		0x27,
		TESNPC =		0x2B,
		Character =		0x3E,
		TESObjectARMA =	0x66
	}



	static public class TESForm
	{
		/// <param name="form">TESForm</param>
		static public void AddFormFlags(System.IntPtr form, System.UInt32 formFlags)
		{
			if (form == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("form"); }
			// formFlags

			TESForm.SetFormFlags(form, formFlags | TESForm.GetFormFlags(form));
		}

		/// <param name = "form">TESForm</param>
		static public System.String GetEditorID(System.IntPtr form)
		{
			if (form == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("form"); }

			return NetScriptFramework.Memory.ReadString(VirtualObject.InvokeVTableThisCall(form, 0x190), false);
		}

		/// <returns>TESForm, System.IntPtr.Zero</returns>
		static public System.IntPtr GetForm(System.UInt32 globalFormID)
		{
			// globalFormID

			return NetScriptFramework.Memory.InvokeCdecl(VIDS.TESForm.GetForm, globalFormID);
		}
		
		/// <param name = "form">TESForm</param>
		static public System.UInt32 GetFormFlags(System.IntPtr form)
		{
			if (form == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("form"); }

			return NetScriptFramework.Memory.ReadUInt32(form + 0x10);
		}

		/// <summary>&lt;SkyrimSE.exe&gt; + 0x972E10 (VID54832)</summary>
		/// <returns>TESForm, System.IntPtr.Zero</returns>
		static public System.IntPtr GetFormFromFile(System.UInt32 localFormID, System.String fileName)
		{
			// localFormID
			if (System.String.IsNullOrWhiteSpace(fileName)) { throw new Eggceptions.ArgumentNullOrWhiteSpaceException("fileName"); }

			var file = TESDataHandler.GetFile(TESDataHandler.Instance, fileName);

			if (file != System.IntPtr.Zero)
			{
				if (TESFile.IsLoaded(file))
				{
					var globalFormID = TESFile.GetGlobalFormID(file, localFormID);

					return TESForm.GetForm(globalFormID);
				}
			}

			return System.IntPtr.Zero;
		}

		/// <param name = "form">TESForm</param>
		static public System.UInt32 GetFormID(System.IntPtr form)
		{
			if (form == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("form"); }

			return NetScriptFramework.Memory.ReadUInt32(form + 0x14);
		}

		/// <param name = "form">TESForm</param>
		static public FormTypes GetFormType(System.IntPtr form)
		{
			if (form == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("form"); }

			return (FormTypes)NetScriptFramework.Memory.ReadUInt8(form + 0x1A);
		}

		/// <param name = "form">TESForm</param>
		static public System.UInt32 GetInGameFormFlags(System.IntPtr form)
		{
			if (form == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("form"); }

			return NetScriptFramework.Memory.ReadUInt16(form + 0x18);
		}
		
		/// <param name = "form">TESForm</param>
		static public System.String GetName(System.IntPtr form)
		{
			if (form == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("form"); }

			using (var allocation = NetScriptFramework.Memory.Allocate(0x10))
			{
				allocation.Zero();

				var name = VirtualObject.InvokeVTableThisCall(form, 0x170, allocation.Address);
				if (name == System.IntPtr.Zero) { throw new Eggceptions.NullException("name"); }

				return NetScriptFramework.Memory.ReadString(name, false);
			}
		}

		/// <param name = "form">TESForm</param>
		static public System.Boolean HasFormFlags(System.IntPtr form, System.UInt32 formFlags)
		{
			if (form == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("form"); }
			// formFlags

			return (TESForm.GetFormFlags(form) & formFlags) == formFlags;
		}

		/// <param name = "form">TESForm</param>
		static public System.Boolean HasFormType(System.IntPtr form, params FormTypes[] formTypes)
		{
			if (form == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("form"); }
			if (formTypes == null) { throw new Eggceptions.ArgumentNullException("formTypes"); }

			var formType = TESForm.GetFormType(form);

			for (var i = 0; i < formTypes.Length; i++)
			{
				if (formTypes[i] == formType)
				{
					return true;
				}
			}

			return false;
		}

		/// <param name="form">TESForm</param>
		static public void RemoveFormFlags(System.IntPtr form, System.UInt32 formFlags)
		{
			if (form == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("form"); }
			// formFlags

			TESForm.SetFormFlags(form, formFlags & ~TESForm.GetFormFlags(form));
		}

		/// <param name="form">TESForm</param>
		static public void SetFormFlags(System.IntPtr form, System.UInt32 formFlags)
		{
			if (form == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("form"); }
			// formFlags

			NetScriptFramework.Memory.WriteUInt32(form + 0x10, formFlags);
		}
	}
}
