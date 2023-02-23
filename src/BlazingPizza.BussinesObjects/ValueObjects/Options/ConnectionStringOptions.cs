namespace BlazingPizza.Backend.BussinesObjects.ValueObjects.Options;
public class ConnectionStringOptions
{
    public const string SectionKey = "ConnectionStrings";

    public string BlazingPizzaDb { get; set; }
}
