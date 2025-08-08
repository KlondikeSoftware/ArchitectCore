using System.Collections.Generic;
using com.ksgames.core.abstractions.enums;
using Lukomor.Reactive;

namespace com.ksgames.core.abstractions.unitproperty
{
    public interface IPropertiesService
    {
        public ReactiveCollection<IUnitProperty> Properties { get; set; }
        public Dictionary<UnitPropertyEnum, IUnitProperty> _propertiesMap { get; set; }

        public ReactiveProperty<float> ObserveValue(UnitPropertyEnum propertyEnum);

        public ReactiveProperty<float> ObserveMaxValue(UnitPropertyEnum propertyEnum);
        public void SetValue(UnitPropertyEnum propertyEnum, float newValue);

        public ReactiveCollection<IUnitProperty> GetCollection();

        public void AddModifier(UnitPropertyEnum propertyEnum, float addAmount);

        public void RemoveModifier(UnitPropertyEnum propertyEnum, float addAmount);
        
        public IUnitProperty GetProperty(UnitPropertyEnum propertyEnum);
    }
    
}