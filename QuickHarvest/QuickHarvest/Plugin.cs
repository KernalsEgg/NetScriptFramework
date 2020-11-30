using Eggstensions.Bethesda;



namespace QuickHarvest
{
    public class Plugin : NetScriptFramework.Plugin
    {
		override public System.String Author
		{
			get
			{
				return "meh321 and KernalsEgg";
			}
		}

		override public System.String Key
		{
			get
			{
				return "QuickHarvest";
			}
		}

		override public System.String Name
		{
			get
			{
				return "Quick Harvest";
			}
		}

		override public System.Int32 RequiredLibraryVersion
		{
			get
			{
				return 10;
			}
		}

		override public System.Int32 Version
		{
			get
			{
				return 1;
			}
		}



		override protected System.Boolean Initialize(System.Boolean loadedAny)
		{
			// loadedAny

			NetScriptFramework.SkyrimSE.Events.OnMainMenu.Register(arguments => { _settings = new Settings(); _settings.Load(); });
			Events.ActivateFloraEvent.Register(OnActivateFlora);
			Events.ActivateTreeEvent.Register(OnActivateTree);

			return true;
		}



		static private System.Int32 _harvesting = 0;

		static private System.String _messageBox =
			"Quick Harvest has thrown an exception." +
			"\nDetails are logged to Data\\NetScriptFramework\\NetScriptFramework.log.txt.";



		static internal Settings _settings;



		public void OnActivateFlora(Events.ActivateFloraEventArguments arguments)
		{
			if (arguments == null) { throw new Eggceptions.ArgumentNullException("arguments"); }

			if (System.Threading.Interlocked.Exchange(ref _harvesting, 1) == 0)
			{
				try
				{
					QuickHarvest(TESFlora.GetIngredient(arguments.BaseForm), arguments.Target, arguments.Activator);
				}
				catch (Eggceptions.Eggception eggception)
				{
					if (_settings.LogHandledExceptions) { NetScriptFramework.Main.Log.Append(eggception); }
					if (_settings.ShowHandledExceptions) { UI.ShowMessageBox(_messageBox); }
				}

				System.Threading.Interlocked.Exchange(ref _harvesting, 0);
			}
		}

		public void OnActivateTree(Events.ActivateTreeEventArguments arguments)
		{
			if (arguments == null) { throw new Eggceptions.ArgumentNullException("arguments"); }

			if (System.Threading.Interlocked.Exchange(ref _harvesting, 1) == 0)
			{
				try
				{
					QuickHarvest(TESObjectTREE.GetIngredient(arguments.BaseForm), arguments.Target, arguments.Activator);
				}
				catch (Eggceptions.Eggception eggception)
				{
					if (_settings.LogHandledExceptions) { NetScriptFramework.Main.Log.Append(eggception); }
					if (_settings.ShowHandledExceptions) { UI.ShowMessageBox(_messageBox); }
				}

				System.Threading.Interlocked.Exchange(ref _harvesting, 0);
			}
		}

		public void QuickHarvest(System.IntPtr ingredient, System.IntPtr target, System.IntPtr activator)
		{
			// ingredient
			if (target == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("target"); }
			if (activator == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("activator"); }

			if (activator != PlayerCharacter.Instance) { return; }
			if (ingredient == System.IntPtr.Zero) { return; }
			if (!_settings.IncludedIngredientFormTypes.Contains(TESForm.GetFormType(ingredient))) { return; }
			if (_settings.ExcludedIngredients.Contains(ingredient)) { return; }
			if (TESObjectREFR.IsHarvested(target)) { return; }

			var stealing = TESObjectREFR.IsCrimeToActivate(target);
			if (!_settings.Steal && stealing) { return; }

			foreach (var loadedCell in TES.LoadedCells)
			{
				(var loadedFloras, var loadedTrees) = TESObjectCELL.GetReferences(loadedCell, FormTypes.TESFlora, FormTypes.TESObjectTREE);

				foreach (var loadedFlora in loadedFloras)
				{
					if (loadedFlora == target) { continue; }
					
					var loadedIngredient = TESFlora.GetIngredient(TESObjectREFR.GetBaseForm(loadedFlora));
					if (loadedIngredient == System.IntPtr.Zero) { continue; }

					if (_settings.HarvestEverything)
					{
						if (!_settings.IncludedIngredientFormTypes.Contains(TESForm.GetFormType(loadedIngredient))) { continue; }
						if (_settings.ExcludedIngredients.Contains(loadedIngredient)) { continue; }
					}
					else
					{
						if (loadedIngredient != ingredient) { continue; } // The loaded ingredient has an included form type and has not been excluded
					}

					if (TESObjectREFR.IsHarvested(loadedFlora)) { continue; }
					if (TESObjectREFR.GetDistanceBetween(loadedFlora, activator) > _settings.MaximumDistance) { continue; }
					if (TESObjectREFR.IsCrimeToActivate(loadedFlora) != stealing) { continue; }
					if (_settings.LineOfSight && !PlayerCharacter.HasLineOfSight(activator, loadedFlora)) { continue; }

					TESObjectREFR.Activate(loadedFlora, activator);
				}

				foreach (var loadedTree in loadedTrees)
				{
					if (loadedTree == target) { continue; }

					var loadedIngredient = TESObjectTREE.GetIngredient(TESObjectREFR.GetBaseForm(loadedTree));
					if (loadedIngredient == System.IntPtr.Zero) { continue; }

					if (_settings.HarvestEverything)
					{
						if (!_settings.IncludedIngredientFormTypes.Contains(TESForm.GetFormType(loadedIngredient))) { continue; }
						if (_settings.ExcludedIngredients.Contains(loadedIngredient)) { continue; }
					}
					else
					{
						if (loadedIngredient != ingredient) { continue; } // The loaded ingredient has an included form type and has not been excluded
					}

					if (TESObjectREFR.IsHarvested(loadedTree)) { continue; }
					if (TESObjectREFR.GetDistanceBetween(loadedTree, activator) > _settings.MaximumDistance) { continue; }
					if (TESObjectREFR.IsCrimeToActivate(loadedTree) != stealing) { continue; }
					if (_settings.LineOfSight && !PlayerCharacter.HasLineOfSight(activator, loadedTree)) { continue; }

					TESObjectREFR.Activate(loadedTree, activator);
				}
			}
		}
	}
}
