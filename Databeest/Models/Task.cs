namespace Databeest.Models
{
    public enum TaskStatus
    {
        NotStarted,
        InProgress,
        Done
    }

    public class Task
    {
        public string Name { get; set; }
        public TaskStatus status { get; set; } = TaskStatus.NotStarted;
        public int Points { get; set; }

        Task(string name)
        {
            Name = name;
        }
    }
}
