

using System.Data;
using System.Data.SqlClient;

namespace Alura.Cursos.DesignPatterns.Factory
{
    class ConnectionFactory
    {
        public IDbConnection GetConnection()
        {
            var connectionString = new FactoryConnectionString().GetConnectionString();
            var connection = new SqlConnection(connectionString);
            connection.Open();

            return connection;
        }
    }
}
