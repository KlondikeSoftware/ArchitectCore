using com.ksgames.core.abstractions.FSM;
using Lukomor.MVVM;
using Lukomor.Reactive;
using UnityEngine;

namespace com.ksgames.core.abstractions.waves.ViewModels
{
    public interface IWaveItemViewModel: IViewModel
    {
        IWaveItemService _service { get; }
        string GetID();
        ReactiveProperty<EntityStatesEnum> State { get;}
        ReactiveProperty<IWaveItemPositionData> IdlePosition { get; }
        void ViewCallBack(string callBackCode);
        void SetState(EntityStatesEnum idle);
        GameObject GetPrefab();
    }
}