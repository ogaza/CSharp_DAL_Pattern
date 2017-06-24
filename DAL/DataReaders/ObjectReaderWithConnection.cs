using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataReaders
{
    public abstract class ObjectReaderWithConnection<T> : ObjectReaderBase<T>
    {
        private static string _connectionString = @"DataSource = ...";
        //private static string _connectionString = 
        //    ConfigurationManager.ConnectionStrings["ConnectionName"].ConnectionString;

        protected override IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}