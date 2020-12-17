using Eggstensions.Bethesda;



namespace QuickHarvest
{
	static public class Flags
	{
		public enum Visibility : System.Int32
		{
			All = 0,
			PanoramicView = 1,
			FieldOfView = 2
		}
	}



	static public class Settings
	{
		static Settings()
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
				"PlaySounds",
				new NetScriptFramework.Tools.Value(true),
				"Play Sounds",
				"Play sounds when quick harvesting.",
				NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment
			);

			_configFile.AddSetting
			(
				"ShowNotifications",
				new NetScriptFramework.Tools.Value(true),
				"ShowNotifications",
				"Show notifications when quick harvesting.",
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
				"\nIf set to 1 then only ingredients in your panoramic (360 degree) view will be quick harvested." +
				"\nIf set to 2 then only ingredients in your field of view will be quick harvested.",
				NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment
			);

			_configFile.AddSetting
			(
				"MaximumDistance",
				new NetScriptFramework.Tools.Value(1024.0f),
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
				"IncludedFormType0",
				new NetScriptFramework.Tools.Value(0x1Eu),
				"Included Form Type 0",
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
				"ExcludedFormID0",
				new NetScriptFramework.Tools.Value(default(System.UInt32)),
				"Excluded Form ID 0",
				"The form ID of an ingredient to exclude. Must be in hexadecimal notation and without its load order index.",
				NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment | NetScriptFramework.Tools.ConfigEntryFlags.PreferHex
			);

			_configFile.AddSetting
			(
				"ExcludedFileName0",
				new NetScriptFramework.Tools.Value(default(System.String)),
				"Excluded File Name 0",
				"The name of the file that the ingredient originates from, including the filename extension.",
				NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment
			);

			_configFile.AddSetting
			(
				"IncludedFormID0",
				new NetScriptFramework.Tools.Value(default(System.UInt32)),
				"Included Form ID 0",
				"The form ID of an ingredient to exclude. Must be in hexadecimal notation and without its load order index." +
				"\nThis is unnecessary if the ingredient has an included form type.",
				NetScriptFramework.Tools.ConfigEntryFlags.VeryShortComment | NetScriptFramework.Tools.ConfigEntryFlags.PreferHex
			);

			_configFile.AddSetting
			(
				"IncludedFileName0",
				new NetScriptFramework.Tools.Value(default(System.String)),
				"Included File Name 0",
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

			var playSoundsValue = _configFile.GetValue("PlaySounds");
			if (playSoundsValue == null) { throw new Eggceptions.NullException("playSoundsValue"); }
			PlaySounds = playSoundsValue.ToBoolean();

			var showNotificationsValue = _configFile.GetValue("ShowNotifications");
			if (showNotificationsValue == null) { throw new Eggceptions.NullException("showNotificationsValue"); }
			ShowNotifications = showNotificationsValue.ToBoolean();

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

			IncludedIngredientFormTypes = new System.Collections.Generic.List<FormTypes>();

			for (var index = 0u; index <= System.Byte.MaxValue; index++)
			{
				var includedFormTypeValue = _configFile.GetValue("IncludedFormType" + index);
				if (includedFormTypeValue == null) { break; }
				var includedFormType = (FormTypes)includedFormTypeValue.ToByte();

				IncludedIngredientFormTypes.Add(includedFormType);
			}

			ExcludedIngredients = new System.Collections.Generic.HashSet<System.IntPtr>();

			for (var index = 0ul; index <= System.UInt32.MaxValue; index++)
			{
				var excludedFormIDValue = _configFile.GetValue("ExcludedFormID" + index);
				if (excludedFormIDValue == null) { break; }
				var excludedFormID = excludedFormIDValue.ToUInt32();

				var excludedFileNameValue = _configFile.GetValue("ExcludedFileName" + index);
				if (excludedFileNameValue == null) { break; }
				var excludedFileName = excludedFileNameValue.ToString();
				if (System.String.IsNullOrWhiteSpace(excludedFileName)) { break; }

				var excludedForm = TESForm.GetFormFromFile(excludedFormID, excludedFileName);
				if (excludedForm == System.IntPtr.Zero) { throw new Eggceptions.Bethesda.FormNotFoundException("Form ID: " + excludedFormID.ToString("X8") + ", File Name: " + excludedFileName); }

				ExcludedIngredients.Add(excludedForm);
			}

			IncludedIngredients = new System.Collections.Generic.HashSet<System.IntPtr>();

			for (var index = 0ul; index <= System.UInt32.MaxValue; index++)
			{
				var includedFormIDValue = _configFile.GetValue("IncludedFormID" + index);
				if (includedFormIDValue == null) { break; }
				var includedFormID = includedFormIDValue.ToUInt32();

				var includedFileNameValue = _configFile.GetValue("IncludedFileName" + index);
				if (includedFileNameValue == null) { break; }
				var includedFileName = includedFileNameValue.ToString();
				if (System.String.IsNullOrWhiteSpace(includedFileName)) { break; }

				var includedForm = TESForm.GetFormFromFile(includedFormID, includedFileName);
				if (includedForm == System.IntPtr.Zero) { throw new Eggceptions.Bethesda.FormNotFoundException("Form ID: " + includedFormID.ToString("X8") + ", File Name: " + includedFileName); }

				IncludedIngredients.Add(includedForm);
			}
		}



		readonly static private NetScriptFramework.Tools.ConfigFile _configFile;



		static public System.Boolean HarvestEverything { get; private set; }

		static public System.Boolean LogHandledExceptions { get; private set; }

		static public System.Boolean ShowHandledExceptions { get; private set; }

		static public System.Boolean PlaySounds { get; private set; }

		static public System.Boolean ShowNotifications { get; private set; }

		static public System.Boolean Steal { get; private set; }

		static public System.Collections.Generic.HashSet<System.IntPtr> ExcludedIngredients { get; private set; }

		static public System.Collections.Generic.HashSet<System.IntPtr> IncludedIngredients { get; private set; }

		static public System.Collections.Generic.List<FormTypes> IncludedIngredientFormTypes { get; private set; }

		static public Flags.Visibility Visibility { get; private set; }

		static public System.Single MaximumDistance { get; private set; }
	}
}
