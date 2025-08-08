using com.ksgames.core.abstractions.enums;
using Lukomor.Reactive;
using UnityEngine;

namespace com.ksgames.core.abstractions.gameresources
{
    public interface IGameResource
    {
        GameResourceEnum ResourceType { get; set; }
        ReactiveProperty<int> Amount { get; }
        ReactiveProperty<Sprite> IconSprite { get; }
    }
}