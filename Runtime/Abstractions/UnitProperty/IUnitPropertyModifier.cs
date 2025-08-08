using com.ksgames.core.abstractions.enums;

namespace com.ksgames.core.abstractions.unitproperty
{
    public interface IUnitPropertyModifier
    {
        public UnitPropertyEnum Type { get;  set; }
        public int Value { get;  set; }
    }
}