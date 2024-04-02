
namespace CleanDemo.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentension(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddHttpContextAccessor();

        return services;
    }
}

