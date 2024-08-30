using System;

namespace WeDesign.TaskManagement
{
    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }

        public Task(string title, string description, DateTime dueDate)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            IsCompleted = false;
        }

        public override string ToString()
        {
            return $"Title: {Title}, Description: {Description}, Due Date: {DueDate:yyyy-MM-dd}, Completed: {(IsCompleted ? "Yes" : "No")}";
        }
    }
}
