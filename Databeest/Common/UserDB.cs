using Databeest.Models;
using MySql.Data.MySqlClient;

namespace Databeest.Common
{
    public class UserDB : DB
    {
        public UserDB()
        {}

        public bool Create(User user)
        {
            if (Exists(user))
                return false;

            OpenConnection();

            string query = "INSERT INTO users (username, password, email) VALUES (@username, @password, @email)";

            MySqlCommand command = new MySqlCommand(query, Connection);
            command.Parameters.AddWithValue("@username", user.Username);
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@email", user.Email);

            command.ExecuteNonQuery();

            CloseConnection();

            return true;
        }

        // At this moment, we only need to select one user
        public  User Select(User user)
        {
            User resultUser = new User();
            
            OpenConnection();

            string query = "SELECT * FROM users WHERE username = @username";

            MySqlCommand command = new MySqlCommand(query, Connection);
            command.Parameters.AddWithValue("@username", user.Username);

            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                resultUser.Id = dataReader.GetInt32("id");
                resultUser.Username = dataReader.GetString("username");
                resultUser.Password = dataReader.GetString("password");
                resultUser.Email = dataReader.GetString("email");
                resultUser.Score = dataReader.GetInt32("score");
            }

            CloseConnection();

            return resultUser;
        }

        public User Select(string username)
        {
            User user = new User();
            user.Username = username;

            return Select(user);
        }

        public bool Exists(User user)
        {
            User tempUser = Select(user);
            if (tempUser.Username == user.Username)
                return true;

            return false;
        }

        public bool Exists(string username)
        {
            User user = Select(username);
            if (user.Username == username)
                return true;

            return false;
        }

        public void Update(User user)
        {
            if (!Exists(user))
                return;

            OpenConnection();

            string query = "UPDATE users SET score = @score WHERE username=@username";

            MySqlCommand command = new MySqlCommand(query, Connection);
            command.Parameters.AddWithValue("score", user.Score);
            command.Parameters.AddWithValue("username", user.Username);

            command.ExecuteNonQuery();

            CloseConnection();
        }

        public void Update(string username, int score)
        {
            User user = new User();
            user.Username = username;
            user.Score = score;
            
            Update(user);
        }

        public void Delete(User user)
        {
            // Do select first to check if user exists
            if (!Exists(user))
                return;

            OpenConnection();

            string query = "";
            MySqlCommand command = new MySqlCommand(query, Connection);

            CloseConnection();
        }

        public void Delete(string username)
        {
            User user = new User();
            user.Username = username;
            
            Delete(user);
        }
    }
}
