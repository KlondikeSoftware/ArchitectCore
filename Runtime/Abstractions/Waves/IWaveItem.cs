using com.ksgames.core.abstractions.enums;
using com.ksgames.core.abstractions.FSM;
using com.ksgames.core.abstractions.skills;
using com.ksgames.core.abstractions.unitproperty;
using Lukomor.Reactive;

namespace com.ksgames.core.abstractions.waves
{
    public interface IWaveItem
    {
        public IWaveItemData Origin { get; }
        public ReactiveCollection<IUnitProperty> Properties { get; }
        public ReactiveProperty<EntityStatesEnum> State { get; }
        string Id { get; }
        public ReactiveProperty<int> Speed { get;  }
        public ReactiveProperty<PositionInWaveEnum> Position { get; }
        public ReactiveCollection<IBuff> Perks { get; }
      

        public void SetState(EntityStatesEnum newState)
        {
            State.Value = newState;
        }

    }
}