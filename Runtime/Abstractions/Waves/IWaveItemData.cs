using System.Collections;
using System.Collections.Generic;
using com.ksgames.core.abstractions.enums;
using com.ksgames.core.abstractions.FSM;
using com.ksgames.core.abstractions.gameresources;
using com.ksgames.core.abstractions.unitproperty;
using com.ksgames.core.architect.monsters;

namespace com.ksgames.core.abstractions.waves
{
    public interface IWaveItemData
    {
        public EntityStatesEnum State { get; }
        public string Id { get; }
        public int Speed { get; }
        public IWaveItemPositionData IdlePosition { get; }
        public IMonsterParams Params { get; }
        List<IUnitPropertyData> Properties { get;}
    }
}