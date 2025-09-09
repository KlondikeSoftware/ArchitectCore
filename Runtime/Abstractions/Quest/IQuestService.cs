using System.Collections.Generic;
using com.ksgames.core.abstractions.enums;
using com.ksgames.core.abstractions.gameresources;
using com.ksgames.core.abstractions.landscape;
using com.ksgames.core.abstractions.waves;

namespace com.ksgames.core.abstractions.quest
{
    public interface IQuestService
    {
        List<IWaveInfo> GetWaves();
        IQuestInfo Settings { get; set; }
        BiomEnum Biom => Settings.Biom;
        IQuestInfo Data => Settings;
        IGameResource GetRewardResource(GameResourceEnum coins);
        string GetID() => Settings.Id;
    }
}