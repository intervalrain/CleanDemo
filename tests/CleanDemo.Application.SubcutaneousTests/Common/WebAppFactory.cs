using CleanDemo.Api;
using CleanDemo.Application.Common.Interfaces;
using CleanDemo.Infrastructure.Common;

using MediatR;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

using TestCommon.Security;

namespace CleanDemo.Application.SubcutaneousTests.Common;

public class WebAppFactory : WebApplicationFactory<IAssemblyMarker>, IAsyncLifetime
{
    public TestCurrentUserProvider TestCurrentUserProvider { get; private set; } = new();
    public PostgresTestDatabase TestDatabase { get; set; } = null!; 

    public IMediator CreateMediator()
    {
        var serviceScope = Services.CreateScope();
        TestDatabase.ResetDatabase();
        return serviceScope.ServiceProvider.GetRequiredService<IMediator>();
    }

    public Task InitializeAsync() => Task.CompletedTask;

    public new Task DisposeAsync()
    {
        TestDatabase.Dispose();

        return Task.CompletedTask;
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        TestDatabase = PostgresTestDatabase.CreateAndInitialize();

        builder.ConfigureServices(services =>
        {
            services
            .RemoveAll<ICurrentUserProvider>()
            .AddScoped<ICurrentUserProvider>(_ => TestCurrentUserProvider);

            services
            .RemoveAll<DbContextOptions<AppDbContext>>()
            .AddDbContext<AppDbContext>((sp, options) => options.UseNpgsql(TestDatabase.Connection));
        });

        builder.ConfigureAppConfiguration((context, conf) => conf.AddInMemoryCollection(new Dictionary<string, string?>
        {
            { "EmailSettings:EnableEmailNotifications", "false" }
        }));
    }
}

