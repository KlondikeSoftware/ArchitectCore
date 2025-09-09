using com.ksgames.core.abstractions.FSM;
using Lukomor.MVVM;
using Lukomor.Reactive;
using UnityEngine;

namespace com.ksgames.core.abstractions.waves.ViewModels
{
    public interface IWaveItemViewModel: IViewModel
    {
        string GetID();
        int Position { get; set; }
        ReactiveProperty<EntityStatesEnum> State { get; set; }
        void ViewCallBack(string callBackCode);
        void SetState(EntityStatesEnum idle);
        View GetPrefab();
    }
}