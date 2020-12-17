using System.Linq;

using Eggstensions.Bethesda;



namespace QuickHarvest
{
    public class Plugin : NetScriptFramework.Plugin
	{
		override public System.Int32 RequiredLibraryVersion	{ get { return 10; } }

		override public System.Int32 Version				{ get { return 1; } }

		override public System.String Author				{ get { return "meh321 and KernalsEgg"; } }

		override public System.String Key					{ get { return "QuickHarvest"; } }

		override public System.String Name					{ get { return "Quick Harvest"; } }



		override protected System.Boolean Initialize(System.Boolean loadedAny)
		{
			// loadedAny

			NetScriptFramework.SkyrimSE.Events.OnMainMenu.Register
			(arguments =>
			{
				if (arguments == null) { throw new Eggceptions.ArgumentNullException("arguments"); }

				if (arguments.Entering)
				{
					_collisionLayers = Plugin.GetCollisionLayers();
				}
			});
			Events.ActivateFloraEvent.Register(OnActivateFlora);
			Events.ActivateTreeEvent.Register(OnActivateTree);
			Events.PlayHarvestSoundEvent.Register(OnPlayHarvestSound);
			Events.ShowHarvestNotificationEvent.Register(OnShowHarvestNotification);

			return true;
		}



		readonly static private System.String _messageBox =
			"Quick Harvest has thrown an exception." +
			"\nDetails are logged to Data\\NetScriptFramework\\NetScriptFramework.log.txt.";



		static private CollisionLayers[] _collisionLayers;

		static private System.Int32 _harvesting = 0;



		static private CollisionLayers[] GetCollisionLayers()
		{
			var los = TESForm.GetFormFromFile(0x8878A, "Skyrim.esm");
			if (los == System.IntPtr.Zero) { throw new Eggceptions.NullException("los"); }
			if (!TESForm.HasFormType(los, FormTypes.BGSCollisionLayer)) { throw new Eggceptions.Bethesda.FormTypeException("los"); }

			var collidesWith = BSTArray.IntPtr(BGSCollisionLayer.GetCollidesWith(los));
			var collisionLayers =
				from collisionLayer in collidesWith
				select BGSCollisionLayer.GetCollisionLayer(collisionLayer);

			return collisionLayers.ToArray<CollisionLayers>();
		}

		static public void OnActivateFlora(Events.ActivateFloraEventArguments arguments)
		{
			if (arguments == null) { throw new Eggceptions.ArgumentNullException("arguments"); }

			if (System.Threading.Interlocked.Exchange(ref _harvesting, 1) == 0)
			{
				try
				{
					Plugin.QuickHarvest(TESFlora.GetIngredient(arguments.BaseForm), arguments.Target, arguments.Activator);
				}
				catch (Eggceptions.Eggception eggception)
				{
					if (Settings.LogHandledExceptions) { NetScriptFramework.Main.Log.Append(eggception); }
					if (Settings.ShowHandledExceptions) { UI.ShowMessageBox(_messageBox); }
				}

				System.Threading.Interlocked.Exchange(ref _harvesting, 0);
			}
		}

		static public void OnActivateTree(Events.ActivateTreeEventArguments arguments)
		{
			if (arguments == null) { throw new Eggceptions.ArgumentNullException("arguments"); }

			if (System.Threading.Interlocked.Exchange(ref _harvesting, 1) == 0)
			{
				try
				{
					Plugin.QuickHarvest(TESObjectTREE.GetIngredient(arguments.BaseForm), arguments.Target, arguments.Activator);
				}
				catch (Eggceptions.Eggception eggception)
				{
					if (Settings.LogHandledExceptions) { NetScriptFramework.Main.Log.Append(eggception); }
					if (Settings.ShowHandledExceptions) { UI.ShowMessageBox(_messageBox); }
				}

				System.Threading.Interlocked.Exchange(ref _harvesting, 0);
			}
		}

		static public void QuickHarvest(System.IntPtr ingredient, System.IntPtr target, System.IntPtr activator)
		{
			// ingredient
			if (target == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("target"); }
			if (activator == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("activator"); }

			if (activator != PlayerCharacter.Instance) { return; }
			if (ingredient == System.IntPtr.Zero) { return; }
			if (!Settings.IncludedIngredientFormTypes.Contains(TESForm.GetFormType(ingredient)) && !Settings.IncludedIngredients.Contains(ingredient)) { return; }
			if (Settings.ExcludedIngredients.Contains(ingredient)) { return; }
			if (TESObjectREFR.IsHarvested(target)) { return; }

			var stealing = TESObjectREFR.IsCrimeToActivate(target);
			if (!Settings.Steal && stealing) { return; }

			foreach (var loadedCell in TES.GetLoadedCells(TES.Instance))
			{
				(var loadedFloras, var loadedTrees) = TESObjectCELL.GetReferences(loadedCell, FormTypes.TESFlora, FormTypes.TESObjectTREE);

				foreach (var loadedFlora in loadedFloras)
				{
					if (loadedFlora == target) { continue; }
					
					var loadedIngredient = TESFlora.GetIngredient(TESObjectREFR.GetBaseForm(loadedFlora));
					if (loadedIngredient == System.IntPtr.Zero) { continue; }

					if (Settings.HarvestEverything)
					{
						if (!Settings.IncludedIngredientFormTypes.Contains(TESForm.GetFormType(loadedIngredient)) && !Settings.IncludedIngredients.Contains(loadedIngredient)) { continue; }
						if (Settings.ExcludedIngredients.Contains(loadedIngredient)) { continue; }
					}
					else
					{
						if (loadedIngredient != ingredient) { continue; } // The loaded ingredient has an included form type and has not been excluded
					}

					if (TESObjectREFR.IsHarvested(loadedFlora)) { continue; }
					if (TESObjectREFR.GetDistanceBetween(loadedFlora, activator) > Settings.MaximumDistance) { continue; }
					if (TESObjectREFR.IsCrimeToActivate(loadedFlora) != stealing) { continue; }
					if (!Plugin.Visibility(activator, loadedFlora)) { continue; }

					TESObjectREFR.Activate(loadedFlora, activator);
				}

				foreach (var loadedTree in loadedTrees)
				{
					if (loadedTree == target) { continue; }

					var loadedIngredient = TESObjectTREE.GetIngredient(TESObjectREFR.GetBaseForm(loadedTree));
					if (loadedIngredient == System.IntPtr.Zero) { continue; }

					if (Settings.HarvestEverything)
					{
						if (!Settings.IncludedIngredientFormTypes.Contains(TESForm.GetFormType(loadedIngredient)) && !Settings.IncludedIngredients.Contains(loadedIngredient)) { continue; }
						if (Settings.ExcludedIngredients.Contains(loadedIngredient)) { continue; }
					}
					else
					{
						if (loadedIngredient != ingredient) { continue; } // The loaded ingredient has an included form type and has not been excluded
					}

					if (TESObjectREFR.IsHarvested(loadedTree)) { continue; }
					if (TESObjectREFR.GetDistanceBetween(loadedTree, activator) > Settings.MaximumDistance) { continue; }
					if (TESObjectREFR.IsCrimeToActivate(loadedTree) != stealing) { continue; }
					if (!Plugin.Visibility(activator, loadedTree)) { continue; }

					TESObjectREFR.Activate(loadedTree, activator);
				}
			}
		}

		static private System.Boolean Visibility(System.IntPtr viewer, System.IntPtr target)
		{
			if (viewer == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("viewer"); }
			if (target == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("target"); }

			switch (Settings.Visibility)
			{
				case Flags.Visibility.PanoramicView:
					return !TESObjectREFR.IsOccluded(viewer, target, _collisionLayers);
				case Flags.Visibility.FieldOfView:
					return PlayerCharacter.HasLineOfSight(viewer, target);
				default:
					return true;
			}
		}

		static public void OnPlayHarvestSound(Events.PlayHarvestSoundEventArguments arguments)
		{
			arguments.Skip =
				(_harvesting != 0)
				&&
				!Settings.PlaySounds;
		}

		static public void OnShowHarvestNotification(Events.ShowHarvestNotificationEventArguments arguments)
		{
			arguments.Skip =
				(_harvesting != 0)
				&&
				!Settings.ShowNotifications;
		}
	}
}
