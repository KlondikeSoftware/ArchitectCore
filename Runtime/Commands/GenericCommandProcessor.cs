using System;
using System.Collections.Generic;
using com.ksgames.services.persistenceservice;

namespace com.ksgames.core.architect
{
    public class GenericCommandProcessor<T>: ICommandProcessor where T : IGameData
    {

        private readonly Dictionary<Type, object> _handlersMap = new Dictionary<Type, object>();
        private iDataProvider<T> _saveProvider;


        public GenericCommandProcessor(iDataProvider<T> saveProvider)
        {
            _saveProvider = saveProvider;
        }
        public GenericCommandProcessor()
        {
            _saveProvider = null;
        }
        
        public void RegisterHandler<TCommand>(ICommandHandler<TCommand> handler) where TCommand : ICommand
        {
            _handlersMap[typeof(TCommand)] = handler;
        }

        public bool Process<TCommand>(TCommand commmand) where TCommand : ICommand
        {
            if (_handlersMap.TryGetValue(typeof(TCommand), out var handler))
            {
                var typedHandler = (ICommandHandler<TCommand>)handler;
                var result = typedHandler.Handle(commmand);
        
                if (result && _saveProvider!= null) _saveProvider.SaveData();
        
                return result;
        
            }
        
            return false;
        }
    }
}