namespace com.ksgames.core.architect
{
    public interface ICommandHandler<TCommand> where TCommand:ICommand
    {
        bool Handle(TCommand command);
    }
}