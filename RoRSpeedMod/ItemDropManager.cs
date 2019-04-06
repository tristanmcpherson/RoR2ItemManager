using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoMod;
using RoR2;

namespace RoR2 {
	public static class ItemDropManager {
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
