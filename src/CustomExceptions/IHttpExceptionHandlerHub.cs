namespace CustomExceptions;
public interface IHttpExceptionHandlerHub
{
    ProblemDetails Handle(Exception exception, bool includeDetails);
}
