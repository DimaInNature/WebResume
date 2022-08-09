namespace WR.Consumers.Desktop.Application.Exceptions;

public class ViewModelNotFoundException : Exception
{
    public ViewModelNotFoundException(string? message) : base(message) { }

    public ViewModelNotFoundException(string? message, Exception? innerException)
        : base(message, innerException) { }

    public ViewModelNotFoundException() : base() { }

    public static void ThrowIfNotFound(BaseViewModel? model, string? message = default)
    {
        if (model is null)
            throw new ViewModelNotFoundException(message);
    }
}