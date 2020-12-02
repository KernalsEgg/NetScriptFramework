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
				var isSheltered = Plugin.IsShelteredCache(arguments.Subject);

				arguments.Text = detectShelter ? "Is Sheltered >> %0.2f" : "Is Exposed >> %0.2f";
				arguments.Result = (isSheltered == detectShelter) ? 1.0d : 0.0d;
			}
			catch (Eggceptions.Eggception eggception)
			{
				if (_settings.LogHandledExceptions) { NetScriptFramework.Main.Log.Append(eggception); }
				if (_settings.ShowHandledExceptions) { UI.ShowMessageBox(_messageBox); }
			}
		}

		/// <param name="reference">TESObjectREFR</param>
		static private System.Boolean IsShelteredCache(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			var lastUpdate = Actor.GetLastUpdate(reference);

			if (!_isShelteredCache.TryGetValue(reference, out var isShelteredCachedValue) || lastUpdate != isShelteredCachedValue.lastUpdate)
			{
				_isShelteredCache[reference] = (lastUpdate, Plugin.IsSheltered(reference));
			}

			return _isShelteredCache[reference].isSheltered;
		}

		/// <param name="reference">TESObjectREFR</param>
		static private System.Boolean IsSheltered(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			var ray = GetPrecipitationVelocity();

			if (ray == (0.0f, 0.0f, 0.0f))
			{
				ray = (0.0f, 0.0f, _settings.RayCastLength);
			}
			else
			{
				var multiplier = (float)System.Math.Sqrt((_settings.RayCastLength * _settings.RayCastLength) / ((ray.x * ray.x) + (ray.y * ray.y) + (ray.z * ray.z)));
				ray = (-ray.x * multiplier, -ray.y * multiplier, -ray.z * multiplier);
			}

			NetScriptFramework.Main.Log.AppendLine
			(
				"name = " + TESForm.GetName(TESObjectREFR.GetBaseForm(reference)) +
				", address = " + reference.ToString("X8") +
				", distance = " + TESObjectREFR.GetDistanceBetween(PlayerCharacter.Instance, reference).ToString("0") +
				", lastUpdate = " + Actor.GetLastUpdate(reference).ToString("0.00") +
				", ray = (" + ray.x.ToString("0") + ", " + ray.y.ToString("0") + ", " + ray.z.ToString("0") + ")"
			);

			return TESObjectREFR.IsHit(reference, TESObjectREFR.GetLookAtPosition(reference), ray, _collisionLayers);
		}

		static private (System.Single x, System.Single y, System.Single z) GetPrecipitationVelocity()
		{
			var currentPrecipitation = Precipitation.GetCurrentPrecipitation(Sky.GetPrecipitation(Sky.Instance));
			if (currentPrecipitation == System.IntPtr.Zero) { return (0.0f, 0.0f, 0.0f); }
			if (NiAVObject.HasNiAVFlags(currentPrecipitation, NiAVFlags.Hidden)) { return (0.0f, 0.0f, 0.0f); }
			if (!NiObject.HasNiRTTI(currentPrecipitation, NiRTTI.BSGeometry)) { throw new Eggceptions.Bethesda.RunTimeTypeInformationException("currentPrecipitation"); }

			var properties = BSGeometry.GetProperties(currentPrecipitation);
			if (properties == System.IntPtr.Zero) { return (0.0f, 0.0f, 0.0f); }
			if (!NiObject.HasNiRTTI(properties, NiRTTI.BSParticleShaderProperty)) { throw new Eggceptions.Bethesda.RunTimeTypeInformationException("properties"); }

			var emitter = BSParticleShaderProperty.GetParticleShaderEmitter(properties);
			if (emitter == System.IntPtr.Zero) { return (0.0f, 0.0f, 0.0f); }
			// RTTI

			return BSParticleShaderCubeEmitter.GetVelocity(emitter);
		}
	}
}
