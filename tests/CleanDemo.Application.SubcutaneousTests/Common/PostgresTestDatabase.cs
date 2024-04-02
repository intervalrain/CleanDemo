using CleanDemo.Infrastructure.Common;

using Microsoft.EntityFrameworkCore;

using Npgsql;

namespace CleanDemo.Application.SubcutaneousTests.Common;

public class PostgresTestDatabase : IDisposable
{
    public NpgsqlConnection Connection { get; } 

    public static PostgresTestDatabase CreateAndInitialize()
    {
        var testDatabase = new PostgresTestDatabase("DataSource=:memory");

        testDatabase.InitialDatabase();

        return testDatabase;
    }

    private void InitialDatabase()
    {
        Connection.Open();
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseNpgsql(Connection)
            .Options;

        using var context = new AppDbContext(options, null!, null!);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }

    public void ResetDatabase()
    {
        Connection.Close();
        InitialDatabase();
    }

    public void Dispose()
    {
        Connection.Close();
    }    

    private PostgresTestDatabase(string connectionString)
    {
        Connection = new NpgsqlConnection(connectionString);
    }
}

