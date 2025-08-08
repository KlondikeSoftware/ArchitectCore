using System;
using com.ksgames.core.abstractions.persistence.enums;
using R3;

namespace com.ksgames.core.abstractions.persistence
{
    public interface IPersistenceProviderWrapper
    {
        Type StateType { get; }
        Observable<IGameData> LoadData();

        public ReactiveProperty<PersistenceProviderStateEnum> State { get; }

        object RawProvider { get; }
        void Initialize();
    }
}


