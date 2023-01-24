namespace BlazingPizza.Presenters.GetSpecials;
internal class GetSpecialsPresenter : IGetSpecialsPresenter
{
    readonly string ImagesBaseUrl;

    public GetSpecialsPresenter(string imagesBaseUrl) => ImagesBaseUrl = imagesBaseUrl;

    public Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync(IReadOnlyCollection<PizzaSpecial> specials) 
    {
        foreach (PizzaSpecial special in specials)
        {
            special.ImageUrl = $"{ImagesBaseUrl}/{special.ImageUrl}";
        }
        return Task.FromResult(specials);
    }
}
