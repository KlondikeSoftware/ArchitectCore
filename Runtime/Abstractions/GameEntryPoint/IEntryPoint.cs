using Lukomor.DI;

namespace com.ksgames.core.abstractions.gameentrypoint
{
    public interface IEntryPoint
    {
        // public void Process(DIContainer gameContainer, IEnterParams enterParams, Action callBack);
        public void Process(DIContainer gameContainer, IEnterParams enterParams);
        public void Process(DIContainer gameContainer);
        
    }


}