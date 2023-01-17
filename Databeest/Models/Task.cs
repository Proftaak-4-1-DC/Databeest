using System.ComponentModel.DataAnnotations;

namespace Databeest.Models
{
    public enum TaskStatus
    {
        NotStarted = 0,
        Good = 1,
        Bad = 2
    }

    public class Task
    {
        public int? Id { get; set; } = -1;

        [DataType(DataType.Text)]
        public string? Name { get; set; }

        public TaskStatus Status { get; set; } = TaskStatus.NotStarted;
        public int? Points { get; set; }

        [DataType(DataType.Text)]
        public string? DescriptionBad { get; set; }

        [DataType(DataType.Text)]
        public string? DescriptionGood { get; set; }

        [DataType(DataType.Text)]
        public string? ShortBad { get; set; }

        [DataType(DataType.Text)]
        public string? ShortGood { get; set; }

        public string ReturnUrl { get; set; }

        public Task()
        { }

        public Task(string name, TaskStatus status, int points)
        {
            Name = name;
            Status = status;
            Points = points;
        }
    }
}
