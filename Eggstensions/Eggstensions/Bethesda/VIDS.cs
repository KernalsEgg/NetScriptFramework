namespace Eggstensions.Bethesda
{
	static public class VIDS
	{
		static public class Actor
		{
			static Actor()
			{
				_castSpellPerkEntryPoint =	NetScriptFramework.Main.GameInfo.GetAddressOf(37817);
				_getCollisionFilter =		NetScriptFramework.Main.GameInfo.GetAddressOf(36559);
				_getEyeLevel =				NetScriptFramework.Main.GameInfo.GetAddressOf(36478);
				_getMount =					NetScriptFramework.Main.GameInfo.GetAddressOf(37757);
				_getMountInteraction =		NetScriptFramework.Main.GameInfo.GetAddressOf(19223);
				_getRider =					NetScriptFramework.Main.GameInfo.GetAddressOf(37758);
				_isBeingRidden =			NetScriptFramework.Main.GameInfo.GetAddressOf(21343);
				_isBeingRiddenBy =			NetScriptFramework.Main.GameInfo.GetAddressOf(36878);
				_isHostileToActor =			NetScriptFramework.Main.GameInfo.GetAddressOf(36537);
				_isOnFlyingMount =			NetScriptFramework.Main.GameInfo.GetAddressOf(36877);
				_isOnMount =				NetScriptFramework.Main.GameInfo.GetAddressOf(17570);
				_update3DModel =			NetScriptFramework.Main.GameInfo.GetAddressOf(38404);
			}



			readonly static private System.IntPtr _castSpellPerkEntryPoint;

			readonly static private System.IntPtr _getCollisionFilter;

			readonly static private System.IntPtr _getEyeLevel;

			readonly static private System.IntPtr _getMount;

			readonly static private System.IntPtr _getMountInteraction;

			readonly static private System.IntPtr _getRider;

			readonly static private System.IntPtr _isBeingRidden;

			readonly static private System.IntPtr _isBeingRiddenBy;

			readonly static private System.IntPtr _isHostileToActor;

			readonly static private System.IntPtr _isOnFlyingMount;

			readonly static private System.IntPtr _isOnMount;

			readonly static private System.IntPtr _update3DModel;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x632180 (VID37817)</summary>
			static public System.IntPtr CastSpellPerkEntryPoint	{ get { return _castSpellPerkEntryPoint; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x5EBD90 (VID36559)</summary>
			static public System.IntPtr GetCollisionFilter		{ get { return _getCollisionFilter; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x5E2BB0 (VID36478)</summary>
			static public System.IntPtr GetEyeLevel				{ get { return _getEyeLevel; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x62EBC0 (VID37757)</summary>
			static public System.IntPtr GetMount				{ get { return _getMount; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x28C520 (VID19223)</summary>
			static public System.IntPtr GetMountInteraction		{ get { return _getMountInteraction; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x62ECD0 (VID37758)</summary>
			static public System.IntPtr GetRider				{ get { return _getRider; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x2E4310 (VID21343)</summary>
			static public System.IntPtr IsBeingRidden			{ get { return _isBeingRidden; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x605840 (VID36878)</summary>
			static public System.IntPtr IsBeingRiddenBy			{ get { return _isBeingRiddenBy; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x5E7E40 (VID36537)</summary>
			static public System.IntPtr IsHostileToActor		{ get { return _isHostileToActor; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x6057C0 (VID36877)</summary>
			static public System.IntPtr IsOnFlyingMount			{ get { return _isOnFlyingMount; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x22F320 (VID17570)</summary>
			static public System.IntPtr IsOnMount				{ get { return _isOnMount; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x650DF0 (VID38404)</summary>
			static public System.IntPtr Update3DModel			{ get { return _update3DModel; } }
		}

		static public class BGSCollisionLayer
		{
			static BGSCollisionLayer()
			{
				_collisionFilter = NetScriptFramework.Main.GameInfo.GetAddressOf(514415);
			}



			readonly static private System.IntPtr _collisionFilter;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1EC4328 (VID514415)</summary>
			static public System.IntPtr CollisionFilter { get { return _collisionFilter; } }
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

		static public class BSReadWriteLock
		{
			static BSReadWriteLock()
			{
				_lockForRead =		NetScriptFramework.Main.GameInfo.GetAddressOf(66976);
				_lockForWrite =		NetScriptFramework.Main.GameInfo.GetAddressOf(66977);
				_unlockForRead =	NetScriptFramework.Main.GameInfo.GetAddressOf(66982);
				_unlockForWrite =	NetScriptFramework.Main.GameInfo.GetAddressOf(66983);
			}



			readonly static private System.IntPtr _lockForRead;

			readonly static private System.IntPtr _lockForWrite;

			readonly static private System.IntPtr _unlockForRead;

			readonly static private System.IntPtr _unlockForWrite;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0xC072D0 (VID66976)</summary>
			static public System.IntPtr LockForRead		{ get { return _lockForRead; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0xC07350 (VID66977)</summary>
			static public System.IntPtr LockForWrite	{ get { return _lockForWrite; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0xC07590 (VID66982)</summary>
			static public System.IntPtr UnlockForRead	{ get { return _unlockForRead; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0xC075A0 (VID66983)</summary>
			static public System.IntPtr UnlockForWrite	{ get { return _unlockForWrite; } }
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

		static public class CrosshairPickData
		{
			static CrosshairPickData()
			{
				_instance =	NetScriptFramework.Main.GameInfo.GetAddressOf(515446);
				_pick =		NetScriptFramework.Main.GameInfo.GetAddressOf(25591);
			}



			readonly static private System.IntPtr _instance;

			readonly static private System.IntPtr _pick;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x2F011D0 (VID515446)</summary>
			static public System.IntPtr Instance	{ get { return _instance; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x3AA4B0 (VID25591)</summary>
			static public System.IntPtr Pick		{ get { return _pick; } }
		}

		static public class Events
		{
			static Events()
			{
				_activateFlora =					NetScriptFramework.Main.GameInfo.GetAddressOf(16986);
				_activateTree =						NetScriptFramework.Main.GameInfo.GetAddressOf(17636);
				_attachPrecipitationObject =		NetScriptFramework.Main.GameInfo.GetAddressOf(25640);
				_detachPrecipitationObject1 =		NetScriptFramework.Main.GameInfo.GetAddressOf(25638);
				_detachPrecipitationObject2 =		NetScriptFramework.Main.GameInfo.GetAddressOf(25639);
				_getIsCreatureType =				NetScriptFramework.Main.GameInfo.GetAddressOf(21029);
				_harvest =							NetScriptFramework.Main.GameInfo.GetAddressOf(14692);
			}



			readonly static private System.IntPtr _activateFlora;

			readonly static private System.IntPtr _activateTree;

			readonly static private System.IntPtr _attachPrecipitationObject;

			readonly static private System.IntPtr _detachPrecipitationObject1;

			readonly static private System.IntPtr _detachPrecipitationObject2;

			readonly static private System.IntPtr _getIsCreatureType;

			readonly static private System.IntPtr _harvest;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x218CE0 (VID16986)</summary>
			static public System.IntPtr ActivateFlora					{ get { return _activateFlora; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x231580 (VID17636)</summary>
			static public System.IntPtr ActivateTree					{ get { return _activateTree; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x3AF100 (VID25640)</summary>
			static public System.IntPtr AttachPrecipitationObject		{ get { return _attachPrecipitationObject; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x3AEBD0 (VID25638)</summary>
			static public System.IntPtr DetachPrecipitationObject1		{ get { return _detachPrecipitationObject1; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x3AF050 (VID25639)</summary>
			static public System.IntPtr DetachPrecipitationObject2		{ get { return _detachPrecipitationObject2; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x2D7750 (VID21029)</summary>
			static public System.IntPtr GetIsCreatureType				{ get { return _getIsCreatureType; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x19CA00 (VID14692)</summary>
			static public System.IntPtr Harvest							{ get { return _harvest; } }
		}

		static public class ExtraDataList
		{
			static ExtraDataList()
			{
				_getExtraData = NetScriptFramework.Main.GameInfo.GetAddressOf(12200);
			}



			readonly static private System.IntPtr _getExtraData;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1323C0 (VID12200)</summary>
			static public System.IntPtr GetExtraData { get { return _getExtraData; } }
		}

		static public class Havok
		{
			static Havok()
			{
				_getNiObjectFromHavokObject =	NetScriptFramework.Main.GameInfo.GetAddressOf(76160);
				_havokWorldScale =				NetScriptFramework.Main.GameInfo.GetAddressOf(231896);
				_havokWorldScaleInverse =		NetScriptFramework.Main.GameInfo.GetAddressOf(230692);
			}



			readonly static private System.IntPtr _getNiObjectFromHavokObject;

			readonly static private System.IntPtr _havokWorldScale;

			readonly static private System.IntPtr _havokWorldScaleInverse;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0xDAD060 (VID76160)</summary>
			static public System.IntPtr GetNiObjectFromHavokObject	{ get { return _getNiObjectFromHavokObject; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x154064C (VID231896)</summary>
			static public System.IntPtr HavokWorldScale				{ get { return _havokWorldScale; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1536BA0 (VID230692)</summary>
			static public System.IntPtr HavokWorldScaleInverse		{ get { return _havokWorldScaleInverse; } }
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

		static public class HorseCameraState
		{
			static HorseCameraState()
			{
				_weaponDrawnTargetOffsetX =		NetScriptFramework.Main.GameInfo.GetAddressOf(509838);
				_weaponDrawnTargetOffsetY =		NetScriptFramework.Main.GameInfo.GetAddressOf(509842);
				_weaponDrawnTargetOffsetZ =		NetScriptFramework.Main.GameInfo.GetAddressOf(509840);
				_weaponSheathedTargetOffsetX =	NetScriptFramework.Main.GameInfo.GetAddressOf(509832);
				_weaponSheathedTargetOffsetY =	NetScriptFramework.Main.GameInfo.GetAddressOf(509836);
				_weaponSheathedTargetOffsetZ =	NetScriptFramework.Main.GameInfo.GetAddressOf(509834);
			}



			readonly static private System.IntPtr _weaponDrawnTargetOffsetX;

			readonly static private System.IntPtr _weaponDrawnTargetOffsetY;

			readonly static private System.IntPtr _weaponDrawnTargetOffsetZ;

			readonly static private System.IntPtr _weaponSheathedTargetOffsetX;

			readonly static private System.IntPtr _weaponSheathedTargetOffsetY;

			readonly static private System.IntPtr _weaponSheathedTargetOffsetZ;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1DF35F8 (VID509838)</summary>
			static public System.IntPtr WeaponDrawnTargetOffsetX	{ get { return _weaponDrawnTargetOffsetX; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1DF3628 (VID509842)</summary>
			static public System.IntPtr WeaponDrawnTargetOffsetY	{ get { return _weaponDrawnTargetOffsetY; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1DF3610 (VID509840)</summary>
			static public System.IntPtr WeaponDrawnTargetOffsetZ	{ get { return _weaponDrawnTargetOffsetZ; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1DF35B0 (VID509832)</summary>
			static public System.IntPtr WeaponSheathedTargetOffsetX	{ get { return _weaponSheathedTargetOffsetX; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1DF35E0 (VID509836)</summary>
			static public System.IntPtr WeaponSheathedTargetOffsetY	{ get { return _weaponSheathedTargetOffsetY; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1DF35C8 (VID509834)</summary>
			static public System.IntPtr WeaponSheathedTargetOffsetZ	{ get { return _weaponSheathedTargetOffsetZ; } }
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

		static public class Math
		{
			static Math()
			{
				_delta =				NetScriptFramework.Main.GameInfo.GetAddressOf(235554);
				_half =					NetScriptFramework.Main.GameInfo.GetAddressOf(230690);
				_halfPercent =			NetScriptFramework.Main.GameInfo.GetAddressOf(233241);
				_halfPercentNegative =	NetScriptFramework.Main.GameInfo.GetAddressOf(262074);
				_one =					NetScriptFramework.Main.GameInfo.GetAddressOf(228662);
				_oneNegative =			NetScriptFramework.Main.GameInfo.GetAddressOf(228611);
				_oneQuarter =			NetScriptFramework.Main.GameInfo.GetAddressOf(232866);
				_threeQuarters =		NetScriptFramework.Main.GameInfo.GetAddressOf(235914);
			}



			readonly static private System.IntPtr _delta;

			readonly static private System.IntPtr _half;

			readonly static private System.IntPtr _halfPercent;

			readonly static private System.IntPtr _halfPercentNegative;

			readonly static private System.IntPtr _one;

			readonly static private System.IntPtr _oneNegative;

			readonly static private System.IntPtr _oneQuarter;

			readonly static private System.IntPtr _threeQuarters;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x156B7B4 (VID235554)</summary>
			static public System.IntPtr Delta				{ get { return _delta; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1536B98 (VID230690)</summary>
			static public System.IntPtr Half				{ get { return _half; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x154C018 (VID233241)</summary>
			static public System.IntPtr HalfPercent			{ get { return _halfPercent; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1665730 (VID262074)</summary>
			static public System.IntPtr HalfPercentNegative	{ get { return _halfPercentNegative; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x15232D8 (VID228662)</summary>
			static public System.IntPtr One					{ get { return _one; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x152259C (VID228611)</summary>
			static public System.IntPtr OneNegative			{ get { return _oneNegative; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1548E48 (VID232866)</summary>
			static public System.IntPtr OneQuarter			{ get { return _oneQuarter; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x156F92C (VID235914)</summary>
			static public System.IntPtr ThreeQuarters		{ get { return _threeQuarters; } }
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

		static public class NiBound
		{
			static NiBound()
			{
				_isInFieldOfView = NetScriptFramework.Main.GameInfo.GetAddressOf(15671);
			}



			readonly static private System.IntPtr _isInFieldOfView;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1D24C0 (VID15671)</summary>
			static public System.IntPtr IsInFieldOfView { get { return _isInFieldOfView; } }
		}

		static public class PlayerCamera
		{
			static PlayerCamera()
			{
				_getCameraTarget =	NetScriptFramework.Main.GameInfo.GetAddressOf(49904);
				_instance =			NetScriptFramework.Main.GameInfo.GetAddressOf(514642);
			}



			readonly static private System.IntPtr _getCameraTarget;

			readonly static private System.IntPtr _instance;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x84D320 (VID49904)</summary>
			static public System.IntPtr GetCameraTarget	{ get { return _getCameraTarget; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x2EC59B8 (VID514642)</summary>
			static public System.IntPtr Instance		{ get { return _instance; } }
		}

		static public class PlayerCharacter
		{
			static PlayerCharacter()
			{
				_activateDistance =		NetScriptFramework.Main.GameInfo.GetAddressOf(502527);
				_commandDistance =		NetScriptFramework.Main.GameInfo.GetAddressOf(502841);
				_hasLineOfSight =		NetScriptFramework.Main.GameInfo.GetAddressOf(39444);
				_instance =				NetScriptFramework.Main.GameInfo.GetAddressOf(517014);
				_isCommandingActor =	NetScriptFramework.Main.GameInfo.GetAddressOf(39579);
			}



			readonly static private System.IntPtr _activateDistance;

			readonly static private System.IntPtr _commandDistance;

			readonly static private System.IntPtr _hasLineOfSight;

			readonly static private System.IntPtr _instance;

			readonly static private System.IntPtr _isCommandingActor;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1DD7E88 (VID502527)</summary>
			static public System.IntPtr ActivateDistance	{ get { return _activateDistance; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1DD8FB0 (VID502841)</summary>
			static public System.IntPtr CommandDistance		{ get { return _commandDistance; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x6A4A00 (VID39444)</summary>
			static public System.IntPtr HasLineOfSight		{ get { return _hasLineOfSight; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x2F26EF8 (VID517014)</summary>
			static public System.IntPtr Instance			{ get { return _instance; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x6B3670 (VID39579)</summary>
			static public System.IntPtr IsCommandingActor	{ get { return _isCommandingActor; } }
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

		static public class SceneGraph
		{
			static SceneGraph()
			{
				_menu3DRootNode = NetScriptFramework.Main.GameInfo.GetAddressOf(517008);
				_menuRootNode = NetScriptFramework.Main.GameInfo.GetAddressOf(517007);
				_worldRootNode = NetScriptFramework.Main.GameInfo.GetAddressOf(517006);
			}



			readonly static private System.IntPtr _menu3DRootNode;

			readonly static private System.IntPtr _menuRootNode;

			readonly static private System.IntPtr _worldRootNode;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x2F26ED0 (VID517008)</summary>
			static public System.IntPtr Menu3DRootNode { get { return _menu3DRootNode; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x2F26EC8 (VID517007)</summary>
			static public System.IntPtr MenuRootNode { get { return _menuRootNode; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x2F26EC0 (VID517006)</summary>
			static public System.IntPtr WorldRootNode { get { return _worldRootNode; } }
		}

		static public class SettingT
		{
			static public class GameSettingCollection
			{
				static GameSettingCollection()
				{
					_autoAimBasedOnDistance =	NetScriptFramework.Main.GameInfo.GetAddressOf(504543);
					_autoAimMaxDistance =		NetScriptFramework.Main.GameInfo.GetAddressOf(504545);
					_autoAimScreenPercentage =	NetScriptFramework.Main.GameInfo.GetAddressOf(504547);
				}



				readonly static private System.IntPtr _autoAimBasedOnDistance;

				readonly static private System.IntPtr _autoAimMaxDistance;

				readonly static private System.IntPtr _autoAimScreenPercentage;



				/// <summary>&lt;SkyrimSE.exe&gt; + 0x1DDEC70 (VID504543)</summary>
				static public System.IntPtr AutoAimBasedOnDistance	{ get { return _autoAimBasedOnDistance; } }

				/// <summary>&lt;SkyrimSE.exe&gt; + 0x1DDEC88 (VID504545)</summary>
				static public System.IntPtr AutoAimMaxDistance		{ get { return _autoAimMaxDistance; } }

				/// <summary>&lt;SkyrimSE.exe&gt; + 0x1DDECA0 (VID504547)</summary>
				static public System.IntPtr AutoAimScreenPercentage	{ get { return _autoAimScreenPercentage; } }
			}

			static public class INISettingCollection
			{
				static INISettingCollection()
				{
					_gridsToLoad = NetScriptFramework.Main.GameInfo.GetAddressOf(501244);
				}



				readonly static private System.IntPtr _gridsToLoad;



				/// <summary>&lt;SkyrimSE.exe&gt; + 0x1DB3E28 (VID501244)</summary>
				static public System.IntPtr GridsToLoad { get { return _gridsToLoad; } }
			}
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
				_instance =		NetScriptFramework.Main.GameInfo.GetAddressOf(516923);
			}



			readonly static private System.IntPtr _instance;



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

		static public class TESFlora
		{
			static TESFlora()
			{
				_vTable = NetScriptFramework.Main.GameInfo.GetAddressOf(233756);
			}



			readonly static private System.IntPtr _vTable;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1553738 (VID233756)</summary>
			static public System.IntPtr VTable { get { return _vTable; } }
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
				_activate =						NetScriptFramework.Main.GameInfo.GetAddressOf(19369);
				_createHandleFromReference =	NetScriptFramework.Main.GameInfo.GetAddressOf(12192);
				_getHandleFromReference =		NetScriptFramework.Main.GameInfo.GetAddressOf(19418);
				_getReferenceFromHandle =		NetScriptFramework.Main.GameInfo.GetAddressOf(16828);
				_isCrimeToActivate =			NetScriptFramework.Main.GameInfo.GetAddressOf(19400);
				_nullHandle =					NetScriptFramework.Main.GameInfo.GetAddressOf(514164);
			}



			readonly static private System.IntPtr _activate;

			readonly static private System.IntPtr _createHandleFromReference;

			readonly static private System.IntPtr _getHandleFromReference;

			readonly static private System.IntPtr _getReferenceFromHandle;

			readonly static private System.IntPtr _isCrimeToActivate;

			readonly static private System.IntPtr _nullHandle;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x296C00 (VID19369)</summary>
			static public System.IntPtr Activate					{ get { return _activate; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x131F60 (VID12192)</summary>
			static public System.IntPtr CreateHandleFromReference	{ get { return _createHandleFromReference; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x29B980 (VID19418)</summary>
			static public System.IntPtr GetHandleFromReference		{ get { return _getHandleFromReference; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x2130F0 (VID16828)</summary>
			static public System.IntPtr GetReferenceFromHandle		{ get { return _getReferenceFromHandle; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x29A330 (VID19400)</summary>
			static public System.IntPtr IsCrimeToActivate			{ get { return _isCrimeToActivate; } }

			/// <summary>&lt;SkyrimSE.exe&gt; + 0x1EBEABC (VID514164)</summary>
			static public System.IntPtr NullHandle					{ get { return _nullHandle; } }
		}

		static public class TESObjectTREE
		{
			static TESObjectTREE()
			{
				_vTable = NetScriptFramework.Main.GameInfo.GetAddressOf(234296);
			}



			readonly static private System.IntPtr _vTable;



			/// <summary>&lt;SkyrimSE.exe&gt; + 0x155B7F8 (VID234296)</summary>
			static public System.IntPtr VTable { get { return _vTable; } }
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
