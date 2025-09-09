using System.Collections.Generic;
using com.ksgames.core.abstractions.landscape;
using com.ksgames.core.abstractions.waves;
using UnityEngine;

namespace com.ksgames.core.abstractions.quest
{
    public interface IQuestInfo
    {
        string Id { get; set; }
        bool IsOnboarding { get; }
        Sprite Icon { get;  }
        string Caption { get;  }
        QuestLevel Level { get; }
        IEnumerable<IWaveInfo> Waves { get; }
        BiomEnum Biom { get; }
    }
}