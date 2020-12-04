namespace Eggstensions.Bethesda
{
	static public class VIDS
	{
		static public class Actor
		{
			static Actor()
			{
				_update3DModel = NetScriptFramework.Main.GameInfo.GetAddressOf(38404);
			}



			readonly static private System.IntPtr _update3DModel;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x650DF0 (VID38404)</summary>
			static public System.IntPtr Update3DModel { get { return _update3DModel; } }
		}

		static public class BSFixedString
		{
			static BSFixedString()
			{
				_initialize =	NetScriptFramework.Main.GameInfo.GetAddressOf(67819);
				_release =		NetScriptFramework.Main.GameInfo.GetAddressOf(67822);
			}



			readonly static private System.IntPtr _initialize;

			readonly static private System.IntPtr _release;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0xC28BF0 (VID67819)</summary>
			static public System.IntPtr Initialize	{ get { return _initialize; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0xC28D40 (VID67822)</summary>
			static public System.IntPtr Release		{ get { return _release; } }
		}

		static public class BSSpinLock
		{
			static BSSpinLock()
			{
				_lock = NetScriptFramework.Main.GameInfo.GetAddressOf(12210);
			}



			readonly static private System.IntPtr _lock;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x132BD0 (VID12210)</summary>
			static public System.IntPtr Lock { get { return _lock; } }
		}

		static public class Character
		{
			static Character()
			{
				_hasLineOfSight = NetScriptFramework.Main.GameInfo.GetAddressOf(36745);
			}



			readonly static private System.IntPtr _hasLineOfSight;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x5FC880 (VID36745)</summary>
			static public System.IntPtr HasLineOfSight { get { return _hasLineOfSight; } }
		}

		static public class ConsoleLog
		{
			static ConsoleLog()
			{
				_instance =	NetScriptFramework.Main.GameInfo.GetAddressOf(515064);
				_print =	NetScriptFramework.Main.GameInfo.GetAddressOf(50179);
			}



			readonly static private System.IntPtr _instance;

			readonly static private System.IntPtr _print;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x2F000F0 (VID515064)</summary>
			static public System.IntPtr Instance	{ get { return _instance; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x85C290 (VID50179)</summary>
			static public System.IntPtr Print		{ get { return _print; } }
		}

		static public class Events
		{
			static Events()
			{
				_activateFlora =				NetScriptFramework.Main.GameInfo.GetAddressOf(16986);
				_activateTree =					NetScriptFramework.Main.GameInfo.GetAddressOf(17636);
				_attachPrecipitationObject =	NetScriptFramework.Main.GameInfo.GetAddressOf(25640);
				_detachPrecipitationObject1 =	NetScriptFramework.Main.GameInfo.GetAddressOf(25638);
				_detachPrecipitationObject2 =	NetScriptFramework.Main.GameInfo.GetAddressOf(25639);
				_getIsCreatureType =			NetScriptFramework.Main.GameInfo.GetAddressOf(21029);
			}



			readonly static private System.IntPtr _activateFlora;

			readonly static private System.IntPtr _activateTree;

			readonly static private System.IntPtr _attachPrecipitationObject;

			readonly static private System.IntPtr _detachPrecipitationObject1;

			readonly static private System.IntPtr _detachPrecipitationObject2;

			readonly static private System.IntPtr _getIsCreatureType;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x218CE0 (VID16986)</summary>
			static public System.IntPtr ActivateFlora		{ get { return _activateFlora; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x231580 (VID17636)</summary>
			static public System.IntPtr ActivateTree		{ get { return _activateTree; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x3AF100 (VID25640)</summary>
			static public System.IntPtr AttachPrecipitationObject { get { return _attachPrecipitationObject; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x3AEBD0 (VID25638)</summary>
			static public System.IntPtr DetachPrecipitationObject1 { get { return _detachPrecipitationObject1; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x3AF050 (VID25639)</summary>
			static public System.IntPtr DetachPrecipitationObject2 { get { return _detachPrecipitationObject2; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x2D7750 (VID21029)</summary>
			static public System.IntPtr GetIsCreatureType	{ get { return _getIsCreatureType; } }
		}

		static public class Havok
		{
			static Havok()
			{
				_getNiObjectFromHavokObject = NetScriptFramework.Main.GameInfo.GetAddressOf(76160);
			}



			readonly static private System.IntPtr _getNiObjectFromHavokObject;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0xDAD060 (VID76160)</summary>
			static public System.IntPtr GetNiObjectFromHavokObject { get { return _getNiObjectFromHavokObject; } }
		}

		static public class hkpAllRayHitTempCollector
		{
			static hkpAllRayHitTempCollector()
			{
				_constructor =	NetScriptFramework.Main.GameInfo.GetAddressOf(15062);
				_destructor =	NetScriptFramework.Main.GameInfo.GetAddressOf(15073);
			}



			readonly static private System.IntPtr _constructor;

			readonly static private System.IntPtr _destructor;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1AFE40 (VID15062)</summary>
			static public System.IntPtr Constructor	{ get { return _constructor; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1B02A0 (VID15073)</summary>
			static public System.IntPtr Destructor	{ get { return _destructor; } }
		}

		static public class Main
		{
			static Main()
			{
				_instance =			NetScriptFramework.Main.GameInfo.GetAddressOf(516943);
				_isInMenuMode =		NetScriptFramework.Main.GameInfo.GetAddressOf(56476);
				_isInMenuModeBase =	NetScriptFramework.Main.GameInfo.GetAddressOf(516933);
			}



			readonly static private System.IntPtr _instance;

			readonly static private System.IntPtr _isInMenuMode;

			readonly static private System.IntPtr _isInMenuModeBase;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x2F26BF8 (VID516943)</summary>
			static public System.IntPtr Instance			{ get { return _instance; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x9B8750 (VID56476)</summary>
			static public System.IntPtr IsInMenuMode		{ get { return _isInMenuMode; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x2F26B74 (VID516933)</summary>
			static public System.IntPtr IsInMenuModeBase	{ get { return _isInMenuModeBase; } }
		}

		static public class NiAVObject
		{
			static NiAVObject()
			{
				_getBoneNodeByName = NetScriptFramework.Main.GameInfo.GetAddressOf(74481);
			}



			readonly static private System.IntPtr _getBoneNodeByName;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0xD41970 (VID74481)</summary>
			static public System.IntPtr GetBoneNodeByName { get { return _getBoneNodeByName; } }
		}

		static public class NiBoneNames
		{
			static NiBoneNames()
			{
				_instance = NetScriptFramework.Main.GameInfo.GetAddressOf(11308);
			}



			readonly static private System.IntPtr _instance;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x104AD0 (VID11308)</summary>
			static public System.IntPtr Instance { get { return _instance; } }
		}

		static public class PlayerCharacter
		{
			static PlayerCharacter()
			{
				_instance =			NetScriptFramework.Main.GameInfo.GetAddressOf(517014);
				_hasLineOfSight =	NetScriptFramework.Main.GameInfo.GetAddressOf(39444);
			}



			readonly static private System.IntPtr _instance;

			readonly static private System.IntPtr _hasLineOfSight;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x2F26EF8 (VID517014)</summary>
			static public System.IntPtr Instance		{ get { return _instance; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x6A4A00 (VID39444)</summary>
			static public System.IntPtr HasLineOfSight	{ get { return _hasLineOfSight; } }
		}

		static public class ProcessLists
		{
			static ProcessLists()
			{
				_instance = NetScriptFramework.Main.GameInfo.GetAddressOf(514167);
			}



			readonly static private System.IntPtr _instance;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1EBEAD0 (VID514167)</summary>
			static public System.IntPtr Instance { get { return _instance; } }
		}

		static public class Sky
		{
			static Sky()
			{
				_instance = NetScriptFramework.Main.GameInfo.GetAddressOf(13789);
			}



			readonly static private System.IntPtr _instance;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x177790 (VID13789)</summary>
			static public System.IntPtr Instance { get { return _instance; } }
		}

		static public class TES
		{
			static TES()
			{
				_gridsToLoad =	NetScriptFramework.Main.GameInfo.GetAddressOf(501244);
				_instance =		NetScriptFramework.Main.GameInfo.GetAddressOf(516923);
			}



			readonly static private System.IntPtr _gridsToLoad;

			readonly static private System.IntPtr _instance;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1DB3E28 (VID501244)</summary>
			static public System.IntPtr GridsToLoad	{ get { return _gridsToLoad; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x2F26B20 (VID516923)</summary>
			static public System.IntPtr Instance	{ get { return _instance; } }
		}

		static public class TESDataHandler
		{
			static TESDataHandler()
			{
				_instance =	NetScriptFramework.Main.GameInfo.GetAddressOf(514141);
				_getFile =	NetScriptFramework.Main.GameInfo.GetAddressOf(13632);
			}



			readonly static private System.IntPtr _instance;

			readonly static private System.IntPtr _getFile;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1EBE428 (VID514141)</summary>
			static public System.IntPtr Instance	{ get { return _instance; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x16D1B0 (VID13632)</summary>
			static public System.IntPtr GetFile		{ get { return _getFile; } }
		}

		static public class TESFile
		{
			static TESFile()
			{
				_getGlobalFormID =	NetScriptFramework.Main.GameInfo.GetAddressOf(13915);
				_isLoaded =			NetScriptFramework.Main.GameInfo.GetAddressOf(13882);
			}



			readonly static private System.IntPtr _getGlobalFormID;

			readonly static private System.IntPtr _isLoaded;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x17E180 (VID13915)</summary>
			static public System.IntPtr GetGlobalFormID	{ get { return _getGlobalFormID; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x17C670 (VID13882)</summary>
			static public System.IntPtr IsLoaded		{ get { return _isLoaded; } }
		}

		static public class TESForm
		{
			static TESForm()
			{
				_getForm = NetScriptFramework.Main.GameInfo.GetAddressOf(14461);
			}



			readonly static private System.IntPtr _getForm;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x194230 (VID14461)</summary>
			static public System.IntPtr GetForm { get { return _getForm; } }
		}

		static public class TESObjectCELL
		{
			static TESObjectCELL()
			{
				_getHavokWorld = NetScriptFramework.Main.GameInfo.GetAddressOf(18536);
			}



			readonly static private System.IntPtr _getHavokWorld;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x2654C0 (VID18536)</summary>
			static public System.IntPtr GetHavokWorld { get { return _getHavokWorld; } }
		}

		static public class TESObjectREFR
		{
			static TESObjectREFR()
			{
				_getHandleFromReference =	NetScriptFramework.Main.GameInfo.GetAddressOf(12192);
				_getReferenceFromHandle =	NetScriptFramework.Main.GameInfo.GetAddressOf(16828);
				_isCrimeToActivate =		NetScriptFramework.Main.GameInfo.GetAddressOf(19400);
			}



			readonly static private System.IntPtr _getHandleFromReference;

			readonly static private System.IntPtr _getReferenceFromHandle;

			readonly static private System.IntPtr _isCrimeToActivate;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x131F60 (VID12192)</summary>
			static public System.IntPtr GetHandleFromReference	{ get { return _getHandleFromReference; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x2130F0 (VID16828)</summary>
			static public System.IntPtr GetReferenceFromHandle	{ get { return _getReferenceFromHandle; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x29A330 (VID19400)</summary>
			static public System.IntPtr IsCrimeToActivate		{ get { return _isCrimeToActivate; } }
		}

		static public class UI
		{
			static UI()
			{
				_instance =			NetScriptFramework.Main.GameInfo.GetAddressOf(514178);
				_showMessageBox =	NetScriptFramework.Main.GameInfo.GetAddressOf(54737);
				_showNotification =	NetScriptFramework.Main.GameInfo.GetAddressOf(54738);
			}



			readonly static private System.IntPtr _instance;

			readonly static private System.IntPtr _showMessageBox;

			readonly static private System.IntPtr _showNotification;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1EBEB20 (VID514178)</summary>
			static public System.IntPtr Instance			{ get { return _instance; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x96DD60 (VID54737)</summary>
			static public System.IntPtr ShowMessageBox		{ get { return _showMessageBox; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x96DDB0 (VID54738)</summary>
			static public System.IntPtr ShowNotification	{ get { return _showNotification; } }
		}
	}
}
