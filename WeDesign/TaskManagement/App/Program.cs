using System;
using WeDesign.TaskManagement;

namespace WeDesign.TaskManagement.App
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager taskManager = new TaskManager();
            TaskHelper taskHelper = new TaskHelper(taskManager);
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
                            taskHelper.AddTask();
                            break;
                        case "2":
                            taskHelper.UpdateTask();
                            break;
                        case "3":
                            taskHelper.MarkTaskAsCompleted();
                            break;
                        case "4":
                            taskHelper.ViewTasksByDueDate();
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
    }
}