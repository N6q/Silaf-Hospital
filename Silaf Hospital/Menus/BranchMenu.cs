using Silaf_Hospital.DTOs;
using Silaf_Hospital.Services;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Menus
{
    public static class BranchMenu
    {
        public static void Show(BranchService branchService)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("======= BRANCH MANAGEMENT =======");
                Console.ResetColor();

                Console.WriteLine("1. Add Branch");
                Console.WriteLine("2. View All Branches");
                Console.WriteLine("3. Update Branch");
                Console.WriteLine("4. Delete Branch");
                Console.WriteLine("5. Search Branch by ID");
                Console.WriteLine("6. Search Branch by Name");
                Console.WriteLine("0. Back");

                Console.Write("\nChoose an option: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddBranch(branchService);
                        break;
                    case "2":
                        ViewAllBranches(branchService);
                        break;
                    case "3":
                        UpdateBranch(branchService);
                        break;
                    case "4":
                        DeleteBranch(branchService);
                        break;
                    case "5":
                        SearchById(branchService);
                        break;
                    case "6":
                        SearchByName(branchService);
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

        private static void AddBranch(BranchService service)
        {
            Console.Write("Enter branch name: ");
            string name = Console.ReadLine();
            Console.Write("Enter branch location: ");
            string location = Console.ReadLine();

            var input = new BranchInputDTO
            {
                Name = name,
                Location = location
            };

            service.AddBranch(input);
            Console.ReadKey();
        }

        private static void ViewAllBranches(BranchService service)
        {
            var branches = service.GetAllBranches();
            Console.WriteLine("\n=== Branch List ===");
            foreach (var branch in branches)
            {
                Console.WriteLine($"🆔 ID: {branch.Id} | 📍 {branch.Name} - {branch.Location}");
            }
            Console.ReadKey();
        }

        private static void UpdateBranch(BranchService service)
        {
            Console.Write("Enter branch ID to update: ");
            string id = Console.ReadLine();

            Console.Write("New name: ");
            string newName = Console.ReadLine();
            Console.Write("New location: ");
            string newLocation = Console.ReadLine();

            var update = new BranchUpdateDTO
            {
                Id = id,
                Name = newName,
                Location = newLocation
            };

            service.UpdateBranch(update);
            Console.ReadKey();
        }

        private static void DeleteBranch(BranchService service)
        {
            Console.Write("Enter branch ID to delete: ");
            string id = Console.ReadLine();
            service.DeleteBranch(id);
            Console.ReadKey();
        }

        private static void SearchById(BranchService service)
        {
            Console.Write("Enter branch ID: ");
            string id = Console.ReadLine();

            var branch = service.GetBranchById(id);
            if (branch != null)
            {
                Console.WriteLine($"✅ Found: {branch.Name} - {branch.Location}");
            }
            else
            {
                Console.WriteLine("❌ Branch not found.");
            }
            Console.ReadKey();
        }

        private static void SearchByName(BranchService service)
        {
            Console.Write("Enter branch name: ");
            string name = Console.ReadLine();

            var branch = service.GetBranchByName(name);
            if (branch != null)
            {
                Console.WriteLine($"✅ Found: {branch.Name} - {branch.Location}");
            }
            else
            {
                Console.WriteLine("❌ Branch not found.");
            }
            Console.ReadKey();
        }
    }
}
