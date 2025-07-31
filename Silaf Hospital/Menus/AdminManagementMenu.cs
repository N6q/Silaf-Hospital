using Silaf_Hospital.DTOs;
using Silaf_Hospital.Services;
using System;

namespace Silaf_Hospital.Menus
{
    public static class AdminManagementMenu
    {
        public static void Show(AdminService adminService)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("======= ADMIN MANAGEMENT =======");
                Console.ResetColor();

                Console.WriteLine("1. Add Admin");
                Console.WriteLine("2. View All Admins");
                Console.WriteLine("3. Update Admin");
                Console.WriteLine("4. Delete Admin");
                Console.WriteLine("5. Search by National ID");
                Console.WriteLine("6. Search by Name");
                Console.WriteLine("0. Back");

                Console.Write("\nChoose an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddAdmin(adminService);
                        break;
                    case "2":
                        adminService.ViewAllAdmins();
                        Console.ReadKey();
                        break;
                    case "3":
                        UpdateAdmin(adminService);
                        break;
                    case "4":
                        DeleteAdmin(adminService);
                        break;
                    case "5":
                        SearchById(adminService);
                        break;
                    case "6":
                        SearchByName(adminService);
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

        private static void AddAdmin(AdminService service)
        {
            UserInputDTO userInput = new UserInputDTO();

            Console.Write("Full Name: ");
            userInput.FullName = Console.ReadLine();

            Console.Write("Email: ");
            userInput.Email = Console.ReadLine();

            Console.Write("Password: ");
            userInput.Password = Console.ReadLine();

            Console.Write("Phone Number: ");
            userInput.PhoneNumber = Console.ReadLine();

            Console.Write("Gender: ");
            userInput.Gender = Console.ReadLine();

            Console.Write("Age: ");
            userInput.Age = int.Parse(Console.ReadLine());

            Console.Write("National ID: ");
            userInput.NationalId = Console.ReadLine();

            Console.Write("Branch ID: ");
            string branchId = Console.ReadLine();

            AdminInputDTO adminInput = new AdminInputDTO
            {
                FullName = userInput.FullName,
                Email = userInput.Email,
                Password = userInput.Password,
                PhoneNumber = userInput.PhoneNumber,
                NationalId = userInput.NationalId,
                AssignedBranchId = branchId
            };


            service.AddAdmin(adminInput);
            Console.ReadKey();
        }



        private static void UpdateAdmin(AdminService service)
        {
            Console.Write("Enter National ID of admin to update: ");
            string nationalId = Console.ReadLine();

            UserInputDTO userInput = new UserInputDTO();
            userInput.NationalId = nationalId;

            Console.Write("New Full Name: ");
            userInput.FullName = Console.ReadLine();

            Console.Write("New Email: ");
            userInput.Email = Console.ReadLine();

            Console.Write("New Password: ");
            userInput.Password = Console.ReadLine();

            Console.Write("New Phone Number: ");
            userInput.PhoneNumber = Console.ReadLine();

            Console.Write("New Gender: ");
            userInput.Gender = Console.ReadLine();

            Console.Write("New Age: ");
            userInput.Age = int.Parse(Console.ReadLine());

            Console.Write("New Branch ID: ");
            string branchId = Console.ReadLine();

            // Convert to AdminUpdateDTO
            AdminUpdateDTO adminUpdate = new AdminUpdateDTO
            {
                NationalId = userInput.NationalId,
                FullName = userInput.FullName,
                Email = userInput.Email,
                Password = userInput.Password,
                PhoneNumber = userInput.PhoneNumber,
                AssignedBranchId = branchId
            };

            service.UpdateAdmin(adminUpdate);
            Console.ReadKey();
        }



        private static void DeleteAdmin(AdminService service)
        {
            Console.Write("Enter National ID of admin to delete: ");
            string id = Console.ReadLine();
            service.DeleteAdmin(id);
            Console.ReadKey();
        }

        private static void SearchById(AdminService service)
        {
            Console.Write("Enter National ID: ");
            string id = Console.ReadLine();

            var admin = service.GetAdminById(id);
            if (admin != null)
            {
                Console.WriteLine($"✅ Found: {admin.FullName}, {admin.Email}");
            }
            else
            {
                Console.WriteLine("❌ Admin not found.");
            }

            Console.ReadKey();
        }

        private static void SearchByName(AdminService service)
        {
            Console.Write("Enter Full Name: ");
            string name = Console.ReadLine();

            var admin = service.GetAdminByName(name);
            if (admin != null)
            {
                Console.WriteLine($"✅ Found: {admin.FullName}, {admin.Email}");
            }
            else
            {
                Console.WriteLine("❌ Admin not found.");
            }

            Console.ReadKey();
        }
    }
}
