namespace BlazingPizza.Controllers;
internal sealed class GetSpecialController : IGetSpecialsController
{
    readonly IGetSpecialsInputPort InputPort;
    readonly IGetSpecialsPresenter Presenter;

    public GetSpecialController(IGetSpecialsInputPort inputPort, IGetSpecialsPresenter presenter)
    {
        InputPort = inputPort;
        Presenter = presenter;
    }

    public async Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync() =>
        await Presenter.GetSpecialsAsync(await InputPort.GetSpecialsAsync());
}
