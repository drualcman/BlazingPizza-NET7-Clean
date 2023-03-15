namespace CustomExceptions;
public sealed class GeneralException : Exception
{
    public string Detail { get; }
    public GeneralException() { }
	public GeneralException(string message) : base(message) { }
	public GeneralException(string message, Exception inner) : base(message, inner) { }

    public GeneralException(string message, string detail) : base(message)
    {
        Detail = detail;
    }
}
