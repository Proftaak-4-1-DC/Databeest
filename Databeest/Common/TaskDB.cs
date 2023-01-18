using Databeest.Models;
using Task = Databeest.Models.Task;
using TaskStatus = Databeest.Models.TaskStatus;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Databeest.Common
{
    public class TaskDB : DB
    {
        public TaskDB()
        {}

        public void CreateUserTasks(User user)
        {
            List<Task> tasks = SelectAll();

            OpenConnection();

            foreach (Task task in tasks)
            {
                string query = "INSERT INTO user_task(user_id, task_id, status) VALUES (@userid, @taskid, @status)";

                MySqlCommand command = new MySqlCommand(query, Connection);
                command.Parameters.AddWithValue("@userid", user.Id);
                command.Parameters.AddWithValue("@taskid", task.Id);
                command.Parameters.AddWithValue("@status", (int)task.Status);

                command.ExecuteNonQuery();
            }

            CloseConnection();
        }

        public List<Task> SelectAll()
        {
            List<Task> tasks = new List<Task>();

            OpenConnection();

            string query = "SELECT * FROM tasks";

            MySqlCommand command = new MySqlCommand(query, Connection);
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                Task task = new Task();
                task.Id = dataReader.GetInt32("id");
                task.Name = dataReader.GetString("name");
                task.Points = dataReader.GetInt32("points");
                task.DescriptionBad = dataReader.GetString("description_bad");
                task.DescriptionGood = dataReader.GetString("description_good");
                task.ShortBad = dataReader.GetString("short_bad");
                task.ShortGood = dataReader.GetString("short_good");
                task.ReturnUrl = dataReader.GetString("return_url");

                if (String.IsNullOrEmpty(task.ReturnUrl))
                    task.ReturnUrl = "/Main/Index";

                tasks.Add(task);
            }

            CloseConnection();

            return tasks;
        }

        public Task Select(string name)
        {
            Task task = new Task();

            OpenConnection();

            string query = "SELECT * FROM tasks WHERE name = @name";

            MySqlCommand command = new MySqlCommand(query, Connection);
            command.Parameters.AddWithValue("@name", name);

            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                task.Id = dataReader.GetInt32("id");
                task.Name = name;
                task.Points = dataReader.GetInt32("points");
                task.DescriptionBad = dataReader.GetString("description_bad");
                task.DescriptionGood = dataReader.GetString("description_good");
                task.ShortBad = dataReader.GetString("short_bad");
                task.ShortGood = dataReader.GetString("short_good");
                task.ReturnUrl = dataReader.GetString("return_url");

                if (String.IsNullOrEmpty(task.ReturnUrl))
                    task.ReturnUrl = "/Main/Index";
            }

            CloseConnection();

            return task;
        }

        public Task Select(int taskid)
        {
            Task task = new Task();

            OpenConnection();

            string query = "SELECT * FROM tasks WHERE id = @taskid";

            MySqlCommand command = new MySqlCommand(query, Connection);
            command.Parameters.AddWithValue("@taskid", taskid);

            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                task.Id = taskid;
                task.Name = dataReader.GetString("name");
                task.Points = dataReader.GetInt32("points");
                task.DescriptionBad = dataReader.GetString("description_bad");
                task.DescriptionGood = dataReader.GetString("description_good");
                task.ShortBad = dataReader.GetString("short_bad");
                task.ShortGood = dataReader.GetString("short_good");
                task.ReturnUrl = dataReader.GetString("return_url");

                if (String.IsNullOrEmpty(task.ReturnUrl))
                    task.ReturnUrl = "/Main/Index";
            }

            CloseConnection();

            return task;
        }

        public Task SelectUserTask(User user, string taskname)
        {
            // We get the general task
            Task task = Select(taskname);

            OpenConnection();

            string query = "SELECT * FROM user_task WHERE user_id=@userid AND task_id=@taskid";

            MySqlCommand command = new MySqlCommand(query, Connection);
            command.Parameters.AddWithValue("@userid", user.Id);
            command.Parameters.AddWithValue("@taskid", task.Id);

            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                // And then fill the user specific data
                task.Status = (TaskStatus)dataReader.GetInt32("status");
                task.IsShown = dataReader.GetInt32("is_shown") == 1 ? true : false;
            }

            CloseConnection();

            return task;
        }

        public Task SelectUserTask(User user, int taskid)
        {
            // We get the general task
            Task task = Select(taskid);

            OpenConnection();

            string query = "SELECT * FROM user_task WHERE user_id=@userid AND task_id=@taskid";

            MySqlCommand command = new MySqlCommand(query, Connection);
            command.Parameters.AddWithValue("@userid", user.Id);
            command.Parameters.AddWithValue("@taskid", taskid);

            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                // And then fill the user specific data
                task.Status = (TaskStatus)dataReader.GetInt32("status");
                task.IsShown = dataReader.GetInt32("is_shown") == 1 ? true : false;
            }

            CloseConnection();

            return task;
        }

        public void UpdateUserTask(User user, Task task)
        {
            OpenConnection();

            string query = "UPDATE user_task SET status=@status WHERE user_id=@userid AND task_id=@taskid";

            MySqlCommand command = new MySqlCommand(query, Connection);
            command.Parameters.AddWithValue("status", (int)task.Status);
            command.Parameters.AddWithValue("userid", user.Id);
            command.Parameters.AddWithValue("taskid", task.Id);

            command.ExecuteNonQuery();

            CloseConnection();
        }

        public void UpdateUserTask(User user, int taskid, TaskStatus status)
        {
            OpenConnection();

            string query = "UPDATE user_task SET status=@status WHERE user_id=@userid AND task_id=@taskid";

            MySqlCommand command = new MySqlCommand(query, Connection);
            command.Parameters.AddWithValue("status", (int)status);
            command.Parameters.AddWithValue("userid", user.Id);
            command.Parameters.AddWithValue("taskid", taskid);

            command.ExecuteNonQuery();

            CloseConnection();
        }

        public void UpdateUserTask(User user, int taskid, bool shown)
        {
            OpenConnection();

            string query = "UPDATE user_task SET is_shown=@shown WHERE user_id=@userid AND task_id=@taskid";

            MySqlCommand command = new MySqlCommand(query, Connection);
            command.Parameters.AddWithValue("shown", shown ? 1 : 0);
            command.Parameters.AddWithValue("userid", user.Id);
            command.Parameters.AddWithValue("taskid", taskid);

            command.ExecuteNonQuery();

            CloseConnection();
        }

        public void UpdateUserTask(int userid, Task task)
        {
            OpenConnection();

            string query = "UPDATE user_task SET status=@status WHERE user_id=@userid AND task_id=@taskid";

            MySqlCommand command = new MySqlCommand(query, Connection);
            command.Parameters.AddWithValue("status", (int)task.Status);
            command.Parameters.AddWithValue("userid", userid);
            command.Parameters.AddWithValue("taskid", task.Id);

            command.ExecuteNonQuery();

            CloseConnection();
        }

        public void UpdateUserTask(int userid, int taskid, TaskStatus status)
        {
            OpenConnection();

            string query = "UPDATE user_task SET status=@status WHERE user_id=@userid AND task_id=@taskid";

            MySqlCommand command = new MySqlCommand(query, Connection);
            command.Parameters.AddWithValue("status", (int)status);
            command.Parameters.AddWithValue("userid", userid);
            command.Parameters.AddWithValue("taskid", taskid);

            command.ExecuteNonQuery();

            CloseConnection();
        }
    }
}
