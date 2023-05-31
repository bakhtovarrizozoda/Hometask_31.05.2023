using System.Data;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Infrastructure.Context;

public class DapperContext
{
    private IConfiguration _iConfiguration;
    public DapperContext(IConfiguration iConfiguration)
    {
        _iConfiguration = iConfiguration;
    }

    public IDbConnection CreateConnection()
    {
        return new NpgsqlConnection(_iConfiguration.GetConnectionString("DefaultConnection"));
    }
}
