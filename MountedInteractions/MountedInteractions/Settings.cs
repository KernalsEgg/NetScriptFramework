namespace MountedInteractions
{
	public class Settings
	{
		[NetScriptFramework.Tools.ConfigValue("ActivateDistance", "ActivateDistance", "Activation distance while mounted.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Single ActivateDistance { get; private set; } = 2048.0f;

		[NetScriptFramework.Tools.ConfigValue("WeaponDrawnOffsetX", "Weapon Drawn Offset X", "Camera offset along the x-axis while mounted with your weapon drawn.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Single WeaponDrawnOffsetX { get; private set; } = 0.0f; // 0.0f

		[NetScriptFramework.Tools.ConfigValue("WeaponDrawnOffsetY", "Weapon Drawn Offset Y", "Camera offset along the y-axis while mounted with your weapon drawn.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Single WeaponDrawnOffsetY { get; private set; } = -150.0f; // -150.0f

		[NetScriptFramework.Tools.ConfigValue("WeaponDrawnOffsetZ", "Weapon Drawn Offset Z", "Camera offset along the z-axis while mounted with your weapon drawn.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Single WeaponDrawnOffsetZ { get; private set; } = 90.0f; // 90.0f

		[NetScriptFramework.Tools.ConfigValue("WeaponSheathedOffsetX", "Weapon Sheathed Offset X", "Camera offset along the x-axis while mounted with your weapon sheathed.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Single WeaponSheathedOffsetX { get; private set; } = 0.0f; // 0.0f

		[NetScriptFramework.Tools.ConfigValue("WeaponSheathedOffsetY", "Weapon Sheathed Offset Y", "Camera offset along the y-axis while mounted with your weapon sheathed.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Single WeaponSheathedOffsetY { get; private set; } = -150.0f; // -300.0f

		[NetScriptFramework.Tools.ConfigValue("WeaponSheathedOffsetZ", "Weapon Sheathed Offset Z", "Camera offset along the z-axis while mounted with your weapon sheathed.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Single WeaponSheathedOffsetZ { get; private set; } = 90.0f; // 0.0f



		internal void Load()
		{
			NetScriptFramework.Tools.ConfigFile.LoadFrom<Settings>(this, "MountedInteractions", true);
		}
	}
}
