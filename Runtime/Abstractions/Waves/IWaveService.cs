using com.ksgames.core.abstractions.waves.enums;
using Lukomor.Reactive;

namespace  com.ksgames.core.abstractions.waves
{
    public interface IWaveService
    {
        void SetWaveState(WaveStateEnum newState);
        public ReactiveProperty<WaveStateEnum> Attack();

        ReactiveProperty<WaveStateEnum> SpawnMonsters();
        public ReactiveProperty<WaveStateEnum> ShowDeadBoss();
        void AllMonstersDeadState();
        void MoveOut();
        public ReactiveProperty<WaveStateEnum>  Clear();
        ReactiveProperty<WaveStateEnum> WaveState { get;  }
    }
}