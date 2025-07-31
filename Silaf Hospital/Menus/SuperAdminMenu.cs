using Silaf_Hospital.Services;
using Silaf_Hospital.DTOs;
using System;

namespace Silaf_Hospital.Menus
{
    public static class SuperAdminMenu
    {
        public static void Show()
        {
            BranchService branchService = new BranchService();
            DepartmentService departmentService = new DepartmentService();
            BranchDepartmentService branchDepartmentService = new BranchDepartmentService();
            AdminService adminService = new AdminService();
            DoctorService doctorService = new DoctorService();

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("========== SUPER ADMIN MENU ==========");
                Console.ResetColor();
                Console.WriteLine("1. Manage Branches");
                Console.WriteLine("2. Manage Departments");
                Console.WriteLine("3. Assign Department to Branch");
                Console.WriteLine("4. Manage Admins");
                Console.WriteLine("5. Manage Doctors");
                Console.WriteLine("6. Assign Admin to Branch");
                Console.WriteLine("0. Back");
                Console.Write("\nChoose an option: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        BranchMenu.Show(branchService);
                        break;

                    case "2":
                        DepartmentMenu.Show(departmentService);
                        break;

                    case "3":
                        branchDepartmentService.AssignDepartmentToBranch();
                        break;

                    case "4":
                        AdminManagementMenu.Show(adminService);
                        break;

                    case "5":
                        DoctorManagementMenu.Show(doctorService);
                        break;

                    case "6":
                        branchService.AssignAdminToBranch();
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
    }
}
