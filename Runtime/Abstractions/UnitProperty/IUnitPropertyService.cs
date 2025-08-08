using com.ksgames.core.abstractions.enums;

namespace com.ksgames.core.abstractions.unitproperty
{
    public interface IUnitPropertyService
    {
        public bool IncreaseProperty(UnitPropertyEnum def, int commandAmount);
    }
}