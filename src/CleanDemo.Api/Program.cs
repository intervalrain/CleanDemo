using CleanDemo.Api;
using CleanDemo.Application;
using CleanDemo.Infrastructure; 

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentension()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
}

var app = builder.Build();
{
    app.UseInfrastructure();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();

    app.Run();
}