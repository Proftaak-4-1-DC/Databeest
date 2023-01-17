using Databeest.Models;
using Task = Databeest.Models.Task;
using TaskStatus = Databeest.Models.TaskStatus;
using MySql.Data.MySqlClient;

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
            }

            CloseConnection();

            return task;
        }

        public Task SelectUserTask(User user, string taskname)
        {
            Task task = Select(taskname);

            OpenConnection();

            string query = "SELECT * FROM user_task WHERE user_id=@userid AND task_id=@taskid";

            MySqlCommand command = new MySqlCommand(query, Connection);
            command.Parameters.AddWithValue("@userid", user.Id);
            command.Parameters.AddWithValue("@taskid", task.Id);

            Task resultTask = new Task();
            MySqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                resultTask.Status = (TaskStatus)dataReader.GetInt32("status");
                resultTask.Id = dataReader.GetInt32("id");
            }

            CloseConnection();

            return resultTask;
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
    }
}
