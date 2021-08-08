using Eggstensions;



namespace ScrambledBugs.Fixes
{
	unsafe internal class WeaponCharge
	{
		static WeaponCharge()
		{
			WeaponCharge.HandleEquippedWeapon = (Actor* actor, TESObjectWEAP* weapon, ExtraDataList* extraDataList, System.Byte leftHand) =>
			{
				if (weapon == null)
				{
					return;
				}

				var player = PlayerCharacter.Instance;
				var rightHand = leftHand == 0;

				if (actor == player)
				{
					ScrambledBugs.Delegates.Instances.Fixes.WeaponCharge.AddEquippedWeaponFlags(player, (System.Byte)((rightHand ? 1 : 0) + 1));
				}

				var enchantment = TESForm.GetEnchantment(&weapon->TESBoundObject.TESForm, extraDataList);

				if (enchantment == null)
				{
					return;
				}

				var castingType = MagicItem.GetCastingType(&enchantment->MagicItem);

				if (castingType == CastingType.ConstantEffect)
				{
					return;
				}

				var actorValue = MagicItem.GetCostActorValue(&enchantment->MagicItem, rightHand);

				if (actorValue == ActorValue.None)
				{
					return;
				}

				Actor.RemoveActorValueModifiers(actor, actorValue);

				if (extraDataList != null)
				{
					var maximumCharge = TESForm.GetMaximumCharge(&weapon->TESBoundObject.TESForm, extraDataList);
					var actorValueOwner = &actor->ActorValueOwner;

					ActorValueOwner.SetActorValue(actorValueOwner, actorValue, maximumCharge);

					if (ExtraDataList.HasExtraData(extraDataList, ExtraDataType.Charge))
					{
						var charge = ExtraDataList.GetCharge(extraDataList);

						ActorValueOwner.RestoreActorValue(actorValueOwner, ActorValueModifier.Damage, actorValue, -(maximumCharge - charge));
					}
				}

				Actor.RevertSelectedSpell(actor, (EquipType)(rightHand ? 1 : 0), &enchantment->MagicItem);
			};

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Fixes.WeaponCharge.HandleEquippedWeapon>
			(
				ScrambledBugs.Offsets.Fixes.WeaponCharge.Enchant,
				WeaponCharge.HandleEquippedWeapon
			);

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Fixes.WeaponCharge.HandleEquippedWeapon>
			(
				ScrambledBugs.Offsets.Fixes.WeaponCharge.Equip,
				WeaponCharge.HandleEquippedWeapon
			);

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Fixes.WeaponCharge.HandleEquippedWeapon>
			(
				ScrambledBugs.Offsets.Fixes.WeaponCharge.Recharge,
				WeaponCharge.HandleEquippedWeapon
			);
		}



		static public ScrambledBugs.Delegates.Types.Fixes.WeaponCharge.HandleEquippedWeapon HandleEquippedWeapon { get; }
	}
}
