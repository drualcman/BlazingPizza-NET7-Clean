using Microsoft.Extensions.Configuration;

namespace BlazingPizza.Presenters.GetSpecials;
public class GetSpecialsPresenter : IGetSpecialsPresenter
{
    readonly string ImagesBaseUrl;
    readonly IGetSpecialsInputPort InputPort;

    public GetSpecialsPresenter(IConfiguration configuration, IGetSpecialsInputPort inputPort)
    {
        ImagesBaseUrl = configuration ["ImageBaseUrl"];
        InputPort = inputPort;
    }

    //public GetSpecialsPresenter(string imagesBaseUrl) => ImagesBaseUrl = imagesBaseUrl;

    public Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync(IReadOnlyCollection<PizzaSpecial> specials) 
    {
        foreach (PizzaSpecial special in specials)
        {
            special.ImageUrl = $"{ImagesBaseUrl}/{special.ImageUrl}";
        }
        return Task.FromResult(specials);
    }
        
    public async Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync() 
    {
        IReadOnlyCollection<PizzaSpecial> specials = await InputPort.GetSpecialsAsync();
        foreach (PizzaSpecial special in specials)
        {
            special.ImageUrl = $"{ImagesBaseUrl}/{special.ImageUrl}";
        }
        return specials;
    }
}
