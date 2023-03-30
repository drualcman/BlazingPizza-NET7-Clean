namespace CustomExceptions.HttpHandlers;
internal class HttpExceptionHandlerHub : IHttpExceptionHandlerHub
{
    readonly Dictionary<Type, Type> ExceptionHandlers = new();

    public HttpExceptionHandlerHub(Assembly assembly)
    {
        Type[] types = assembly.GetTypes();
        foreach (Type type in types)
        {
            IEnumerable<Type> handlers = type.GetInterfaces()
                               .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IHttpExceptionHandler<>));
            foreach (Type handler in handlers)
            {
                Type exceptionType = handler.GetGenericArguments()[0];
                ExceptionHandlers.TryAdd(exceptionType, type);
            }
        }
    }

    public ProblemDetails Handle(Exception exception, bool includeDetails)
    {
        ProblemDetails details;
        Type exceptionType = exception.GetType();
        if (ExceptionHandlers.TryGetValue(exceptionType, out Type handlerType))
        {
            var handlerInstance = Activator.CreateInstance(handlerType);
            details = (ProblemDetails)handlerType
                        .GetMethod(nameof(IHttpExceptionHandler<Exception>.Handle))
                        .Invoke(handlerInstance, new object[] { exception });
        }
        else
        {
            string title = "Ha ocurrido un error al procesar la respuesta.";
            string detail;
            if (includeDetails)
            {
                detail = exception.Message + " " + exception.ToString();
            }
            else
            {
                detail = "Consulta al administrador.";
            }
            details = new ProblemDetails
            {
                Title = title,
                Detail = detail,
                Status = StatusCodes.Status500InternalServerError,
                Type = StatusCodes.Status500InternalServerErrorType
            };
        }
        return details;
    }
}