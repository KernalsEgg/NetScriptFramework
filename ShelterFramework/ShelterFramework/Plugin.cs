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
		//	GetHavokWorld: The Subject is not in the loaded world
		override protected System.Boolean Initialize(System.Boolean loadedAny)
		{
			// loadedAny

			_settings = new Settings();
			_settings.Load();

			Events.GetIsCreatureTypeEvent.Register(OnGetIsCreatureType);

			return true;
		}



		readonly static private System.String _messageBox =
			"Shelter Framework has thrown an exception." +
			"\nDetails are logged to Data\\NetScriptFramework\\NetScriptFramework.log.txt.";



		readonly static internal CollisionLayers[] _collisionLayers = new CollisionLayers[]
		{
			CollisionLayers.AnimStatic,
			CollisionLayers.Ground,
			CollisionLayers.Static,
			CollisionLayers.Terrain,
			CollisionLayers.Trees
		};



		readonly static private System.Single _rayCastLength = 2048.0f;



		static internal Settings _settings;




		static private void OnGetIsCreatureType(Events.GetIsCreatureTypeEventArguments arguments)
		{
			if (arguments == null) { throw new Eggceptions.ArgumentNullException("arguments"); }

			NetScriptFramework.Main.Log.AppendLine("name = " + NetScriptFramework.Memory.ReadString(TESForm.GetName(TESObjectREFR.GetBaseForm(arguments.Subject)), false) + ", address = " + arguments.Subject.ToString("X8") + ", distance = " + TESObjectREFR.GetDistanceBetween(PlayerCharacter.Instance, arguments.Subject).ToString("0") + ", argument1 = " + arguments.Argument1);

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

		/// <param name="reference">TESObjectREFR</param>
		static private System.Boolean IsSheltered(System.IntPtr reference)
		{
			if (reference == System.IntPtr.Zero) { throw new Eggceptions.ArgumentNullException("reference"); }

			var velocity = GetPrecipitationVelocity();

			if (velocity == (0.0f, 0.0f, 0.0f))
			{
				velocity = (0.0f, 0.0f, _rayCastLength);
			}
			else
			{
				var multiplier = (float)System.Math.Sqrt((_rayCastLength * _rayCastLength) / ((velocity.x * velocity.x) + (velocity.y * velocity.y) + (velocity.z * velocity.z)));
				velocity = (-velocity.x * multiplier, -velocity.y * multiplier, -velocity.z * multiplier);
			}

			NetScriptFramework.Main.Log.AppendLine("velocty = " + velocity);

			return TESObjectREFR.IsHit(reference, TESObjectREFR.GetLookAtPosition(reference), velocity, _collisionLayers);
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
