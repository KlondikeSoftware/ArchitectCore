using com.ksgames.core.abstractions.gameresources;
using UnityEngine;

namespace com.ksgames.core.abstractions.inventory
{
    public interface ICollectionItem
    {
        Sprite GetIconSprite();
        string ID { get; set; }
        public Sprite IconBack { get; }
        IGameResourceData GetNextLevelPrice(int i);
    }
}