namespace BlazingPizza.EFCore.Repositories.Configurations;
internal class PizzaToppingConfiguration : IEntityTypeConfiguration<PizzaTopping>
{
    public void Configure(EntityTypeBuilder<PizzaTopping> builder) 
    {
        builder.HasKey(pt => new { pt.PizzaId, pt.ToppingId });
        builder.HasOne<EFEntities.Pizza>().WithMany(p => p.Toppings);
        builder.HasOne(pt => pt.Topping).WithMany();
    }
}
