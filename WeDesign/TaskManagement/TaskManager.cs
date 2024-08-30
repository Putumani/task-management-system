using System;
using System.Collections.Generic;
using System.Linq;

namespace WeDesign.TaskManagement
{
    public class TaskManager
    {
        private List<Task> tasks = new List<Task>();

        public void AddTask(Task task)
        {
            if (TaskExists(task.Title))
            {
                throw new ArgumentException("A task with the same title already exists.\n\n");
            }
            tasks.Add(task);
        }

        public void UpdateTask(string title, Task updatedTask)
        {
            var task = FindTaskByTitle(title);
            task.Title = updatedTask.Title;
            task.Description = updatedTask.Description;
            task.DueDate = updatedTask.DueDate;
        }

        public void MarkTaskAsCompleted(string title)
        {
            var task = FindTaskByTitle(title);
            task.IsCompleted = true;
        }

        public List<Task> GetTasksByDueDate(DateTime date)
        {
            return tasks.Where(t => t.DueDate.Date == date.Date).ToList();
        }

        public void DisplayAllTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks available.\n\n");
            }
            else
            {
                Console.WriteLine("\nTask List:");
                foreach (var task in tasks)
                {
                    Console.WriteLine(task.ToString());
                }
            }
        }

        private Task FindTaskByTitle(string title)
        {
            var task = tasks.FirstOrDefault(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            if (task == null)
            {
                throw new KeyNotFoundException($"The task titled \"{title}\" is not found.");
            }
            return task;
        }

        private bool TaskExists(string title)
        {
            return tasks.Any(t => t.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }
    }
}
