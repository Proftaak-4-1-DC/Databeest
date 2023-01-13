//using Databeest.Models;
//using MySql.Data.MySqlClient;

//namespace Databeest.Common
//{
//    public class UserDB
//    {
//        static SqlManager sqlManager { get; set; } = new SqlManager();

//        UserDB()
//        { }

//        public static void Create(User user)
//        {
//            sqlManager.OpenConnection();

//            string query = "INSERT INTO users (username, password, email) VALUES ('" + user.Username + "', '" + user.Password + "', '" + user.Email + "')";
//            sqlManager.Command = new MySqlCommand(query);

//            sqlManager.CloseConnection();
//        }

//        // At this moment, we only need to select one user
//        public static User Select(User user)
//        {
//            User resultUser = new User();
            
//            sqlManager.OpenConnection();

//            string query = "SELECT * FROM users WHERE username = '" + user.Username + "'";
//            sqlManager.Command = new MySqlCommand(query);

//            sqlManager.CloseConnection();
//        }

//        public static void Update(string username, User newUser)
//        {
//            sqlManager.OpenConnection();

//            // Do select first to check if user exists

//            // Update user
//            string query = "UPDATE users SET 'accepted_policy' = '" + newUser.AcceptedPolicy + "', 'score' = '" + newUser.Score + "' WHERE username='" + username + "'";
//            sqlManager.Command = new MySqlCommand(query);

//            sqlManager.CloseConnection();
//        }

//        public static void Delete(User user)
//        {
//            sqlManager.OpenConnection();

//            // Do select first to check if user exists
            

//            // Delete user
//            string query = "";
//            sqlManager.Command = new MySqlCommand(query);

//            sqlManager.CloseConnection();
//        }
//    }
//}
