using com.ksgames.core.abstractions.FSM;
using Lukomor.Reactive;

namespace com.ksgames.core.abstractions.hero
{
    public interface IHeroBattleService
    {
        bool IsDead { get; }
        ReactiveProperty<bool> Initiative { get; set; }

        public ReactiveProperty<EntityStatesEnum> Run();

        public ReactiveProperty<EntityStatesEnum> MoveToWin();

        public ReactiveProperty<EntityStatesEnum> Attack();

        public void OnPosition();

        public void Stop();

        public void BossCompleteReaction();

        public void EnterToTavern();
        void SetToIdle();
        void SetToReady();
        void SetToWin();
    }
}