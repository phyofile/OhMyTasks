namespace TasksManagerMVC.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public required string Description { get; set; }
        public bool IsCompleted { get; set; }

        public TaskItem(string description)
        {
            Description = description;
            IsCompleted = false;
        }

        public TaskItem() { } // Default constructor for model binding
    }
}