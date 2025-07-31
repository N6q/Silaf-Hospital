using System;
using Silaf_Hospital.DTOs;
using Silaf_Hospital.Services;

namespace Silaf_Hospital.Menus
{
    public static class AdminMenu
    {
        private static readonly IDepartmentService departmentService = new DepartmentService();

        public static void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Admin Menu ===");
                Console.WriteLine("1. Add Department");
                Console.WriteLine("2. View Departments");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Select option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddDepartment();
                        break;
                    case "2":
                        ViewDepartments();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press any key...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void AddDepartment()
        {
            Console.Write("Enter Department Name: ");
            string name = Console.ReadLine();

            var input = new DepartmentInputDTO { Name = name };
            departmentService.AddDepartment(input);

            Console.WriteLine("Department added. Press any key...");
            Console.ReadKey();
        }

        private static void ViewDepartments()
        {
            var departments = departmentService.GetAllDepartments();
            Console.WriteLine("=== Department List ===");
            foreach (var d in departments)
            {
                Console.WriteLine($"ID: {d.Id}, Name: {d.Name}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
