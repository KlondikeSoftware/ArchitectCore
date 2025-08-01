using com.ksgames.services.persistenceservice;
using R3;

namespace com.ksgames.core.architect
{
    public interface iDataProvider
    {
        void Reload();
    }
    public interface iDataProvider<T> : iDataProvider where T : IGameData
    {
        public T Data { get; }
        string GAME_STATE_KEY { get; set; }
        public Observable<T> LoadData();
        public Observable<bool> SaveData();
        public Observable<bool> ResetData();
        void Reload();
    }
}