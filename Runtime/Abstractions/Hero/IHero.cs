using System.Collections.Generic;
using com.ksgames.core.abstractions.inventory;
using com.ksgames.core.abstractions.inventory.enums;
using UnityEngine;

namespace com.ksgames.core.abstractions.hero
{
    public interface IHero
    {
        void ResetEquipment();
        SpriteCollection SpriteCollection { get; set; }
        Sprite Helmet { get; set; }
        bool FullHair { get; set; }
        List<Sprite> Armor { get; set; }
        List<Sprite> Shield { get; set; }
        WeaponType WeaponType { get; set; }
        List<Sprite> Bow { get; set; }
        List<Sprite> PrimaryMeleeWeapon { get; set; }
        void Initialize();
    }
}