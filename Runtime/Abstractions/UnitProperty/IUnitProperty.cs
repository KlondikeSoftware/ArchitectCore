using System;
using com.ksgames.core.abstractions.enums;
using Lukomor.Reactive;

namespace com.ksgames.core.abstractions.unitproperty
{
    public interface IUnitProperty
    {
        public UnitPropertyEnum PropertyTypeEnum { get; set; }
        public ReactiveProperty<float> MaxValue { get; set; }

        public ReactiveProperty<float> BaseValue { get; }

        public ReactiveProperty<float> CurrentValue { get; }

        public ReactiveProperty<float> PreValue { get; }

        public ReactiveCollection<IUnitPropertyModifier> Modifiers { get; }
        
        private void UpdateCurrentValue() { }

        private void AddModifier(IUnitPropertyModifier unitPropertyModifier) {}

        public float GetCurrentValue()
        {
            return CurrentValue.Value;
        }
    }
}