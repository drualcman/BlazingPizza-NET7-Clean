namespace CustomExceptions;
public sealed class PersistenceException : Exception
{
	public PersistenceException() { }
	public PersistenceException(string message) : base(message) { }
	public PersistenceException(string message, Exception inner) : base(message, inner) { }
}
