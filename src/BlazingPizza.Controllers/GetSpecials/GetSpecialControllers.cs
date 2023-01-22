namespace BlazingPizza.Controllers.GetSpecials;
public class GetSpecialControllers : IGetSpecialsController
{
    readonly IGetSpecialsInputPort InputPort;
    readonly IGetSpecialsPresenter Presenter;

    public GetSpecialControllers(IGetSpecialsInputPort inputPort, IGetSpecialsPresenter presenter)
    {
        InputPort = inputPort;
        Presenter = presenter;
    }

    public async Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync()   =>
        //await Presenter.GetSpecialsAsync(await InputPort.GetSpecialsAsync());
        await Presenter.GetSpecialsAsync();
}
