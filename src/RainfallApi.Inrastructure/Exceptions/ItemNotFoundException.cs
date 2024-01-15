namespace RainfallApi.Infrastructure.Exceptions;

public sealed class ItemNotFoundException : ApplicationException
{
    private const string DefaultMessage = "Item not found.";

    public ItemNotFoundException()
        : base(DefaultMessage)
    {
    }

    public ItemNotFoundException(string message)
        : base(message)
    {
    }
}