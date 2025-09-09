using com.ksgames.core.abstractions.landscape;
using com.ksgames.core.architect.monsters;

namespace com.ksgames.core.abstractions.waves
{
    public interface IWaveInfo
    {
        public int ID { get;  }
        public int MonstersCount { get;  }
        public MonsterLevelEnum MonstersLevel { get;  }
        public BiomEnum Biom { get;  }
    }
}