﻿namespace BlazingPizza.EFCore.Repositories.Entities;
internal class PizzaTopping
{
    public int PizzaId { get; set; }
    public int ToppingId { get; set; }
    public Topping Topping { get; set; }
}
