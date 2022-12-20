using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Databeest.Common
{
    public class SqlManager // IDisposable? wanneer gebruiken?
    {
        private readonly IConfigurationBuilder ConfigBuilder = new ConfigurationBuilder();
        private string ConnectionString { get; set; }
        public MySqlConnection Connection { get; set; }
        
        private MySqlCommand _command;
        public MySqlCommand Command {
            get
            {
                return _command;
            }
            set
            {
                _command = value;
                _command.ExecuteNonQuery();
            } 
        }
        
        public MySqlDataReader DataReader { get; set; }

        public SqlManager()
        {
            ConfigBuilder.AddJsonFile("appsettings.json");
            IConfiguration configuration = ConfigBuilder.Build();
            ConnectionString = configuration["ConnectionStrings:ConnectionString"];
            Connection = new MySqlConnection(ConnectionString);
        }

        public void OpenConnection()
        {
            if (!String.IsNullOrEmpty(ConnectionString))
                Connection.Open();
        }

        public void CloseConnection()
        {
            if (!String.IsNullOrEmpty(ConnectionString))
                Connection.Close();
        }
    }
}
