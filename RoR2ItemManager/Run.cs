using MonoMod;
using System.Collections.Generic;
using System.Linq;
using RoR2;

namespace RoR2
{
    internal class patch_Run : Run
    {

        [MonoModPublic]
        public void BuildDropTable()
        {
            this.availableTier1DropList.Clear();
            this.availableTier2DropList.Clear();
            this.availableTier3DropList.Clear();
            this.availableLunarDropList.Clear();
            this.availableEquipmentDropList.Clear();

            this.availableTier1DropList.AddRange(ItemDropManager.Tier1DropList.Select(i => new PickupIndex(i)));
	        this.availableTier2DropList.AddRange(ItemDropManager.Tier2DropList.Select(i => new PickupIndex(i)));
	        this.availableTier3DropList.AddRange(ItemDropManager.Tier3DropList.Select(i => new PickupIndex(i)));

			this.availableEquipmentDropList.Add(new PickupIndex(EquipmentIndex.CritOnUse));

            this.smallChestDropTierSelector.Clear();
            this.smallChestDropTierSelector.AddChoice(this.availableTier1DropList, 1f);
            this.mediumChestDropTierSelector.Clear();
            this.mediumChestDropTierSelector.AddChoice(this.availableTier2DropList, 1f);
            this.largeChestDropTierSelector.Clear();
            this.largeChestDropTierSelector.AddChoice(this.availableTier3DropList, 1f);
        }
    }
}
