using Eggstensions.Bethesda;



namespace ShelterFramework
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
				return "ShelterFramework";
			}
		}

		override public System.String Name
		{
			get
			{
				return "Shelter Framework";
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



		// Exceptions
		//	GetParentCell: The Subject is not in a loaded cell
		//	GetHavokWorld: The Subject is not in the loaded world space
		override protected System.Boolean Initialize(System.Boolean loadedAny)
		{
			// loadedAny

			_settings = new Settings();
			_settings.Load();

			Events.GetIsCreatureTypeEvent.Register(OnGetIsCreatureType);

			return true;
		}



		readonly static private CollisionLayers[] _collisionLayers = new CollisionLayers[]
		{
			CollisionLayers.AnimStatic,
			CollisionLayers.Ground,
			CollisionLayers.Static,
			CollisionLayers.Terrain,
			CollisionLayers.Trees
		};

		readonly static private System.String _messageBox =
			"Shelter Framework has thrown an exception." +
			"\nDetails are logged to Data\\NetScriptFramework\\NetScriptFramework.log.txt.";



		static private Settings _settings;
		
		static private System.Collections.Generic.Dictionary<System.IntPtr, (System.Single lastUpdate, System.Boolean isSheltered)> _isShelteredCache =
			new System.Collections.Generic.Dictionary<System.IntPtr, (System.Single, System.Boolean)>();



		static private void OnGetIsCreatureType(Events.GetIsCreatureTypeEventArguments arguments)
		{
			if (arguments == null) { throw new Eggceptions.ArgumentNullException("arguments"); }

			try
			{
				var detectShelter = System.Convert.ToBoolean(arguments.Argument1);
				var isSheltered = Plugin.IsSheltered(arguments.Subject);

				arguments.Text = detectShelter ? "Is Sheltered >> %0.2f" : "Is Exposed >> %0.2f";
				arguments.Result = (isSheltered == detectShelter) ? 1.0d : 0.0d;
			}
			catch (Eggceptions.Eggception eggception)
			{
				if (_settings.LogHandledExceptions) { NetScriptFramework.Main.Log.Append(eggception); }
				if (_settings.ShowHandledExceptions) { UI.ShowMessageBox(_messageBox); }
			}
		}



		static private System.Boolean IsSheltered(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			return TESForm.HasFormType(reference, FormTypes.Character) ? Plugin.IsShelteredActor(reference) : Plugin.IsShelteredReference(reference);
		}
		
		/// <param name="reference">TESObjectREFR</param>
		static private System.Boolean IsShelteredActor(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			var lastUpdate = Actor.GetLastUpdate(reference);

			if (!_isShelteredCache.TryGetValue(reference, out var isShelteredCache) || lastUpdate != isShelteredCache.lastUpdate)
			{
				_isShelteredCache[reference] = (lastUpdate, TESObjectREFR.IsHit(reference, TESObjectREFR.GetLookAtPosition(reference), Plugin.GetRay(), _collisionLayers));
			}

			return _isShelteredCache[reference].isSheltered;
		}

		static private System.Boolean IsShelteredReference(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			return TESObjectREFR.IsHit(reference, TESObjectREFR.GetLookAtPosition(reference), Plugin.GetRay(), _collisionLayers);
		}

		static private (System.Single x, System.Single y, System.Single z) GetRay()
		{
			var currentPrecipitationObject = Precipitation.GetCurrentPrecipitationObject(Sky.GetPrecipitation(Sky.Instance));

			if (currentPrecipitationObject != System.IntPtr.Zero && !NiAVObject.IsHidden(currentPrecipitationObject))
			{
				var bsParticleShaderProperty = BSGeometry.GetProperties(currentPrecipitationObject, BSGeometry.States.Effect);

				if (bsParticleShaderProperty != System.IntPtr.Zero)
				{
					var bsParticleShaderCubeEmitter = BSParticleShaderProperty.GetParticleShaderEmitter(bsParticleShaderProperty);

					if (bsParticleShaderCubeEmitter != System.IntPtr.Zero)
					{
						var precipitationVelocity = BSParticleShaderCubeEmitter.GetVelocity(bsParticleShaderCubeEmitter);

						if (precipitationVelocity != (0.0f, 0.0f, 0.0f))
						{
							return Plugin.Negate(Plugin.SetLength(precipitationVelocity, _settings.RayCastLength));
						}
					}
				}
			}

			return (0.0f, 0.0f, _settings.RayCastLength);
		}

		static private (System.Single x, System.Single y, System.Single z) SetLength((System.Single x, System.Single y, System.Single z) vector, System.Single length)
		{
			// vector
			// length

			var multiplier = (float)System.Math.Sqrt((length * length) / ((vector.x * vector.x) + (vector.y * vector.y) + (vector.z * vector.z)));

			return (vector.x * multiplier, vector.y * multiplier, vector.z * multiplier);
		}

		static private (System.Single x, System.Single y, System.Single z) Negate((System.Single x, System.Single y, System.Single z) vector)
		{
			// vector

			return (-vector.x, -vector.y, -vector.z);
		}
	}
}
