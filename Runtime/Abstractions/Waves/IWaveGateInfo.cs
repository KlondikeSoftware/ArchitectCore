using System.Collections.Generic;
using com.ksgames.core.abstractions.unitproperty;

namespace com.ksgames.core.abstractions.waves
{
    public class IWaveGateInfo
    {
        public int KeyLevel;
        public int KeyValue;
        public List<IUnitPropertyData> GateProperties;
    }
}