using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Handlers
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}
