namespace BlazingPizza.EFCore.Repositories.Configurations;
internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder) 
    {
        builder.OwnsOne(o => o.DeliveryLocation);
    }
}
