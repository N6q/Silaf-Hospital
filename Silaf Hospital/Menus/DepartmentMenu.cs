using Silaf_Hospital.DTOs;
using Silaf_Hospital.Services;
using System;

namespace Silaf_Hospital.Menus
{
    public static class DepartmentMenu
    {
        public static void Show(DepartmentService departmentService)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("======= DEPARTMENT MANAGEMENT =======");
                Console.ResetColor();

                Console.WriteLine("1. Add Department");
                Console.WriteLine("2. View All Departments");
                Console.WriteLine("3. Update Department");
                Console.WriteLine("4. Delete Department");
                Console.WriteLine("5. Search Department by ID");
                Console.WriteLine("6. Search Department by Name");
                Console.WriteLine("0. Back");

                Console.Write("\nChoose an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddDepartment(departmentService);
                        break;
                    case "2":
                        ViewAll(departmentService);
                        break;
                    case "3":
                        Update(departmentService);
                        break;
                    case "4":
                        Delete(departmentService);
                        break;
                    case "5":
                        SearchById(departmentService);
                        break;
                    case "6":
                        SearchByName(departmentService);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("❌ Invalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void AddDepartment(DepartmentService service)
        {
            Console.Write("Enter department name: ");
            string name = Console.ReadLine();

            var input = new DepartmentInputDTO { Name = name };
            service.AddDepartment(input);

            Console.WriteLine("✅ Department added.");
            Console.ReadKey();
        }

        private static void ViewAll(DepartmentService service)
        {
            var departments = service.GetAllDepartments();

            Console.WriteLine("\nAll Departments:");
            foreach (var dep in departments)
            {
                Console.WriteLine($"🆔 ID: {dep.Id} | 🏥 Name: {dep.Name}");
            }

            Console.ReadKey();
        }

        private static void Update(DepartmentService service)
        {
            Console.Write("Enter department ID: ");
            string id = Console.ReadLine();

            Console.Write("New department name: ");
            string name = Console.ReadLine();

            var dto = new DepartmentUpdateDTO { Id = id, Name = name };
            service.UpdateDepartment(dto);

            Console.WriteLine("✅ Department updated.");
            Console.ReadKey();
        }

        private static void Delete(DepartmentService service)
        {
            Console.Write("Enter department ID to delete: ");
            string id = Console.ReadLine();

            service.DeleteDepartment(id);
            Console.ReadKey();
        }

        private static void SearchById(DepartmentService service)
        {
            Console.Write("Enter department ID: ");
            string id = Console.ReadLine();

            var result = service.GetDepartmentById(id);
            if (result != null)
            {
                Console.WriteLine($"✅ Found: {result.Name}");
            }
            else
            {
                Console.WriteLine("❌ Not found.");
            }

            Console.ReadKey();
        }

        private static void SearchByName(DepartmentService service)
        {
            Console.Write("Enter department name: ");
            string name = Console.ReadLine();

            var result = service.GetDepartmentByName(name);
            if (result != null)
            {
                Console.WriteLine($"✅ Found: {result.Name}");
            }
            else
            {
                Console.WriteLine("❌ Not found.");
            }

            Console.ReadKey();
        }
    }
}
