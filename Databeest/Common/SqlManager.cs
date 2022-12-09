using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Databeest.Common
{
    /*using (var sqlconn = new ...)
    using (var sqlcom = new ...)
    {
        sqlcon.open();
        sqlcom.ExecuteNonQuery();
    }*/


public class SqlManager // IDisposable? wanneer gebruiken?
    {
        private readonly IConfigurationBuilder ConfigBuilder = new ConfigurationBuilder();
        private static string ConnectionString;
        //public MySqlConnection Connection = new MySqlConnection();

        public SqlManager()
        {
            ConfigBuilder.AddJsonFile("appsettings.json");
            IConfiguration configuration = ConfigBuilder.Build();
            ConnectionString = configuration["ConnectionStrings:ConnectionString"];

            OpenConnection();
        }


        public static void OpenConnection()
        {
            //Connection.Open();

            using (MySqlConnection connection = new MySqlConnection(ConnectionString))
            using (MySqlCommand command = new MySqlCommand())
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void CloseConnection()
        {
            //Connection.Close();
        }
    }
}
