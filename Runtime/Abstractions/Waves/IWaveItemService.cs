using com.ksgames.core.abstractions.enums;
using com.ksgames.core.abstractions.FSM;
using com.ksgames.core.abstractions.inventory;
using com.ksgames.core.abstractions.unitproperty;
using com.ksgames.core.architect;
using Lukomor.MVVM;
using Lukomor.Reactive;
using UnityEngine;

namespace com.ksgames.core.abstractions.waves
{
    public interface IWaveItemService
    {
        public IWaveItem EntityProxy { get; }
        public ReactiveProperty<EntityStatesEnum> State { get; }
        public ReactiveProperty<IWaveItemPositionData> IdlePosition { get; }
        
        public IPropertiesService Properties { get; set; }
        public ICommandProcessor _cmd { get; }
        
        public void SetState(EntityStatesEnum newStateEnum)
        { }

        public virtual void SpawnReward()
        { }
        

        public string GetID();

        protected virtual ICollectionItem GetRandomLootItem()
        {
            return null;
        }

        public virtual ReactiveProperty<EntityStatesEnum> Action()
        {
            return State;
        }

        public bool IsDead()
        {
            return State.Value is EntityStatesEnum.READYFORDEATH or EntityStatesEnum.DEFEAT or  EntityStatesEnum.DEAD or EntityStatesEnum.DISAPPEAR;
        }

        public bool ReadyForAction()
        {
            return State.Value is not EntityStatesEnum.READYFORDEATH and not EntityStatesEnum.DEAD
                and not EntityStatesEnum.DISAPPEAR and not EntityStatesEnum.FINISHEDATTACK;
        }

        GameObject GetPrefab();
    }
}