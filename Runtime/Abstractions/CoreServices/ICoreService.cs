using com.ksgames.core.abstractions.enums.coreservices.enums;
using R3;

namespace com.ksgames.core.abstractions.coreservices
{
    public interface ICoreService
    {
        public ReactiveProperty<CoreServiceStateEnum> State { get; set; }
        public Observable<CoreServiceStateEnum> Initialize(ICoreServiceEnterParams enterParams);
        public void LoadConfig();
        public void CreateDefaultSettings();
    }
}