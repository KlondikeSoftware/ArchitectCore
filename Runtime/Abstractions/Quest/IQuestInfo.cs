using UnityEngine;

namespace com.ksgames.core.abstractions.quest
{
    public interface IQuestInfo
    {
        string Id { get; set; }
        bool IsOnboarding { get; }
        Sprite BossSprite { get;  }
        string BossCaption { get;  }
        QuestLevel Level { get; }
    }
}