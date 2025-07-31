using Silaf_Hospital.Services;
using Silaf_Hospital.Models;
using System;

namespace Silaf_Hospital.Menus
{
    public static class AssignAdminToBranchMenu
    {
        public static void Show(AdminService adminService, BranchService branchService)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("======= ASSIGN ADMIN TO BRANCH =======");
                Console.ResetColor();

                Console.WriteLine("1. View All Admins");
                Console.WriteLine("2. View All Branches");
                Console.WriteLine("3. Assign Admin");
                Console.WriteLine("0. Back");

                Console.Write("\nChoose option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAdmins(adminService);
                        break;
                    case "2":
                        ViewBranches(branchService);
                        break;
                    case "3":
                        Assign(adminService, branchService);
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

        private static void ViewAdmins(AdminService service)
        {
            var admins = service.GetAllAdmins();
            Console.WriteLine("\nAll Admins:");
            foreach (var a in admins)
            {
                Console.WriteLine($"🆔 {a.NationalId} | 👤 {a.FullName} | 📧 {a.Email} | 📍 Branch: {a.AssignedBranchId}");
            }
            Console.ReadKey();
        }

        private static void ViewBranches(BranchService service)
        {
            var branches = service.GetAllBranches();
            Console.WriteLine("\nAll Branches:");
            foreach (var b in branches)
            {
                Console.WriteLine($"🏢 ID: {b.Id} | Name: {b.Name} | Location: {b.Location}");
            }
            Console.ReadKey();
        }

        private static void Assign(AdminService adminService, BranchService branchService)
        {
            Console.Write("Enter Admin National ID: ");
            string adminId = Console.ReadLine();

            var admin = adminService.GetAdminById(adminId);
            if (admin == null)
            {
                Console.WriteLine("❌ Admin not found.");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter Branch ID to assign: ");
            string branchId = Console.ReadLine();

            var branch = branchService.GetBranchById(branchId);
            if (branch == null)
            {
                Console.WriteLine("❌ Branch not found.");
                Console.ReadKey();
                return;
            }

            admin.AssignedBranchId = branchId;
            adminService.UpdateAdmin(adminId, new DTOs.UserInputDTO
            {
                FullName = admin.FullName,
                Email = admin.Email,
                Password = admin.Password,
                PhoneNumber = admin.PhoneNumber,
                Gender = admin.Gender,
                Age = admin.Age,
                NationalID = admin.NationalId
            });

            Console.WriteLine("✅ Admin assigned to branch.");
            Console.ReadKey();
        }
    }
}
