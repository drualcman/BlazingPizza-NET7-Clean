﻿namespace BlazingPizza.EFCore.Repositories.Entities;

internal class PizzaSpecial
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    [Precision(8, 2)]
    public decimal BasePrice { get; set; }
    public string ImageUrl { get; set; }
}
