using Eggstensions;
using Eggstensions.ExtensionMethods;



namespace ScrambledBugs.Fixes
{
	unsafe static internal class WeaponCharge
	{
		static public System.Boolean Fix()
		{
			if
			(
				!ScrambledBugs.Patterns.Fixes.WeaponCharge.Enchant
				||
				!ScrambledBugs.Patterns.Fixes.WeaponCharge.Equip
				||
				!ScrambledBugs.Patterns.Fixes.WeaponCharge.Recharge
			)
			{
				return false;
			}
			
			var handleEquippedItem = (delegate* unmanaged[Cdecl]<Actor*, TESBoundObject*, ExtraDataList*, System.Byte, void>)&HandleEquippedItem;

			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Fixes.WeaponCharge.Enchant, handleEquippedItem);
			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Fixes.WeaponCharge.Equip, handleEquippedItem);
			Trampoline.WriteRelativeCall(ScrambledBugs.Offsets.Fixes.WeaponCharge.Recharge, handleEquippedItem);

			[System.Runtime.InteropServices.UnmanagedCallersOnly(CallConvs = new[] { typeof(System.Runtime.CompilerServices.CallConvCdecl) })]
			static void HandleEquippedItem(Actor* actor, TESBoundObject* item, ExtraDataList* extraDataList, System.Byte leftHand)
			{
				if (item == null)
				{
					return;
				}

				var player		= PlayerCharacter.Instance;
				var rightHand	= leftHand == 0;

				if (actor == player)
				{
					player->RemoveEquippedItemFlags((System.Byte)((rightHand ? 1 : 0) + 1));
				}

				var enchantment = item->GetEnchantment(extraDataList);

				if (enchantment == null)
				{
					return;
				}

				var castingType = enchantment->GetCastingType();

				if (castingType == CastingType.ConstantEffect)
				{
					return;
				}

				var actorValue = enchantment->GetCostActorValue(rightHand);

				if (actorValue != ActorValue.None)
				{
					actor->RemoveActorValueModifiers(actorValue);

					var maximumCharge = item->GetMaximumCharge(extraDataList);
					actor->ActorValueOwner()->SetActorValue(actorValue, maximumCharge);

					if (extraDataList != null && extraDataList->HasExtraData(ExtraDataType.Charge))
					{
						var charge = extraDataList->GetCharge();
						actor->ActorValueOwner()->RestoreActorValue(ActorValueModifier.Damage, actorValue, -(maximumCharge - charge));
					}
				}

				actor->RevertSelectedSpell((EquipType)(rightHand ? 1 : 0), enchantment);
			}

			return true;
		}



		static void RemoveEquippedItemFlags<TPlayerCharacter>(this ref TPlayerCharacter player, System.Byte flags)
			where TPlayerCharacter : unmanaged, IPlayerCharacter
		{
			var removeEquippedItemFlags = (delegate* unmanaged[Cdecl]<TPlayerCharacter*, System.Byte, void>)ScrambledBugs.Offsets.Fixes.WeaponCharge.RemoveEquippedItemFlags;

			RemoveEquippedItemFlags(player.AsPointer(), flags);



			[System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.NoInlining)]
			void RemoveEquippedItemFlags(TPlayerCharacter* player, System.Byte flags)
			{
				removeEquippedItemFlags(player, flags);
			}
		}
	}
}
