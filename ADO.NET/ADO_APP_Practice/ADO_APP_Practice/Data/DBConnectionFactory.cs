using Microsoft.Data.SqlClient;

namespace ADO_APP_Practice.Data
{
    public class DBConnectionFactory
    {
        private readonly IConfiguration _configuration;
        public DBConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public SqlConnection CreateConnection()
        {
            string connection = _configuration.GetConnectionString("Con");
            return new SqlConnection(connection);
        }
    }
}
