using Databeest.Models;
using MySql.Data.MySqlClient;

namespace Databeest.Common
{
    public class UserDB
    {
        static SqlManager sqlManager { get; set; } = new SqlManager();

        UserDB()
        { }

        public static void Create(User user)
        {
            sqlManager.OpenConnection();
            sqlManager.Command = new MySqlCommand("INSERT INTO users (username, password, email, score) VALUES (@username, @password, @email, @score)");
            sqlManager.CloseConnection();
        }
    }
}
