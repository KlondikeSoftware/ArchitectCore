using System;
using System.Reactive.Linq;

namespace com.ksgames.core.abstractions.landscape
{
    public interface ILandscapeService
    {
        Lukomor.Reactive.ReactiveProperty<LandscapeStateEnum> State { get;  }

        public IObservable<bool> Play()
        {
            State.Value = LandscapeStateEnum.PLAY;
            return Observable.Return(true);
        }

        public IObservable<bool> Stop()
        {
            State.Value = LandscapeStateEnum.STOP;
            return Observable.Return(true);
        }
    }
}