using Databeest.Common;
using MySql.Data.MySqlClient;

namespace Databeest.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Score { get; set; } = 0;

        public User()
        { }

        User(string username, string password)
        {
            Username = username;
            Password = password;

            Email = Username + "@databeast.nl";
        }
    }
}
