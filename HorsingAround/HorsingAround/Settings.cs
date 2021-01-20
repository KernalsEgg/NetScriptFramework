namespace HorsingAround
{
	public class Settings
	{
		[NetScriptFramework.Tools.ConfigValue("DismountBySneaking", "Dismount By Sneaking", "Dismount from horseback by releasing the sneak button instead of the activate button.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Boolean DismountBySneaking { get; private set; } =				true;

		[NetScriptFramework.Tools.ConfigValue("ActivateDistance", "Activate Distance", "Maximum activation distance while on horseback.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Single ActivateDistance { get; private set; } =					270.0f; // 180.0f

		[NetScriptFramework.Tools.ConfigValue("WeaponDrawnOffsetX", "Weapon Drawn Offset X", "Camera offset along the x-axis while on horseback with your weapon drawn.\nIncreasing this value moves the camera rightwards.\nDecreasing this value moves the camera leftwards.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Single WeaponDrawnOffsetX { get; private set; } =					0.0f; // 0.0f

		[NetScriptFramework.Tools.ConfigValue("WeaponDrawnOffsetY", "Weapon Drawn Offset Y", "Camera offset along the y-axis while on horseback with your weapon drawn.\nIncreasing this value moves the camera forwards.\nDecreasing this value moves the camera backwards.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Single WeaponDrawnOffsetY { get; private set; } =					-150.0f; // -150.0f

		[NetScriptFramework.Tools.ConfigValue("WeaponDrawnOffsetZ", "Weapon Drawn Offset Z", "Camera offset along the z-axis while on horseback with your weapon drawn.\nIncreasing this value moves the camera upwards.\nDecreasing this value moves the camera downwards.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Single WeaponDrawnOffsetZ { get; private set; } =					90.0f; // 90.0f

		[NetScriptFramework.Tools.ConfigValue("WeaponDrawnRotationBackwards", "Weapon Drawn Rotation Backwards", "Maximum backwards camera rotation while on horseback with your weapon drawn.\nIncreasing this value allows you to rotate the camera further backwards.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Single WeaponDrawnRotationBackwards { get; private set; } =		25.0f; // 25.0f

		[NetScriptFramework.Tools.ConfigValue("WeaponDrawnRotationForwards", "Weapon Drawn Rotation Forwards", "Maximum forwards camera rotation while on horseback with your weapon drawn.\nIncreasing this value allows you to rotate the camera further forwards.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Single WeaponDrawnRotationForwards { get; private set; } =		90.0f; // 30.0f

		[NetScriptFramework.Tools.ConfigValue("WeaponSheathedOffsetX", "Weapon Sheathed Offset X", "Camera offset along the x-axis while on horseback with your weapon sheathed.\nIncreasing this value moves the camera rightwards.\nDecreasing this value moves the camera leftwards.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Single WeaponSheathedOffsetX { get; private set; } =				0.0f; // 0.0f

		[NetScriptFramework.Tools.ConfigValue("WeaponSheathedOffsetY", "Weapon Sheathed Offset Y", "Camera offset along the y-axis while on horseback with your weapon sheathed.\nIncreasing this value moves the camera forwards.\nDecreasing this value moves the camera backwards.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Single WeaponSheathedOffsetY { get; private set; } =				-150.0f; // -300.0f

		[NetScriptFramework.Tools.ConfigValue("WeaponSheathedOffsetZ", "Weapon Sheathed Offset Z", "Camera offset along the z-axis while on horseback with your weapon sheathed.\nIncreasing this value moves the camera rightwards.\nDecreasing this value moves the camera leftwards.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Single WeaponSheathedOffsetZ { get; private set; } =				90.0f; // 0.0f

		[NetScriptFramework.Tools.ConfigValue("WeaponSheathedRotationBackwards", "Weapon Sheathed Rotation Backwards", "Maximum backwards camera rotation while on horseback with your weapon sheathed.\nIncreasing this value allows you to rotate the camera further backwards.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Single WeaponSheathedRotationBackwards { get; private set; } =	25.0f; // 25.0f

		[NetScriptFramework.Tools.ConfigValue("WeaponSheathedRotationForwards", "Weapon Sheathed Rotation Forwards", "Maximum forwards camera rotation while on horseback with your weapon sheathed.\nIncreasing this value allows you to rotate the camera further forwards.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Single WeaponSheathedRotationForwards { get; private set; } =		90.0f; // 90.0f



		internal void Load()
		{
			NetScriptFramework.Tools.ConfigFile.LoadFrom<Settings>(this, "HorsingAround", true);
		}
	}
}
