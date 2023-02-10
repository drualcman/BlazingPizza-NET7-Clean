namespace BlazingPizza.EFCore.Repositories.Configurations;
public class OrderConfiguration : IEntityTypeConfiguration<EFEntities.Order>
{
    public void Configure(EntityTypeBuilder<EFEntities.Order> builder) 
    {
        builder.OwnsOne(o => o.DeliveryLocation);
    }
}
