using System.Collections.Generic;
using com.ksgames.core.abstractions.gameresources;
using com.ksgames.core.abstractions.inventory;
using com.ksgames.core.abstractions.landscape;
using com.ksgames.core.abstractions.skills;
using com.ksgames.core.abstractions.unitproperty;
using Lukomor.MVVM;
using UnityEngine;

namespace com.ksgames.core.architect.monsters
{
    public interface IMonsterParams
    {
        public string Name { get; }
        public string Id { get; }
        public MonsterTypeEnum Type { get; }
        public MonsterLevelEnum Level { get; }
        public BiomEnum Biom { get; }

        public IEnumerable<IUnitPropertyData> Properties { get; }

        public IEnumerable<IGameResourceData> LootResources { get; }
        public IEnumerable<ICollectionItem> LootItems { get; } 
        public int LootItemsCount { get; }
        public int LootItemsRate { get; }
        public IEnumerable<IBuff> Perks { get; }

        public View Prefab { get; }
        public GameObject BulletPrefab { get; }
        public bool IsChest => Type == MonsterTypeEnum.Chest;
        public bool IsMeleeMinion => Type == MonsterTypeEnum.Melee && Level != MonsterLevelEnum.Boss;
        public bool IsRangedMinion => Type == MonsterTypeEnum.Ranged && Level != MonsterLevelEnum.Boss;
        public bool MeleeBoss => Type == MonsterTypeEnum.Melee && Level == MonsterLevelEnum.Boss;
        public bool RangedBoss => Type == MonsterTypeEnum.Ranged && Level == MonsterLevelEnum.Boss;
        public bool IsBoss => Level == MonsterLevelEnum.Boss;
        
    }
}