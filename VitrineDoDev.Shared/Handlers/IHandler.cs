using VitrineDoDev.Shared.Commands;

namespace VitrineDoDev.Shared.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
