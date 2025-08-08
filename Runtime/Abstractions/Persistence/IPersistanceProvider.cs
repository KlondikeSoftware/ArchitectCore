using com.ksgames.core.abstractions.persistence.enums;
using R3;

namespace com.ksgames.core.abstractions.persistence
{
    public interface IPersistenceProvider
    {
    }

    public interface IPersistenceProvider<T> where T : IGameData
    {
        public T Data { get; }
        string GAME_STATE_KEY { get; set; }
        public Observable<T> LoadData();
        public Observable<bool> SaveData();
        public Observable<bool> ResetData();
        void Reload();
        public T CreateDataFromSettings();
        public ReactiveProperty<PersistenceProviderStateEnum> State { get; }
        void Initialize();
    }
}