using Silaf_Hospital.DTOs;
using Silaf_Hospital.Services;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Menus
{
    public static class DepartmentBranchMenu
    {
        public static void Show(string branchId, DepartmentService departmentService)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("===== DEPARTMENTS IN YOUR BRANCH =====");
                Console.ResetColor();

                Console.WriteLine("1. Add Department");
                Console.WriteLine("2. View All Departments");
                Console.WriteLine("3. Update Department");
                Console.WriteLine("4. Delete Department");
                Console.WriteLine("5. Search by ID");
                Console.WriteLine("6. Search by Name");
                Console.WriteLine("0. Back");

                Console.Write("\nSelect an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Add(departmentService, branchId);
                        break;
                    case "2":
                        ViewAll(departmentService, branchId);
                        break;
                    case "3":
                        Update(departmentService, branchId);
                        break;
                    case "4":
                        Delete(departmentService, branchId);
                        break;
                    case "5":
                        SearchById(departmentService, branchId);
                        break;
                    case "6":
                        SearchByName(departmentService, branchId);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("❌ Invalid option.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void Add(DepartmentService service, string branchId)
        {
            Console.Write("Enter department name: ");
            string name = Console.ReadLine();

            DepartmentInputDTO dto = new DepartmentInputDTO
            {
                Name = name,
                BranchId = branchId
            };

            service.AddDepartment(dto);
            Console.WriteLine("✅ Department added to your branch.");
            Console.ReadKey();
        }

        private static void ViewAll(DepartmentService service, string branchId)
        {
            var departments = service.GetDepartmentsByBranch(branchId);
            Console.WriteLine($"\nDepartments in Branch {branchId}:");

            foreach (var dep in departments)
            {
                Console.WriteLine($"🆔 {dep.Id} | 📛 {dep.Name}");
            }

            Console.ReadKey();
        }

        private static void Update(DepartmentService service, string branchId)
        {
            Console.Write("Enter Department ID to update: ");
            string id = Console.ReadLine();

            var department = service.GetDepartmentById(id);
            if (department != null && department.BranchId == branchId)
            {
                Console.Write("New department name: ");
                string newName = Console.ReadLine();

                DepartmentUpdateDTO dto = new DepartmentUpdateDTO
                {
                    Id = id,
                    Name = newName
                };

                service.UpdateDepartment(dto);
                Console.WriteLine("✅ Department updated.");
            }
            else
            {
                Console.WriteLine("❌ Department not found in your branch.");
            }

            Console.ReadKey();
        }

        private static void Delete(DepartmentService service, string branchId)
        {
            Console.Write("Enter Department ID to delete: ");
            string id = Console.ReadLine();

            var department = service.GetDepartmentById(id);
            if (department != null && department.BranchId == branchId)
            {
                service.DeleteDepartment(id);
                Console.WriteLine("🗑️ Department deleted.");
            }
            else
            {
                Console.WriteLine("❌ Not in your branch.");
            }

            Console.ReadKey();
        }

        private static void SearchById(DepartmentService service, string branchId)
        {
            Console.Write("Enter Department ID: ");
            string id = Console.ReadLine();

            var dep = service.GetDepartmentById(id);
            if (dep != null && dep.BranchId == branchId)
            {
                Console.WriteLine($"✅ Found: {dep.Name}");
            }
            else
            {
                Console.WriteLine("❌ Department not found in your branch.");
            }

            Console.ReadKey();
        }

        private static void SearchByName(DepartmentService service, string branchId)
        {
            Console.Write("Enter Department Name: ");
            string name = Console.ReadLine();

            var dep = service.GetDepartmentByName(name);
            if (dep != null && dep.BranchId == branchId)
            {
                Console.WriteLine($"✅ Found: {dep.Name}");
            }
            else
            {
                Console.WriteLine("❌ Not found in your branch.");
            }

            Console.ReadKey();
        }
    }
}
