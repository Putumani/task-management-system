using System;
using WeDesign.TaskManagement;

namespace WeDesign.TaskManagement.App
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Welcome to WeDesign Solutions Task Management System");
                Console.WriteLine("1. Add a new task");
                Console.WriteLine("2. Update an existing task");
                Console.WriteLine("3. Mark a task as completed");
                Console.WriteLine("4. View tasks by due date");
                Console.WriteLine("5. Display all tasks");
                Console.WriteLine("6. Exit");
                Console.Write("Please select an option: ");
                string choice = Console.ReadLine()?.Trim() ?? string.Empty;

                try
                {
                    switch (choice)
                    {
                        case "1":
                            AddTask(taskManager);
                            break;
                        case "2":
                            UpdateTask(taskManager);
                            break;
                        case "3":
                            MarkTaskAsCompleted(taskManager);
                            break;
                        case "4":
                            ViewTasksByDueDate(taskManager);
                            break;
                        case "5":
                            taskManager.DisplayAllTasks();
                            break;
                        case "6":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.\n\n");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}\n\n");
                }
            }
        }

        static void AddTask(TaskManager taskManager)
        {
            string title = GetNonEmptyInput("\nEnter Title: ");
            string description = GetNonEmptyInput("Enter Description: ");
            DateTime dueDate = GetValidDate("Enter Due Date (yyyy-mm-dd): ");

            Task newTask = new Task(title, description, dueDate);
            taskManager.AddTask(newTask);
            Console.WriteLine("Task added successfully!\n\n");
        }

        static void UpdateTask(TaskManager taskManager)
        {
            string title = GetNonEmptyInput("\nEnter the title of the task to update: ");
            string newTitle = GetNonEmptyInput("Enter new Title: ");
            string description = GetNonEmptyInput("Enter new Description: ");
            DateTime dueDate = GetValidDate("Enter new Due Date (yyyy-mm-dd): ");

            Task updatedTask = new Task(newTitle, description, dueDate);
            taskManager.UpdateTask(title, updatedTask);
            Console.WriteLine("Task updated successfully!\n\n");
        }

        static void MarkTaskAsCompleted(TaskManager taskManager)
        {
            string title = GetNonEmptyInput("\nEnter the title of the task to mark as completed: ");
            taskManager.MarkTaskAsCompleted(title);
            Console.WriteLine("Task marked as completed!\n\n");
        }

        static void ViewTasksByDueDate(TaskManager taskManager)
        {
            DateTime dueDate = GetValidDate("\nEnter Due Date (yyyy-mm-dd): ");
            var tasks = taskManager.GetTasksByDueDate(dueDate);
            if (tasks.Count == 0)
            {
                Console.WriteLine("No tasks found for the given date.\n\n");
            }
            else
            {
                foreach (var task in tasks)
                {
                    Console.WriteLine(task.ToString());
                }
            }
        }

        static string GetNonEmptyInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine()?.Trim() ?? string.Empty;
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty. Please try again.\n\n");
                }
            } while (string.IsNullOrEmpty(input));

            return input;
        }

        static DateTime GetValidDate(string prompt)
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
