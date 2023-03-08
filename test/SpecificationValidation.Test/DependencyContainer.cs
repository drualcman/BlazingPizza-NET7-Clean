namespace SpecificationValidation.Test;

public static class DependencyContainer
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddScoped<ISpecification<Address>, NameSpecification>();
        services.AddScoped<ISpecification<Address>, AddressSpecification>();
        services.AddScoped<ISpecification<Address>, RegionSpecification>();
        services.AddScoped<IValidator<Address>, AddressValidator>();
        return services;
    }
}
