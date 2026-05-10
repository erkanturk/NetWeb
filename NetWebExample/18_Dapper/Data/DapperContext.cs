using Microsoft.Data.SqlClient;
using System.Data;

namespace _18_Dapper.Data
{
    public class DapperContext
    {
        private readonly string _context;
        public DapperContext(IConfiguration configuration)
        {
            _context = configuration.GetConnectionString("DefaultConnection");
        }
        public IDbConnection CreateConnection() => new SqlConnection(_context);
    }
}
