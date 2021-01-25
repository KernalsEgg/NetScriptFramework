namespace Eggstensions.SkyrimSE
{
	static public class VIDS
	{
		static public class Actor
		{
			static Actor()
			{
				AddSpellHandler =		NetScriptFramework.Main.GameInfo.GetAddressOf(37817);
				GetCollisionFilter =	NetScriptFramework.Main.GameInfo.GetAddressOf(36559);
				GetEyeLevel =			NetScriptFramework.Main.GameInfo.GetAddressOf(36478);
				GetMount =				NetScriptFramework.Main.GameInfo.GetAddressOf(37757);
				GetMountInteraction =	NetScriptFramework.Main.GameInfo.GetAddressOf(19223);
				GetRider =				NetScriptFramework.Main.GameInfo.GetAddressOf(37758);
				IsBeingRidden =			NetScriptFramework.Main.GameInfo.GetAddressOf(21343);
				IsBeingRiddenBy =		NetScriptFramework.Main.GameInfo.GetAddressOf(36878);
				IsHostileToActor =		NetScriptFramework.Main.GameInfo.GetAddressOf(36537);
				IsOnFlyingMount =		NetScriptFramework.Main.GameInfo.GetAddressOf(36877);
				IsOnMount =				NetScriptFramework.Main.GameInfo.GetAddressOf(17570);
				Update3DModel =			NetScriptFramework.Main.GameInfo.GetAddressOf(38404);
			}



			/// <summary>SkyrimSE.exe + 0x632180 (VID 37817)</summary>
			static public System.IntPtr AddSpellHandler { get; }

			/// <summary>SkyrimSE.exe + 0x5EBD90 (VID 36559)</summary>
			static public System.IntPtr GetCollisionFilter { get; }

			/// <summary>SkyrimSE.exe + 0x5E2BB0 (VID 36478)</summary>
			static public System.IntPtr GetEyeLevel { get; }

			/// <summary>SkyrimSE.exe + 0x62EBC0 (VID 37757)</summary>
			static public System.IntPtr GetMount { get; }

			/// <summary>SkyrimSE.exe + 0x28C520 (VID 19223)</summary>
			static public System.IntPtr GetMountInteraction { get; }

			/// <summary>SkyrimSE.exe + 0x62ECD0 (VID 37758)</summary>
			static public System.IntPtr GetRider { get; }

			/// <summary>SkyrimSE.exe + 0x2E4310 (VID 21343)</summary>
			static public System.IntPtr IsBeingRidden { get; }

			/// <summary>SkyrimSE.exe + 0x605840 (VID 36878)</summary>
			static public System.IntPtr IsBeingRiddenBy { get; }

			/// <summary>SkyrimSE.exe + 0x5E7E40 (VID 36537)</summary>
			static public System.IntPtr IsHostileToActor { get; }

			/// <summary>SkyrimSE.exe + 0x6057C0 (VID 36877)</summary>
			static public System.IntPtr IsOnFlyingMount { get; }

			/// <summary>SkyrimSE.exe + 0x22F320 (VID 17570)</summary>
			static public System.IntPtr IsOnMount { get; }

			/// <summary>SkyrimSE.exe + 0x650DF0 (VID 38404)</summary>
			static public System.IntPtr Update3DModel { get; }
		}

		static public class BGSCollisionLayer
		{
			static BGSCollisionLayer()
			{
				CollisionFilter = NetScriptFramework.Main.GameInfo.GetAddressOf(514415);
			}



			/// <summary>SkyrimSE.exe + 0x1EC4328 (VID 514415)</summary>
			static public System.IntPtr CollisionFilter { get; }
		}

		static public class bhkWorldM
		{
			static bhkWorldM()
			{
				Scale =			NetScriptFramework.Main.GameInfo.GetAddressOf(231896);
				ScaleInverse =	NetScriptFramework.Main.GameInfo.GetAddressOf(230692);
			}



			/// <summary>SkyrimSE.exe + 0x154064C (VID 231896)</summary>
			static public System.IntPtr Scale { get; }

			/// <summary>SkyrimSE.exe + 0x1536BA0 (VID 230692)</summary>
			static public System.IntPtr ScaleInverse { get; }
		}

		static public class BSFixedString
		{
			static BSFixedString()
			{
				Initialize =	NetScriptFramework.Main.GameInfo.GetAddressOf(67819);
				Release =		NetScriptFramework.Main.GameInfo.GetAddressOf(67822);
			}



			/// <summary>SkyrimSE.exe + 0xC28BF0 (VID 67819)</summary>
			static public System.IntPtr Initialize { get; }

			/// <summary>SkyrimSE.exe + 0xC28D40 (VID 67822)</summary>
			static public System.IntPtr Release { get; }
		}

		static public class BSPointerHandle
		{
			static BSPointerHandle()
			{
				CreateHandleFromReference =	NetScriptFramework.Main.GameInfo.GetAddressOf(12192);
				GetHandleFromReference =	NetScriptFramework.Main.GameInfo.GetAddressOf(19418);
				GetReferenceFromHandle =	NetScriptFramework.Main.GameInfo.GetAddressOf(16828);
				List =						NetScriptFramework.Main.GameInfo.GetAddressOf(514478);
				Null =						NetScriptFramework.Main.GameInfo.GetAddressOf(514164);
			}



			/// <summary>SkyrimSE.exe + 0x131F60 (VID 12192)</summary>
			static public System.IntPtr CreateHandleFromReference { get; }

			/// <summary>SkyrimSE.exe + 0x29B980 (VID 19418)</summary>
			static public System.IntPtr GetHandleFromReference { get; }

			/// <summary>SkyrimSE.exe + 0x2130F0 (VID 16828)</summary>
			static public System.IntPtr GetReferenceFromHandle { get; }

			/// <summary>SkyrimSE.exe + 0x1EC47C0 (VID 514478)</summary>
			static public System.IntPtr List { get; }

			/// <summary>SkyrimSE.exe + 0x1EBEABC (VID 514164)</summary>
			static public System.IntPtr Null { get; }
		}

		static public class BSReadWriteLock
		{
			static BSReadWriteLock()
			{
				LockForRead =		NetScriptFramework.Main.GameInfo.GetAddressOf(66976);
				LockForWrite =		NetScriptFramework.Main.GameInfo.GetAddressOf(66977);
				UnlockForRead =		NetScriptFramework.Main.GameInfo.GetAddressOf(66982);
				UnlockForWrite =	NetScriptFramework.Main.GameInfo.GetAddressOf(66983);
			}



			/// <summary>SkyrimSE.exe + 0xC072D0 (VID 66976)</summary>
			static public System.IntPtr LockForRead { get; }

			/// <summary>SkyrimSE.exe + 0xC07350 (VID 66977)</summary>
			static public System.IntPtr LockForWrite { get; }

			/// <summary>SkyrimSE.exe + 0xC07590 (VID 66982)</summary>
			static public System.IntPtr UnlockForRead { get; }

			/// <summary>SkyrimSE.exe + 0xC075A0 (VID 66983)</summary>
			static public System.IntPtr UnlockForWrite { get; }
		}

		static public class BSSpinLock
		{
			static BSSpinLock()
			{
				Lock = NetScriptFramework.Main.GameInfo.GetAddressOf(12210);
			}



			/// <summary>SkyrimSE.exe + 0x132BD0 (VID 12210)</summary>
			static public System.IntPtr Lock { get; }
		}

		static public class Character
		{
			static Character()
			{
				HasLineOfSight = NetScriptFramework.Main.GameInfo.GetAddressOf(36745);
			}



			/// <summary>SkyrimSE.exe + 0x5FC880 (VID 36745)</summary>
			static public System.IntPtr HasLineOfSight { get; }
		}

		static public class ConsoleLog
		{
			static ConsoleLog()
			{
				Instance =	NetScriptFramework.Main.GameInfo.GetAddressOf(515064);
				Print =		NetScriptFramework.Main.GameInfo.GetAddressOf(50179);
			}



			/// <summary>SkyrimSE.exe + 0x2F000F0 (VID 515064)</summary>
			static public System.IntPtr Instance { get; }

			/// <summary>SkyrimSE.exe + 0x85C290 (VID 50179)</summary>
			static public System.IntPtr Print { get; }
		}

		static public class CrosshairPickData
		{
			static CrosshairPickData()
			{
				Instance = NetScriptFramework.Main.GameInfo.GetAddressOf(515446);
			}



			/// <summary>SkyrimSE.exe + 0x2F011D0 (VID 515446)</summary>
			static public System.IntPtr Instance { get; }
		}

		static public class Events
		{
			static Events()
			{
				ActivateFlora =					NetScriptFramework.Main.GameInfo.GetAddressOf(16986);
				ActivateTree =					NetScriptFramework.Main.GameInfo.GetAddressOf(17636);
				AttachPrecipitationObject =		NetScriptFramework.Main.GameInfo.GetAddressOf(25640);
				DetachPrecipitationObject1 =	NetScriptFramework.Main.GameInfo.GetAddressOf(25638);
				DetachPrecipitationObject2 =	NetScriptFramework.Main.GameInfo.GetAddressOf(25639);
				GetIsCreatureType =				NetScriptFramework.Main.GameInfo.GetAddressOf(21029);
				Harvest =						NetScriptFramework.Main.GameInfo.GetAddressOf(14692);
			}



			/// <summary>SkyrimSE.exe + 0x218CE0 (VID 16986)</summary>
			static public System.IntPtr ActivateFlora { get; }

			/// <summary>SkyrimSE.exe + 0x231580 (VID 17636)</summary>
			static public System.IntPtr ActivateTree { get; }

			/// <summary>SkyrimSE.exe + 0x3AF100 (VID 25640)</summary>
			static public System.IntPtr AttachPrecipitationObject { get; }

			/// <summary>SkyrimSE.exe + 0x3AEBD0 (VID 25638)</summary>
			static public System.IntPtr DetachPrecipitationObject1 { get; }

			/// <summary>SkyrimSE.exe + 0x3AF050 (VID 25639)</summary>
			static public System.IntPtr DetachPrecipitationObject2 { get; }

			/// <summary>SkyrimSE.exe + 0x2D7750 (VID 21029)</summary>
			static public System.IntPtr GetIsCreatureType { get; }

			/// <summary>SkyrimSE.exe + 0x19CA00 (VID 14692)</summary>
			static public System.IntPtr Harvest { get; }
		}

		static public class ExtraDataList
		{
			static ExtraDataList()
			{
				GetExtraData = NetScriptFramework.Main.GameInfo.GetAddressOf(12200);
			}



			/// <summary>SkyrimSE.exe + 0x1323C0 (VID 12200)</summary>
			static public System.IntPtr GetExtraData { get; }
		}

		static public class Havok
		{
			static Havok()
			{
				GetNiObjectFromHavokObject = NetScriptFramework.Main.GameInfo.GetAddressOf(76160);
			}



			/// <summary>SkyrimSE.exe + 0xDAD060 (VID 76160)</summary>
			static public System.IntPtr GetNiObjectFromHavokObject { get; }
		}

		static public class hkpAllRayHitTempCollector
		{
			static hkpAllRayHitTempCollector()
			{
				Constructor =	NetScriptFramework.Main.GameInfo.GetAddressOf(15062);
				Destructor =	NetScriptFramework.Main.GameInfo.GetAddressOf(15073);
			}



			/// <summary>SkyrimSE.exe + 0x1AFE40 (VID 15062)</summary>
			static public System.IntPtr Constructor { get; }

			/// <summary>SkyrimSE.exe + 0x1B02A0 (VID 15073)</summary>
			static public System.IntPtr Destructor { get; }
		}

		static public class Main
		{
			static Main()
			{
				Instance = NetScriptFramework.Main.GameInfo.GetAddressOf(516943);
			}



			/// <summary>SkyrimSE.exe + 0x2F26BF8 (VID 516943)</summary>
			static public System.IntPtr Instance { get; }
		}

		static public class Math
		{
			static Math()
			{
				Delta =									NetScriptFramework.Main.GameInfo.GetAddressOf(235554);
				Half =									NetScriptFramework.Main.GameInfo.GetAddressOf(230690);
				HalfPercent =							NetScriptFramework.Main.GameInfo.GetAddressOf(233241);
				HalfPercentNegative =					NetScriptFramework.Main.GameInfo.GetAddressOf(262074);
				NinetyDegreesToRadians =				NetScriptFramework.Main.GameInfo.GetAddressOf(234435);
				NinetyDegreesToRadiansNegative =		NetScriptFramework.Main.GameInfo.GetAddressOf(234440);
				NinetyDegreesToRadiansInverseNegative =	NetScriptFramework.Main.GameInfo.GetAddressOf(256661);
				One =									NetScriptFramework.Main.GameInfo.GetAddressOf(228662);
				OneNegative =							NetScriptFramework.Main.GameInfo.GetAddressOf(228611);
				OneQuarter =							NetScriptFramework.Main.GameInfo.GetAddressOf(232866);
				ThreeQuarters =							NetScriptFramework.Main.GameInfo.GetAddressOf(235914);
			}



			/// <summary>SkyrimSE.exe + 0x156B7B4 (VID 235554)</summary>
			static public System.IntPtr Delta { get; }

			/// <summary>SkyrimSE.exe + 0x1536B98 (VID 230690)</summary>
			static public System.IntPtr Half { get; }

			/// <summary>SkyrimSE.exe + 0x154C018 (VID 233241)</summary>
			static public System.IntPtr HalfPercent { get; }

			/// <summary>SkyrimSE.exe + 0x1665730 (VID 262074)</summary>
			static public System.IntPtr HalfPercentNegative { get; }

			/// <summary>SkyrimSE.exe + 0x155CFD8 (VID 234435)</summary>
			static public System.IntPtr NinetyDegreesToRadians { get; }

			/// <summary>SkyrimSE.exe + 0x155CFEC (VID 234440)</summary>
			static public System.IntPtr NinetyDegreesToRadiansNegative { get; }

			/// <summary>SkyrimSE.exe + 0x162F550 (VID 256661)</summary>
			static public System.IntPtr NinetyDegreesToRadiansInverseNegative { get; }

			/// <summary>SkyrimSE.exe + 0x15232D8 (VID 228662)</summary>
			static public System.IntPtr One { get; }

			/// <summary>SkyrimSE.exe + 0x152259C (VID 228611)</summary>
			static public System.IntPtr OneNegative { get; }

			/// <summary>SkyrimSE.exe + 0x1548E48 (VID 232866)</summary>
			static public System.IntPtr OneQuarter { get; }

			/// <summary>SkyrimSE.exe + 0x156F92C (VID 235914)</summary>
			static public System.IntPtr ThreeQuarters { get; }
		}

		static public class MountInteraction
		{
			static MountInteraction()
			{
				GetMount = NetScriptFramework.Main.GameInfo.GetAddressOf(40521);
				GetRider = NetScriptFramework.Main.GameInfo.GetAddressOf(40522);
			}



			/// <summary>SkyrimSE.exe + 0x6E4F00 (VID 40521)</summary>
			static public System.IntPtr GetMount { get; }

			/// <summary>SkyrimSE.exe + 0x6E4FF0 (VID 40522)</summary>
			static public System.IntPtr GetRider { get; }
		}

		static public class NiAVObject
		{
			static NiAVObject()
			{
				GetBoneNodeByName = NetScriptFramework.Main.GameInfo.GetAddressOf(74481);
			}



			/// <summary>SkyrimSE.exe + 0xD41970 (VID 74481)</summary>
			static public System.IntPtr GetBoneNodeByName { get; }
		}

		static public class NiBoneNames
		{
			static NiBoneNames()
			{
				Instance = NetScriptFramework.Main.GameInfo.GetAddressOf(11308);
			}



			/// <summary>SkyrimSE.exe + 0x104AD0 (VID 11308)</summary>
			static public System.IntPtr Instance { get; }
		}

		static public class NiBound
		{
			static NiBound()
			{
				IsInFieldOfView = NetScriptFramework.Main.GameInfo.GetAddressOf(15671);
			}



			/// <summary>SkyrimSE.exe + 0x1D24C0 (VID 15671)</summary>
			static public System.IntPtr IsInFieldOfView { get; }
		}

		static public class PlayerCamera
		{
			static PlayerCamera()
			{
				Instance = NetScriptFramework.Main.GameInfo.GetAddressOf(514642);
			}



			/// <summary>SkyrimSE.exe + 0x2EC59B8 (VID 514642)</summary>
			static public System.IntPtr Instance { get; }
		}

		static public class PlayerCharacter
		{
			static PlayerCharacter()
			{
				HasLineOfSight =	NetScriptFramework.Main.GameInfo.GetAddressOf(39444);
				Instance =			NetScriptFramework.Main.GameInfo.GetAddressOf(517014);
			}



			/// <summary>SkyrimSE.exe + 0x6A4A00 (VID 39444)</summary>
			static public System.IntPtr HasLineOfSight { get; }

			/// <summary>SkyrimSE.exe + 0x2F26EF8 (VID 517014)</summary>
			static public System.IntPtr Instance { get; }
		}

		static public class PlayerControls
		{
			static PlayerControls()
			{
				Instance = NetScriptFramework.Main.GameInfo.GetAddressOf(514706);
			}



			/// <summary>SkyrimSE.exe + 0x2EC5BD8 (VID 514706)</summary>
			static public System.IntPtr Instance { get; }
		}

		static public class ProcessLists
		{
			static ProcessLists()
			{
				Instance = NetScriptFramework.Main.GameInfo.GetAddressOf(514167);
			}



			/// <summary>SkyrimSE.exe + 0x1EBEAD0 (VID 514167)</summary>
			static public System.IntPtr Instance { get; }
		}

		static public class SceneGraph
		{
			static SceneGraph()
			{
				Menu3DRootNode =	NetScriptFramework.Main.GameInfo.GetAddressOf(517008);
				MenuRootNode =		NetScriptFramework.Main.GameInfo.GetAddressOf(517007);
				WorldRootNode =		NetScriptFramework.Main.GameInfo.GetAddressOf(517006);
			}



			/// <summary>SkyrimSE.exe + 0x2F26ED0 (VID 517008)</summary>
			static public System.IntPtr Menu3DRootNode { get; }

			/// <summary>SkyrimSE.exe + 0x2F26EC8 (VID 517007)</summary>
			static public System.IntPtr MenuRootNode { get; }

			/// <summary>SkyrimSE.exe + 0x2F26EC0 (VID 517006)</summary>
			static public System.IntPtr WorldRootNode { get; }
		}

		static public class SettingT
		{
			static public class GameSettingCollection
			{
				static GameSettingCollection()
				{
					AutoAimBasedOnDistance =		NetScriptFramework.Main.GameInfo.GetAddressOf(504543);
					AutoAimMaxDistance =			NetScriptFramework.Main.GameInfo.GetAddressOf(504545);
					AutoAimScreenPercentage =		NetScriptFramework.Main.GameInfo.GetAddressOf(504547);
					FavorRequestPickDistance =		NetScriptFramework.Main.GameInfo.GetAddressOf(502840);
					HorseMaxUpwardPitch =			NetScriptFramework.Main.GameInfo.GetAddressOf(509845);
					MountedMaxLookingDown =			NetScriptFramework.Main.GameInfo.GetAddressOf(503103);
					OverShoulderRangedMountedAddY =	NetScriptFramework.Main.GameInfo.GetAddressOf(509841);
					OverShoulderRangedMountedPosX =	NetScriptFramework.Main.GameInfo.GetAddressOf(509837);
					OverShoulderRangedMountedPosZ =	NetScriptFramework.Main.GameInfo.GetAddressOf(509839);
				}



				/// <summary>SkyrimSE.exe + 0x1DDEC70 (VID 504543)</summary>
				static public System.IntPtr AutoAimBasedOnDistance { get; }

				/// <summary>SkyrimSE.exe + 0x1DDEC88 (VID 504545)</summary>
				static public System.IntPtr AutoAimMaxDistance { get; }

				/// <summary>SkyrimSE.exe + 0x1DDECA0 (VID 504547)</summary>
				static public System.IntPtr AutoAimScreenPercentage { get; }

				/// <summary>SkyrimSE.exe + 0x1DD8FA8 (VID 502840)</summary>
				static public System.IntPtr FavorRequestPickDistance { get; }

				/// <summary>SkyrimSE.exe + 0x1DF3650 (VID 509845)</summary>
				static public System.IntPtr HorseMaxUpwardPitch { get; }

				/// <summary>SkyrimSE.exe + 0x1DD9E18 (VID 503103)</summary>
				static public System.IntPtr MountedMaxLookingDown { get; }

				/// <summary>SkyrimSE.exe + 0x1DF3620 (VID 509841)</summary>
				static public System.IntPtr OverShoulderRangedMountedAddY { get; }

				/// <summary>SkyrimSE.exe + 0x1DF35F0 (VID 509837)</summary>
				static public System.IntPtr OverShoulderRangedMountedPosX { get; }

				/// <summary>SkyrimSE.exe + 0x1DF3608 (VID 509839)</summary>
				static public System.IntPtr OverShoulderRangedMountedPosZ { get; }
			}

			static public class INISettingCollection
			{
				static public class Interface
				{
					static Interface()
					{
						ActivatePickLength = NetScriptFramework.Main.GameInfo.GetAddressOf(502526);
					}



					/// <summary>SkyrimSE.exe + 0x1DD7E80 (VID 502526)</summary>
					static public System.IntPtr ActivatePickLength { get; }
				}

				static public class General
				{
					static General()
					{
						GridsToLoad = NetScriptFramework.Main.GameInfo.GetAddressOf(501244);
					}



					/// <summary>SkyrimSE.exe + 0x1DB3E28 (VID 501244)</summary>
					static public System.IntPtr GridsToLoad { get; }
				}

				static public class Camera
				{
					static Camera()
					{
						FreeRotationSpeed =		NetScriptFramework.Main.GameInfo.GetAddressOf(509883);
						OverShoulderHorseAddY =	NetScriptFramework.Main.GameInfo.GetAddressOf(509835);
						OverShoulderHorsePosX =	NetScriptFramework.Main.GameInfo.GetAddressOf(509831);
						OverShoulderHorsePosZ =	NetScriptFramework.Main.GameInfo.GetAddressOf(509833);
						PitchZoomOutMaxDist =	NetScriptFramework.Main.GameInfo.GetAddressOf(509904);
					}



					/// <summary>SkyrimSE.exe + 0x1DF3818 (VID 509883)</summary>
					static public System.IntPtr FreeRotationSpeed { get; }

					/// <summary>SkyrimSE.exe + 0x1DF35D8 (VID 509835)</summary>
					static public System.IntPtr OverShoulderHorseAddY { get; }

					/// <summary>SkyrimSE.exe + 0x1DF35A8 (VID 509831)</summary>
					static public System.IntPtr OverShoulderHorsePosX { get; }

					/// <summary>SkyrimSE.exe + 0x1DF35C0 (VID 509833)</summary>
					static public System.IntPtr OverShoulderHorsePosZ { get; }

					/// <summary>SkyrimSE.exe + 0x1DF3920 (VID 509904)</summary>
					static public System.IntPtr PitchZoomOutMaxDist { get; }
				}
			}
		}

		static public class Sky
		{
			static Sky()
			{
				Instance =	NetScriptFramework.Main.GameInfo.GetAddressOf(13789);
				IsRaining =	NetScriptFramework.Main.GameInfo.GetAddressOf(21344);
				IsSnowing =	NetScriptFramework.Main.GameInfo.GetAddressOf(21345);
			}



			/// <summary>SkyrimSE.exe + 0x177790 (VID 13789)</summary>
			static public System.IntPtr Instance { get; }

			/// <summary>SkyrimSE.exe + 0x2E4380 (VID 21344)</summary>
			static public System.IntPtr IsRaining { get; }

			/// <summary>SkyrimSE.exe + 0x2E4400 (VID 21345)</summary>
			static public System.IntPtr IsSnowing { get; }
		}

		static public class TES
		{
			static TES()
			{
				Instance = NetScriptFramework.Main.GameInfo.GetAddressOf(516923);
			}



			/// <summary>SkyrimSE.exe + 0x2F26B20 (VID 516923)</summary>
			static public System.IntPtr Instance { get; }
		}

		static public class TESDataHandler
		{
			static TESDataHandler()
			{
				Instance =	NetScriptFramework.Main.GameInfo.GetAddressOf(514141);
				GetFile =	NetScriptFramework.Main.GameInfo.GetAddressOf(13632);
			}



			/// <summary>SkyrimSE.exe + 0x1EBE428 (VID 514141)</summary>
			static public System.IntPtr Instance { get; }

			/// <summary>SkyrimSE.exe + 0x16D1B0 (VID 13632)</summary>
			static public System.IntPtr GetFile { get; }
		}

		static public class TESFile
		{
			static TESFile()
			{
				GetGlobalFormID =	NetScriptFramework.Main.GameInfo.GetAddressOf(13915);
				IsLoaded =			NetScriptFramework.Main.GameInfo.GetAddressOf(13882);
			}



			/// <summary>SkyrimSE.exe + 0x17E180 (VID 13915)</summary>
			static public System.IntPtr GetGlobalFormID { get; }

			/// <summary>SkyrimSE.exe + 0x17C670 (VID 13882)</summary>
			static public System.IntPtr IsLoaded { get; }
		}

		static public class TESFlora
		{
			static TESFlora()
			{
				Activate = NetScriptFramework.Main.GameInfo.GetAddressOf(16986);
			}



			/// <summary>SkyrimSE.exe + 0x218CE0 (VID 16986)<br/>VTable + 0x1B8</summary>
			static public System.IntPtr Activate { get; }
		}

		static public class TESForm
		{
			static TESForm()
			{
				GetForm = NetScriptFramework.Main.GameInfo.GetAddressOf(14461);
			}



			/// <summary>SkyrimSE.exe + 0x194230 (VID 14461)</summary>
			static public System.IntPtr GetForm { get; }
		}

		static public class TESObjectCELL
		{
			static TESObjectCELL()
			{
				GetHavokWorld = NetScriptFramework.Main.GameInfo.GetAddressOf(18536);
			}



			/// <summary>SkyrimSE.exe + 0x2654C0 (VID 18536)</summary>
			static public System.IntPtr GetHavokWorld { get; }
		}

		static public class TESObjectREFR
		{
			static TESObjectREFR()
			{
				Activate =			NetScriptFramework.Main.GameInfo.GetAddressOf(19369);
				IsCrimeToActivate =	NetScriptFramework.Main.GameInfo.GetAddressOf(19400);
			}



			/// <summary>SkyrimSE.exe + 0x296C00 (VID 19369)</summary>
			static public System.IntPtr Activate { get; }

			/// <summary>SkyrimSE.exe + 0x29A330 (VID 19400)</summary>
			static public System.IntPtr IsCrimeToActivate { get; }
		}

		static public class TESObjectTREE
		{
			static TESObjectTREE()
			{
				Activate = NetScriptFramework.Main.GameInfo.GetAddressOf(17636);
			}



			/// <summary>SkyrimSE.exe + 0x231580 (VID 17636)<br/>VTable + 0x1B8</summary>
			static public System.IntPtr Activate { get; }
		}

		static public class TimeManager
		{
			static TimeManager()
			{
				Instance = NetScriptFramework.Main.GameInfo.GetAddressOf(523657);
			}



			/// <summary>SkyrimSE.exe + 0x2F6B930 (VID 523657)</summary>
			static public System.IntPtr Instance { get; }
		}

		static public class UI
		{
			static UI()
			{
				Instance =			NetScriptFramework.Main.GameInfo.GetAddressOf(514178);
				IsInMenuMode =		NetScriptFramework.Main.GameInfo.GetAddressOf(56476);
				IsInMenuModeBase =	NetScriptFramework.Main.GameInfo.GetAddressOf(516933);
				ShowMessageBox =	NetScriptFramework.Main.GameInfo.GetAddressOf(54737);
				ShowNotification =	NetScriptFramework.Main.GameInfo.GetAddressOf(54738);
			}



			/// <summary>SkyrimSE.exe + 0x1EBEB20 (VID 514178)</summary>
			static public System.IntPtr Instance { get; }

			/// <summary>SkyrimSE.exe + 0x9B8750 (VID 56476)</summary>
			static public System.IntPtr IsInMenuMode { get; }

			/// <summary>SkyrimSE.exe + 0x2F26B74 (VID 516933)</summary>
			static public System.IntPtr IsInMenuModeBase { get; }

			/// <summary>SkyrimSE.exe + 0x96DD60 (VID 54737)</summary>
			static public System.IntPtr ShowMessageBox { get; }

			/// <summary>SkyrimSE.exe + 0x96DDB0 (VID 54738)</summary>
			static public System.IntPtr ShowNotification { get; }
		}
	}
}
