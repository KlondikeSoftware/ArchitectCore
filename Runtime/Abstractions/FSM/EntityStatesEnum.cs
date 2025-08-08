using System;

namespace com.ksgames.core.abstractions.FSM
{
    [Serializable]
    public enum EntityStatesEnum
    {
        IDLE,
        WALK,
        RUN,
        DEAD,
        READYFORDEATH,
        READY,
        ATTACK,
        CHARGE,
        RELEASE,
        TAKEDAMAGE,
        MOVEIN,
        MOVEOUT,
        HEROTURN,
        MONSTERTURN,
        NEXTWAVE,
        CLEAR,
        STOP,
        WIN,
        RELAX,
        ENDTURN,
        END,
        // CREATED // monster created
        FINISHEDATTACK,
        PAUSE,
        PLAY,
        DISAPPEAR,
        DEFEAT,
        EVASION,
        STUNMOVE,
        STUN,
        CASTSPELL,
        MOVETOWIN,
        FREE
    }
}