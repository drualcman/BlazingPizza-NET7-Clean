namespace BlazingPizza.Controllers.GetSpecials;
public class GetSpecialControllers : IGetSpecialsController
{
    readonly IGetSpecialsInputPort InputPort;

    public GetSpecialControllers(IGetSpecialsInputPort inputPort)
    {
        InputPort = inputPort;
    }

    public Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync()   =>
        InputPort.GetSpecialsAsync();
}
