using System;
using MonoMod;
using RoR2;
using UnityEngine;
using UnityEngine.Networking;

namespace RoR2 {

	internal class patch_ShrineChanceBehavior : ShrineChanceBehavior {
		public static event Action<bool, Interactor> onShrineChancePurchaseGlobal;

		private PurchaseInteraction purchaseInteraction;

		// Token: 0x040018D7 RID: 6359
		private int successfulPurchaseCount;

		// Token: 0x040018D8 RID: 6360
		private float refreshTimer;

		// Token: 0x040018D9 RID: 6361
		private const float refreshDuration = 2f;

		// Token: 0x040018DA RID: 6362
		private bool waitingForRefresh;

		private Xoroshiro128Plus rng;

		[Server]
		[MonoModPublic]
		public void AddShrineStack(Interactor activator)
		{
			if (!NetworkServer.active) {
				Debug.LogWarning("[Server] function 'System.Void RoR2.ShrineChanceBehavior::AddShrineStack(RoR2.Interactor)' called on client");
				return;
			}
			PickupIndex none = PickupIndex.none;
			PickupIndex value = Run.instance.availableTier1DropList[this.rng.RangeInt(0, Run.instance.availableTier1DropList.Count)];
			PickupIndex value2 = Run.instance.availableTier2DropList[this.rng.RangeInt(0, Run.instance.availableTier2DropList.Count)];
			PickupIndex value3 = Run.instance.availableTier3DropList[this.rng.RangeInt(0, Run.instance.availableTier3DropList.Count)];
			PickupIndex value4 = Run.instance.availableEquipmentDropList[this.rng.RangeInt(0, Run.instance.availableEquipmentDropList.Count)];
			WeightedSelection<PickupIndex> weightedSelection = new WeightedSelection<PickupIndex>(8);
			weightedSelection.AddChoice(none, this.failureWeight);
			weightedSelection.AddChoice(value, this.tier1Weight);
			weightedSelection.AddChoice(value2, this.tier2Weight);
			weightedSelection.AddChoice(value3, this.tier3Weight);
			weightedSelection.AddChoice(value4, this.equipmentWeight);
			PickupIndex pickupIndex = weightedSelection.Evaluate(this.rng.nextNormalizedFloat);
			bool flag = pickupIndex == PickupIndex.none;
			if (flag) {
				Chat.SendBroadcastChat(new Chat.SubjectFormatChatMessage {
					subjectCharacterBodyGameObject = activator.gameObject,
					baseToken = "SHRINE_CHANCE_FAIL_MESSAGE"
				});
			} else {
				this.successfulPurchaseCount++;
				PickupDropletController.CreatePickupDroplet(pickupIndex, this.dropletOrigin.position, this.dropletOrigin.forward * 20f);
				Chat.SendBroadcastChat(new Chat.SubjectFormatChatMessage {
					subjectCharacterBodyGameObject = activator.gameObject,
					baseToken = "SHRINE_CHANCE_SUCCESS_MESSAGE"
				});
			}

			Chat.SendBroadcastChat(new Chat.UserChatMessage { sender = activator.gameObject, text = "Anyone want this?" });
			
			Action<bool, Interactor> action = onShrineChancePurchaseGlobal;
			if (action != null) {
				action(flag, activator);
			}
			this.waitingForRefresh = true;
			this.refreshTimer = 2f;
			EffectManager.instance.SpawnEffect(Resources.Load<GameObject>("Prefabs/Effects/ShrineUseEffect"), new EffectData {
				origin = base.transform.position,
				rotation = Quaternion.identity,
				scale = 1f,
				color = this.shrineColor
			}, true);
			if (this.successfulPurchaseCount >= this.maxPurchaseCount) {
				this.symbolTransform.gameObject.SetActive(false);
			}
		}
	}
}
