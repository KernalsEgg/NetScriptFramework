using Eggstensions;



namespace ScrambledBugs.Fixes
{
	unsafe internal class WeaponCharge
	{
		static WeaponCharge()
		{
			WeaponCharge.HandleEquippedItem = (Actor* actor, TESBoundObject* item, ExtraDataList* extraDataList, System.Byte leftHand) =>
			{
				if (item == null)
				{
					return;
				}

				var player = PlayerCharacter.Instance;
				var rightHand = leftHand == 0;

				if (actor == player)
				{
					ScrambledBugs.Delegates.Instances.Fixes.WeaponCharge.RemoveEquippedItemFlags(player, (System.Byte)((rightHand ? 1 : 0) + 1));
				}

				var enchantment = TESForm.GetEnchantment(&item->TESForm, extraDataList);

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

				if (actorValue != ActorValue.None)
				{
					Actor.RemoveActorValueModifiers(actor, actorValue);

					var maximumCharge = TESForm.GetMaximumCharge(&item->TESForm, extraDataList);
					ActorValueOwner.SetActorValue(&actor->ActorValueOwner, actorValue, maximumCharge);

					if (extraDataList != null && ExtraDataList.HasExtraData(extraDataList, ExtraDataType.Charge))
					{
						var charge = ExtraDataList.GetCharge(extraDataList);
						ActorValueOwner.RestoreActorValue(&actor->ActorValueOwner, ActorValueModifier.Damage, actorValue, -(maximumCharge - charge));
					}
				}

				Actor.RevertSelectedSpell(actor, (EquipType)(rightHand ? 1 : 0), &enchantment->MagicItem);
			};

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Fixes.WeaponCharge.HandleEquippedItem>
			(
				ScrambledBugs.Offsets.Fixes.WeaponCharge.Enchant,
				WeaponCharge.HandleEquippedItem
			);

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Fixes.WeaponCharge.HandleEquippedItem>
			(
				ScrambledBugs.Offsets.Fixes.WeaponCharge.Equip,
				WeaponCharge.HandleEquippedItem
			);

			ScrambledBugs.Plugin.Trampoline.WriteRelativeCall<ScrambledBugs.Delegates.Types.Fixes.WeaponCharge.HandleEquippedItem>
			(
				ScrambledBugs.Offsets.Fixes.WeaponCharge.Recharge,
				WeaponCharge.HandleEquippedItem
			);
		}



		static public ScrambledBugs.Delegates.Types.Fixes.WeaponCharge.HandleEquippedItem HandleEquippedItem { get; }
	}
}
