using System.ComponentModel.DataAnnotations;

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
        [DataType(DataType.Text)]
        public string? Name { get; set; }

        public TaskStatus Status { get; set; } = TaskStatus.NotStarted;
        public int? Points { get; set; }

        public Task()
        { }

        public Task(string name)
        {
            Name = name;
        }

        public Task(string name, TaskStatus status, int points)
        {
            Name = name;
            Status = status;
            Points = points;
        }

        public void FinishTask()
        {
            
        }
    }
}
