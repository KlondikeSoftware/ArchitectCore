using com.ksgames.core.abstractions.waves.enums;
using Lukomor.Reactive;

namespace  com.ksgames.core.abstractions.waves
{
    public interface IWavesSpawnerService
    {
        
        public IWaveService Wave { get; }
        public ReactiveProperty<bool> GateOpen { get; set; }

        
        
        bool IsDefeat();
        void HideProgress();

        
        private void SpawnNextWave() { }
        public ReactiveProperty<WaveSpawnerStatesEnum> SpawnNewWave();
        public ReactiveProperty<WaveSpawnerStatesEnum> Clear();
        void InProgress();
        void Ready();
        public ReactiveProperty<WaveSpawnerStatesEnum> DeleteWave();
    }
}