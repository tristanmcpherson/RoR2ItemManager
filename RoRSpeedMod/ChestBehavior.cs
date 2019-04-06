using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityStates;
using EntityStates.Barrel;
using MonoMod;
using RoR2;

namespace RoR2 {
	internal class patch_ChestBehavior : ChestBehavior
	{
		public extern void orig_ctor();
		[MonoModConstructor]
		public void ctor()
		{
			orig_ctor();

			this.tier1Chance = ItemDropManager.ChestTier1DropChance;
			this.tier2Chance = ItemDropManager.ChestTier2DropChance;
			this.tier3Chance = ItemDropManager.ChestTier3DropChance;
		}
	}
}
