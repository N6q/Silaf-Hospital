using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.Services;
using System;

namespace Silaf_Hospital.Menus
{
    public static class SuperAdminMenu
    {
        private static IAdminService adminService = new AdminService();
        private static IBranchService branchService = new BranchService();
        private static IBranchDepartmentService branchDepartmentService = new BranchDepartmentService();
        private static IDepartmentService departmentService = new DepartmentService();

        public static void Show(User currentUser)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==== Super Admin Menu ====");
                Console.WriteLine("1. Add Admin");
                Console.WriteLine("2. Add Branch");
                Console.WriteLine("3. Assign Department to Branch");
                Console.WriteLine("4. View All Admins");
                Console.WriteLine("5. View All Branches");
                Console.WriteLine("6. Logout");

                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddAdmin();
                        break;
                    case "2":
                        AddBranch();
                        break;
                    case "3":
                        AssignDepartmentToBranch();
                        break;
                    case "4":
                        ViewAllAdmins();
                        break;
                    case "5":
                        ViewAllBranches();
                        break;
                    case "6":
                        Console.WriteLine("Logging out...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        private static void AddAdmin()
        {
            var input = new AdminInputDTO();

            Console.Write("Full Name: ");
            input.FullName = Console.ReadLine();

            Console.Write("Email: ");
            input.Email = Console.ReadLine();

            Console.Write("Phone Number: ");
            input.PhoneNumber = Console.ReadLine();

            Console.Write("National ID: ");
            input.NationalId = Console.ReadLine();

            Console.Write("Password: ");
            input.Password = Console.ReadLine();

            adminService.AddAdmin(input);
            Console.WriteLine(" Admin added successfully.");
        }

        private static void AddBranch()
        {
            var input = new BranchInputDTO();

            Console.Write("Branch Name: ");
            input.Name = Console.ReadLine();

            Console.Write("Location: ");
            input.Location = Console.ReadLine();

            branchService.AddBranch(input);
            Console.WriteLine(" Branch added successfully.");
        }

        private static void AssignDepartmentToBranch()
        {
            Console.Write("Enter Branch ID: ");
            var branchId = Console.ReadLine();

            Console.Write("Enter Department ID: ");
            var deptId = Console.ReadLine();

            branchDepartmentService.AssignDepartmentToBranch(branchId, deptId);
            Console.WriteLine(" Department assigned to branch.");
        }

        private static void ViewAllAdmins()
        {
            var admins = adminService.GetAllAdmins();
            Console.WriteLine("---- All Admins ----");
            foreach (var admin in admins)
            {
                Console.WriteLine($"ID: {admin.Id} | Name: {admin.FullName} | Email: {admin.Email}");
            }
        }

        private static void ViewAllBranches()
        {
            var branches = branchService.GetAllBranches();
            Console.WriteLine("---- All Branches ----");
            foreach (var b in branches)
            {
                Console.WriteLine($"ID: {b.Id} | Name: {b.Name} | Location: {b.Location}");
            }
        }
    }
}
