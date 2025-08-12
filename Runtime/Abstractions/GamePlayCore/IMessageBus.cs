using System;
using Lukomor.Reactive;
using Unit = R3.Unit;

namespace com.ksgames.core.abstractions.gameplaycore
{
    public interface IMessageBus
    {
        public ReactiveProperty<bool> StartGame { get; }
        public ReactiveProperty<int> Merge { get; }
        public ReactiveProperty<bool> Play { get; }
        public ReactiveProperty<bool> Pause { get; }
    }
}