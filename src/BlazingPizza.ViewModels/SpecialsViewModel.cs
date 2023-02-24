﻿namespace BlazingPizza.ViewModels;

internal sealed  class SpecialsViewModel : ISpecialsViewModel
{
    readonly ISpecialsModel Model;

    public SpecialsViewModel(ISpecialsModel model) => Model = model;

    public IReadOnlyCollection<PizzaSpecial> Specials {get; private set;}   

    public async Task GetSpeiclasAsync()
    {
        Specials = await Model.GetSpecialsAsync();
    }
}