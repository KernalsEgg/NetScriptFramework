using Eggstensions.Bethesda;



namespace QuickHarvest
{
	static public class Flags
	{
		public enum Visibility : System.Int32
		{
			All = 0,
			Unoccluded = 1,
			LineOfSight = 2
		}
	}



	sealed public class Settings
	{
		private NetScriptFramework.Tools.ConfigFile _configFile;



		public System.Boolean HarvestEverything { get; private set; }

		public System.Boolean LogHandledExceptions { get; private set; }

		public System.Boolean ShowHandledExceptions { get; private set; }

		public System.Boolean Steal { get; private set; }

		public System.Collections.Generic.HashSet<System.IntPtr> ExcludedIngredients { get; private set; }

		public System.Collections.Generic.List<FormTypes> IncludedIngredientFormTypes { get; private set; }

		public Flags.Visibility Visibility { get; private set; }

		public System.Single MaximumDistance { get; private set; }



		internal void Load()
		{
			_configFile = new NetScriptFramework.Tools.ConfigFile("QuickHarvest");

			_configFile.AddSetting
			(
				"HarvestEverything",
				new NetScriptFramework.Tools.Value(true),
				"Harvest Everything",
				"If enabled all ingredients will be quick harvested." +
				"\nIf disabled only the targeted ingredient will be quick harvested.",
				NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment
			);

			_configFile.AddSetting
			(
				"Steal",
				new NetScriptFramework.Tools.Value(false),
				"Steal",
				"If enabled ingredients will only be stolen when you steal." +
				"\nIf disabled ingredients will never be stolen.",
				NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment
			);

			_configFile.AddSetting
			(
				"Visibility",
				new NetScriptFramework.Tools.Value(1),
				"Visibility",
				"If set to 0 then all ingredients will be quick harvested" +
				"\nIf set to 1 then only ingredients not hidden behind walls or surfaces will be quick harvested." +
				"\nIf set to 2 then only ingredients within your line of sight will be quick harvested.",
				NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment
			);

			_configFile.AddSetting
			(
				"MaximumDistance",
				new NetScriptFramework.Tools.Value(2048.0f),
				"Maximum Distance",
				"The maximum distance at which ingredients will be quick harvested (Units)." +
				"\nFor reference, a cell is 4096 Units by 4096 Units.",
				NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment
			);

			_configFile.AddSetting
			(
				"LogHandledExceptions",
				new NetScriptFramework.Tools.Value(true),
				"Log Handled Exceptions",
				"Log handled exceptions to Data\\NetScriptFramework\\NetScriptFramework.log.txt.",
				NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment
			);

			_configFile.AddSetting
			(
				"ShowHandledExceptions",
				new NetScriptFramework.Tools.Value(false),
				"Show Handled Exceptions",
				"Show an in-game message box each time an exception is handled.",
				NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment
			);

			_configFile.AddSetting
			(
				"FormType0",
				new NetScriptFramework.Tools.Value(0x1Eu),
				"Form Type 0",
				"The form type of ingredients to include. Must be in hexadecimal notation." +
				"\nAmmo = 0x2A" +
				"\nArmor = 0x1A" +
				"\nBook = 0x1B" +
				"\nConstructible Object = 0x31" +
				"\nIngredient = 0x1E" +
				"\nKey = 0x2D" +
				"\nLeveled Item = 0x35" +
				"\nMisc Item = 0x20" +
				"\nPotion = 0x2E" +
				"\nScroll = 0x17" +
				"\nSoul Gem = 0x34" +
				"\nWeapon = 0x29",
				NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment | NetScriptFramework.Tools.ConfigEntryFlags.PreferHex
			);

			_configFile.AddSetting
			(
				"FormID0",
				new NetScriptFramework.Tools.Value(default(System.UInt32)),
				"Form ID 0",
				"The form ID of an ingredient to exclude. Must be in hexadecimal notation and without its load order index.",
				NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment | NetScriptFramework.Tools.ConfigEntryFlags.PreferHex
			);

			_configFile.AddSetting
			(
				"FileName0",
				new NetScriptFramework.Tools.Value(default(System.String)),
				"File Name 0",
				"The name of the file that the ingredient originates from, including the filename extension.",
				NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment
			);

			if (!_configFile.Load())
			{
				_configFile.Save();
			}

			var harvestEverythingValue = _configFile.GetValue("HarvestEverything");
			if (harvestEverythingValue == null) { throw new Eggceptions.NullException("harvestEverythingValue"); }
			HarvestEverything = harvestEverythingValue.ToBoolean();

			var stealValue = _configFile.GetValue("Steal");
			if (stealValue == null) { throw new Eggceptions.NullException("stealValue"); }
			Steal = stealValue.ToBoolean();

			var visibilityValue = _configFile.GetValue("Visibility");
			if (visibilityValue == null) { throw new Eggceptions.NullException("visibilityValue"); }
			Visibility = (Flags.Visibility)visibilityValue.ToInt32();

			var maximumDistanceValue = _configFile.GetValue("MaximumDistance");
			if (maximumDistanceValue == null) { throw new Eggceptions.NullException("maximumDistanceValue"); }
			MaximumDistance = maximumDistanceValue.ToSingle();

			var logHandledExceptionsValue = _configFile.GetValue("LogHandledExceptions");
			if (logHandledExceptionsValue == null) { throw new Eggceptions.NullException("logHandledExceptionsValue"); }
			LogHandledExceptions = logHandledExceptionsValue.ToBoolean();

			var showHandledExceptionsValue = _configFile.GetValue("ShowHandledExceptions");
			if (showHandledExceptionsValue == null) { throw new Eggceptions.NullException("showHandledExceptionsValue"); }
			ShowHandledExceptions = showHandledExceptionsValue.ToBoolean();

			ExcludedIngredients = new System.Collections.Generic.HashSet<System.IntPtr>();

			for (var index = 0ul; index <= System.UInt32.MaxValue; index++)
			{
				var formIDValue = _configFile.GetValue("FormID" + index);
				if (formIDValue == null) { break; }
				var formID = formIDValue.ToUInt32();

				var fileNameValue = _configFile.GetValue("FileName" + index);
				if (fileNameValue == null) { break; }
				var fileName = fileNameValue.ToString();
				if (System.String.IsNullOrWhiteSpace(fileName)) { break; }

				var form = TESForm.GetFormFromFile(formID, fileName);
				if (form == System.IntPtr.Zero) { throw new Eggceptions.Bethesda.FormNotFoundException("Form ID: " + formID.ToString("X8") + ", File Name: " + fileName); }

				ExcludedIngredients.Add(form);
			}

			IncludedIngredientFormTypes = new System.Collections.Generic.List<FormTypes>();

			for (var index = 0u; index <= System.Byte.MaxValue; index++)
			{
				var formTypeValue = _configFile.GetValue("FormType" + index);
				if (formTypeValue == null) { break; }

				IncludedIngredientFormTypes.Add((FormTypes)formTypeValue.ToByte());
			}
		}
	}
}
