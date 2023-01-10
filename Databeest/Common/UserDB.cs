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

            string query = "INSERT INTO users (username, password, email) VALUES ('" + user.Username + "', '" + user.Password + "', '" + user.Email + "')";
            MySqlCommand command = new MySqlCommand(query, Connection);
            command.ExecuteNonQuery();

            CloseConnection();

            return true;
        }

        // At this moment, we only need to select one user
        public  User Select(User user)
        {
            User resultUser = new User();
            
            OpenConnection();

            string query = "SELECT * FROM users WHERE username = '" + user.Username + "'";
            MySqlCommand command = new MySqlCommand(query, Connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                resultUser.Username = dataReader.GetString("username");
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

            string query = "UPDATE users SET 'score' = '" + user.Score + "' WHERE username='" + user.Username + "'";
            MySqlCommand command = new MySqlCommand(query, Connection);
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
