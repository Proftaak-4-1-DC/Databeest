using MySql.Data.MySqlClient;

namespace Databeest.Common
{
    public class DB
    {
        private readonly IConfigurationBuilder ConfigBuilder = new ConfigurationBuilder();
        private string ConnectionString { get; set; }
        protected MySqlConnection Connection { get; set; }
        
        public DB()
        {
            ConfigBuilder.AddJsonFile("appsettings.json");
            IConfiguration configuration = ConfigBuilder.Build();
            ConnectionString = configuration["ConnectionStrings:ConnectionString"];
            Connection = new MySqlConnection(ConnectionString);
        }

        protected void OpenConnection()
        {
            if (!String.IsNullOrEmpty(ConnectionString) && Connection.State != System.Data.ConnectionState.Open)
                Connection.Open();
        }

        protected void CloseConnection()
        {
            if (!String.IsNullOrEmpty(ConnectionString) && Connection.State != System.Data.ConnectionState.Closed)
                Connection.Close();
        }
    }
}
