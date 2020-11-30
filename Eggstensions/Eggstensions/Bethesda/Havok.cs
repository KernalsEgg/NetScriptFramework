﻿namespace Eggstensions.Bethesda
{
	public enum CollisionLayers : System.UInt32
	{
		Unidentified =			0x0u,
		Static =				0x1u,
		AnimStatic =			0x2u,
		Transparent =			0x3u,
		Clutter =				0x4u,
		Weapon =				0x5u,
		Projectile =			0x6u,
		Spell =					0x7u,
		Biped =					0x8u,
		Trees =					0x9u,
		Props =					0xAu,
		Water =					0xBu,
		Trigger =				0xCu,
		Terrain =				0xDu,
		Trap =					0xEu,
		NonCollidable =			0xFu,
		CloudTrap =				0x10u,
		Ground =				0x11u,
		Portal =				0x12u,
		DebrisSmall =			0x13u,
		DebrisLarge =			0x14u,
		AcousticSpace =			0x15u,
		ActorZone =				0x16u,
		ProjectileZone =		0x17u,
		GasTrap =				0x18u,
		ShellCasing =			0x19u,
		TransparentSmall =		0x1Au,
		InvisibleWall =			0x1Bu,
		TransparentSmallAnim =	0x1Cu,
		Ward =					0x1Du,
		CharController =		0x1Eu,
		StairHelper =			0x1Fu,
		DeadBip =				0x20u,
		BipedNoCC =				0x21u,
		AvoidBox =				0x22u,
		CollisionBox =			0x23u,
		CameraSphere =			0x24u,
		DoorDetection =			0x25u,
		ConeProjectile =		0x26u,
		Camera =				0x27u,
		ItemPicker =			0x28u,
		LOS =					0x29u,
		PathPicking =			0x2Au,
		CustomPick1 =			0x2Bu,
		CustomPick2 =			0x2Cu,
		SpellExplosion =		0x2Du,
		DroppingPick =			0x2Eu,
		DeadActorZone =			0x2Fu,
		TriggerFallingTrap =	0x30u,
		NavCut =				0x31u,
		Critter =				0x32u,
		SpellTrigger =			0x33u,
		LivingAndDeadActors =	0x34u,
		Detection =				0x35u,
		TrapTrigger =			0x36u
	}



	static public class Havok
	{
		static public System.Single HavokWorldScale { get; } = 0.0142875f;



		/// <param name="havokObject">HavokObject</param>
		static public CollisionLayers GetCollisionLayer(System.IntPtr havokObject)
		{
			if (havokObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("havokObject"); }

			return (CollisionLayers)(NetScriptFramework.Memory.ReadUInt32(havokObject + 0x2C) & 0x7F);
		}

		/// <summary>&lt;SkyrimSE.exe&gt; + 0xDAD060 (VID76160)</summary>
		/// <param name="havokObject">HavokObject</param>
		/// <returns>NiObject, System.IntPtr.Zero</returns>
		static public System.IntPtr GetNiObjectFromHavokObject(System.IntPtr havokObject)
		{
			if (havokObject == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("havokObject"); }

			var functionAddress = NetScriptFramework.Main.GameInfo.GetAddressOf(76160);
			if (functionAddress == System.IntPtr.Zero) { throw new Eggceptions.NullException("functionAddress"); }

			return NetScriptFramework.Memory.InvokeCdecl(functionAddress, havokObject);
		}
	}
}
