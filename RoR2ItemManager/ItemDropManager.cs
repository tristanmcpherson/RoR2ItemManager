using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoMod;
using RoR2;

namespace RoR2 {
    public class PickupSelection
    {
        public List<PickupIndex> Pickups { get; set; }
        public float DropChance { get; set; } = 1.0f;
    }


	public static class ItemDropManager {

        public static Dictionary<DropLocation, List<PickupSelection>> Selection = new Dictionary<DropLocation, List<PickupSelection>>();

        public enum DropLocation
        {
            Boss,
            Chest,
            Shrine
        }

        public static void AddDropInformation(DropLocation dropLocation, List<PickupSelection> pickupSelections)
        {
            Selection[dropLocation] = pickupSelections;
        }

        public static PickupIndex GetSelection(DropLocation dropLocation, float normalizedIndex)
        {
            var selections = Selection[dropLocation];
            WeightedSelection<PickupIndex> weightedSelection = new WeightedSelection<PickupIndex>();
            foreach (var selection in selections)
                foreach (var pickup in selection.Pickups)
                    weightedSelection.AddChoice(pickup, selection.DropChance);

            return weightedSelection.Evaluate(normalizedIndex);
        }

		public static List<ItemIndex> Tier1DropList = new List<ItemIndex>
		{
			ItemIndex.Syringe,
			ItemIndex.Hoof,
			ItemIndex.JumpBoost,
			ItemIndex.SecondarySkillMagazine,
			ItemIndex.Dagger,
			ItemIndex.WardOnLevel,
			ItemIndex.BossDamageBonus,
			ItemIndex.BleedOnHit,
			ItemIndex.ChainLightning,
			ItemIndex.SlowOnHit,
			ItemIndex.Feather,
			ItemIndex.AlienHead,
			ItemIndex.EquipmentMagazine
		};

		public static List<ItemIndex> Tier2DropList = new List<ItemIndex>
		{
			ItemIndex.Syringe,
			ItemIndex.Hoof,
			ItemIndex.JumpBoost,
			ItemIndex.SecondarySkillMagazine,
			ItemIndex.Dagger,
			ItemIndex.WardOnLevel,
			ItemIndex.BossDamageBonus,
			ItemIndex.BleedOnHit,
			ItemIndex.ChainLightning,
			ItemIndex.SlowOnHit,
			ItemIndex.Feather,
			ItemIndex.AlienHead,
			ItemIndex.EquipmentMagazine
		};

		public static List<ItemIndex> Tier3DropList = new List<ItemIndex>
		{
			ItemIndex.UtilitySkillMagazine,
			ItemIndex.ExtraLife,

		};

		public static List<ItemIndex> BossDropList = Tier3DropList;
		public static bool IncludeSpecialBossDrops = true;

		public static float ChestTier1DropChance = 0.8f;
		public static float ChestTier2DropChance = 0.2f;
		public static float ChestTier3DropChance = 0.01f;
	}
}
