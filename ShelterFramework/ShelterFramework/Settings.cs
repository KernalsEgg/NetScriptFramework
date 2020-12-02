namespace ShelterFramework
{
	class Settings
	{
		[NetScriptFramework.Tools.ConfigValue("LogHandledExceptions", "Log Handled Exceptions", "Log handled exceptions to Data\\NetScriptFramework\\NetScriptFramework.log.txt.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Boolean LogHandledExceptions { get; private set; } = false;

		[NetScriptFramework.Tools.ConfigValue("ShowHandledExceptions", "Show Handled Exceptions", "Show an in-game message box each time an exception is handled.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Boolean ShowHandledExceptions { get; private set; } = false;

		[NetScriptFramework.Tools.ConfigValue("RayCastLength", "Ray Cast Length", "The length of the raycast vector used to detect shelter.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Single RayCastLength { get; private set; } = 2048.0f;



		internal void Load()
		{
			NetScriptFramework.Tools.ConfigFile.LoadFrom<Settings>(this, "ShelterFramework", true);
		}
	}
}
