namespace com.ksgames.core.architect
{
    public interface ICommandProcessor
    {
        void RegisterHandler<TCommand>(ICommandHandler<TCommand> command) where TCommand : ICommand;
        bool Process<TCommand>(TCommand commmand) where TCommand : ICommand;
    }
}