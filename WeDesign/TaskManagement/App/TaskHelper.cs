using System;
using WeDesign.TaskManagement;

namespace WeDesign.TaskManagement.App
{
    public class TaskHelper
    {
        private readonly TaskManager _taskManager;

        public TaskHelper(TaskManager taskManager)
        {
            _taskManager = taskManager;
        }

        public void AddTask()
        {
            Task newTask = CreateTaskFromUserInput();
            _taskManager.AddTask(newTask);
            Console.WriteLine("Task added successfully!\n\n");
        }

        public void UpdateTask()
        {
            string title = GetNonEmptyInput("\nEnter the title of the task to update: ");
            Task updatedTask = CreateTaskFromUserInput();
            _taskManager.UpdateTask(title, updatedTask);
            Console.WriteLine("Task updated successfully!\n\n");
        }

        public void MarkTaskAsCompleted()
        {
            string title = GetNonEmptyInput("\nEnter the title of the task to mark as completed: ");
            _taskManager.MarkTaskAsCompleted(title);
            Console.WriteLine("Task marked as completed!\n\n");
        }

        public void ViewTasksByDueDate()
        {
            DateTime dueDate = GetValidDate("\nEnter Due Date (yyyy-mm-dd): ");

            var tasks = _taskManager.GetTasksByDueDate(dueDate);
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found for the given date.\n");
            }
            else
            {
                Console.WriteLine($"\nTasks due on {dueDate:yyyy-MM-dd}:");
                foreach (var task in tasks)
                {
                    Console.WriteLine(task.ToString());
                }
            }
        }

        private Task CreateTaskFromUserInput()
        {
            string title = GetNonEmptyInput("\nEnter Title: ");
            string description = GetNonEmptyInput("Enter Description: ");
            DateTime dueDate = GetValidDate("Enter Due Date (yyyy-mm-dd): ");

            return new Task(title, description, dueDate);
        }

        private string GetNonEmptyInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim() ?? string.Empty;
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty. Please try again.\n");
                }
            } while (string.IsNullOrEmpty(input));

            return input;
        }

        private DateTime GetValidDate(string prompt)
        {
            DateTime date;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()?.Trim() ?? string.Empty;

                if (DateTime.TryParseExact(input, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out date))
                {
                    if (date >= DateTime.Today)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The due date cannot be in the past. Please enter a date that is today or in the future.\n");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid date format. Please enter the date in the format (yyyy-mm-dd).\n");
                }
            }
            return date;
        }
    }
}
