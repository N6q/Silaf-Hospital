using Silaf_Hospital.Services;
using Silaf_Hospital.Models;
using System;

namespace Silaf_Hospital.Menus
{
    public static class AssignDepartmentToBranchMenu
    {
        public static void Show(DepartmentService departmentService, BranchService branchService)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("==== ASSIGN DEPARTMENT TO BRANCH ====");
                Console.ResetColor();

                Console.WriteLine("1. View All Departments");
                Console.WriteLine("2. View All Branches");
                Console.WriteLine("3. Assign Department");
                Console.WriteLine("0. Back");

                Console.Write("\nChoose an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewDepartments(departmentService);
                        break;
                    case "2":
                        ViewBranches(branchService);
                        break;
                    case "3":
                        Assign(departmentService, branchService);
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

        private static void ViewDepartments(DepartmentService service)
        {
            var departments = service.GetAllDepartments();
            Console.WriteLine("\nDepartments:");
            foreach (var d in departments)
            {
                Console.WriteLine($"🆔 {d.Id} | {d.Name} | Branch: {d.BranchId}");
            }
            Console.ReadKey();
        }

        private static void ViewBranches(BranchService service)
        {
            var branches = service.GetAllBranches();
            Console.WriteLine("\nBranches:");
            foreach (var b in branches)
            {
                Console.WriteLine($"🏢 {b.Id} | {b.Name} | {b.Location}");
            }
            Console.ReadKey();
        }

        private static void Assign(DepartmentService departmentService, BranchService branchService)
        {
            Console.Write("Enter Department ID: ");
            string depId = Console.ReadLine();

            var department = departmentService.GetDepartmentById(depId);
            if (department == null)
            {
                Console.WriteLine("❌ Department not found.");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter Branch ID: ");
            string branchId = Console.ReadLine();

            var branch = branchService.GetBranchById(branchId);
            if (branch == null)
            {
                Console.WriteLine("❌ Branch not found.");
                Console.ReadKey();
                return;
            }

            department.BranchId = branchId;

            departmentService.UpdateDepartment(new DTOs.DepartmentUpdateDTO
            {
                Id = department.Id,
                Name = department.Name
            });

            Console.WriteLine("✅ Department assigned to branch.");
            Console.ReadKey();
        }
    }
}
