using System;
using System.Collections.Generic;

namespace com.ksgames.core.architect.FSM
{
    public abstract class FStateMachine
    {
        public FStateMachine() { }

        protected FSMState CurrentState { set; get; }

        protected Dictionary<Type, FSMState> _stateMap = new();


        public void AddState(FSMState newState)
        {
            _stateMap.Add(newState.GetType(), newState);
        }

        public void SetState<T>() where T : FSMState
        {
            var type = typeof(T);
            
            if (CurrentState?.GetType() == type) return;

            if (_stateMap.TryGetValue(type, out var newState))
            {
                CurrentState?.Exit();
                CurrentState = newState;
                CurrentState.Enter();
            }
        }

        public void Update()
        {
            CurrentState?.Update();
        }
    }
}