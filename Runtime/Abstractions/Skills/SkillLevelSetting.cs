using System;
using com.ksgames.core.abstractions.gameresources;

namespace com.ksgames.core.abstractions.skills
{
    [Serializable]
    public class SkillLevelSetting
    {
        public int Level;
        public IGameResourceData UsagePrice;
        public IGameResourceData UpgradePrice;
    }
}