﻿using static NetScriptFramework._IntPtrExtensions;



namespace Eggstensions.Bethesda
{
	public enum FormTypes : System.Byte
	{
		TESRace =			0xE,
		TESObjectARMO =		0x1A,
		TESObjectTREE =		0x26,
		TESFlora =			0x27,
		TESNPC =			0x2B,
		TESObjectREFR =		0x3D,
		Character =			0x3E,
		TESObjectARMA =		0x66,
		BGSCollisionLayer =	0x84
	}



	static public class TESForm
	{
		/// <param name="form">TESForm</param>
		/// <param name="target">TESObjectREFR</param>
		/// <param name="activator">TESObjectREFR</param>
		static public System.Boolean Activate(System.IntPtr form, System.IntPtr target, System.IntPtr activator)
		{
			if (form == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("form"); }
			if (target == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("target"); }
			if (activator == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("activator"); }

			return VirtualObject.InvokeVTableThisCall(form, 0x1B8, target, activator).ToBool();
		}

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

			using (var bsFixedStringAllocation = NetScriptFramework.Memory.Allocate(0x10))
			{
				bsFixedStringAllocation.Zero();

				var name = VirtualObject.InvokeVTableThisCall(form, 0x170, bsFixedStringAllocation.Address);
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
		static public System.Boolean IsArmorAddon(System.IntPtr form)
		{
			if (form == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("form"); }

			return TESForm.GetFormType(form) == FormTypes.TESObjectARMA;
		}

		/// <param name = "form">TESForm</param>
		static public System.Boolean IsRace(System.IntPtr form)
		{
			if (form == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("form"); }

			return TESForm.GetFormType(form) == FormTypes.TESRace;
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
