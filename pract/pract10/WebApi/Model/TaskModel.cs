namespace WebApi.Model
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime ExecutionTime { get; set; }
        public TaskStatus Status { get; set; }
    }

    public enum TaskStatus
    {
        NotStart,
        Running,
        Delayed,
        Complete
    }
}
