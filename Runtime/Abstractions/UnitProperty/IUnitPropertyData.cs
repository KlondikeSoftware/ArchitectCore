using com.ksgames.core.abstractions.enums;

namespace com.ksgames.core.abstractions.unitproperty
{
    public  interface IUnitPropertyData
    { 
        UnitPropertyEnum Id { get; set; }
        string Value { get; set; }
        int ValueInt { get; set; }
    }
}