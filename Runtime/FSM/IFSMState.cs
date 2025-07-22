namespace com.ksgames.core.architect.FSM
{
    public interface IFSMState
    {
        public void Enter();
        public void Exit();
        public void Update();
    }
}