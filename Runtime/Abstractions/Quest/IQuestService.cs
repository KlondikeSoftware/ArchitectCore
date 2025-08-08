using System.Collections.Generic;
using com.ksgames.core.abstractions.enums;
using com.ksgames.core.abstractions.gameresources;
using com.ksgames.core.abstractions.waves;

namespace com.ksgames.core.abstractions.quest
{
    public interface IQuestService
    {
        List<IWaveInfo> GetWaves();
        IQuestInfo Settings { get; set; }
        IGameResource GetRewardResource(GameResourceEnum coins);
    }
}