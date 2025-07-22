namespace com.ksgames.core.architect.FSM
{
    public abstract class FSMState
    {
        protected readonly FStateMachine Fsm;


        protected FSMState(FStateMachine fsm)
        {
            Fsm = fsm;
        }

        public virtual void Enter()
        {
        }

        public virtual void Exit()
        {
        }

        public virtual void Update()
        {
        }
    }
}