using CleanDemo.Application.Common.Interfaces;
using CleanDemo.Infrastructure.Common;
using CleanDemo.Infrastructure.Reminders.Persistence;
using CleanDemo.Infrastructure.Users.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanDemo.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddPersistence(configuration);

        return services;
    }


    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("raindb")));

        services.AddSingleton<IRemindersRepository, RemindersRepository>();
        services.AddSingleton<IUsersRepository, UsersRepository>();

        return services;
    }
}

