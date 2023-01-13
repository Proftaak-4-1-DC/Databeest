using MySql.Data.MySqlClient;

namespace Databeest.Common
{
    public class DB
    {
        private readonly IConfigurationBuilder ConfigBuilder = new ConfigurationBuilder();
        private string ConnectionString { get; set; }
        protected MySqlConnection Connection { get; set; }
        //public MySqlDataReader DataReader { get; set; }

        /*private MySqlCommand _command = new MySqlCommand();
        public MySqlCommand Command
        {
            get
            {
                return _command;
            }
            set
            {
                _command = value;
                _command.Connection = Connection;
                _command.ExecuteNonQuery();
            }
        }*/
        
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
