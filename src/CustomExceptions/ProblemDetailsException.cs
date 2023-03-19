using System.Text.Json;

namespace CustomExceptions;
public class ProblemDetailsException : Exception
{
    public ProblemDetails ProblemDetails { get; }
    public ProblemDetailsException() { ProblemDetails = new(); }
	public ProblemDetailsException(string message) : base(message) { ProblemDetails = new ProblemDetails { Title = message }; }
	public ProblemDetailsException(string message, Exception inner) : base(message, inner) 
    {
        ProblemDetails = new ProblemDetails { Title = message, Detail = inner?.Message ?? "" }; 
    }
    public ProblemDetailsException(JsonElement jsonResponse)
    {
        ProblemDetails = JsonSerializer.Deserialize<ProblemDetails>(jsonResponse.GetRawText(),
                                                                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public ProblemDetailsException(ProblemDetails problemDetails) => ProblemDetails = problemDetails;

    public override string Message => ProblemDetails.Title;

}
