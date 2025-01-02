using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace eCommerce.Infrastructure.DbContext;

public class DapperDbContext
{
    public IDbConnection DbConnection { get; }
    public DapperDbContext(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PostgresConnection");
        DbConnection = new NpgsqlConnection(connectionString);
    }
}
