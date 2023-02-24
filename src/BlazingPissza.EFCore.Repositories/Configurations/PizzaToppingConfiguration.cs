namespace BlazingPizza.EFCore.Repositories.Configurations;
internal sealed class PizzaToppingConfiguration : IEntityTypeConfiguration<PizzaTopping>
{
    public void Configure(EntityTypeBuilder<PizzaTopping> builder) 
    {
        builder.HasKey(pt => new { pt.PizzaId, pt.ToppingId });
        builder.HasOne<Pizza>().WithMany(p => p.Toppings);
        builder.HasOne(pt => pt.Topping).WithMany();
    }
}
