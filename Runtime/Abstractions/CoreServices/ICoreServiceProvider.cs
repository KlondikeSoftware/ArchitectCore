using com.ksgames.core.abstractions.enums.coreservices.enums;
using R3;

namespace com.ksgames.core.abstractions.coreservices
{
    public interface ICoreServiceProvider
    {
        public ReactiveProperty<CoreServiceProviderStateEnum> State { get; set; }
        public ICoreServiceProviderEnterParams EnterParams { get; set; }
        public Observable<CoreServiceProviderStateEnum> Initialize();
    }
}