using com.ksgames.core.abstractions.enums;
using Lukomor.MVVM;
using Lukomor.Reactive;
using UnityEngine;

namespace com.ksgames.core.abstractions.gameresources
{
    public interface IResourceViewModel:IViewModel
    {
        public GameResourceEnum GameResourceEnum { get; set; }
        public ReactiveProperty<int> Amount { get; set; }
        public ReactiveProperty<Sprite> IconSprite { get; set;}
        
        public void ResourceViewModel(IGameResource resource);
    }
}