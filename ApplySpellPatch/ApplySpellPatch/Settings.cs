namespace ApplySpellPatch
{
	public class Settings
	{
		[NetScriptFramework.Tools.ConfigValue("LogHandledExceptions", "Log Handled Exceptions", "Log handled exceptions to Data\\NetScriptFramework\\NetScriptFramework.log.txt.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Boolean LogHandledExceptions { get; private set; } = true;

		[NetScriptFramework.Tools.ConfigValue("ShowHandledExceptions", "Show Handled Exceptions", "Show an in-game message box when an exception is handled.", NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment)]
		public System.Boolean ShowHandledExceptions { get; private set; } = false;



		internal void Load()
		{
			NetScriptFramework.Tools.ConfigFile.LoadFrom<Settings>(this, "ApplySpellPatch", true);
		}
	}
}
