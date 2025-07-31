using Silaf_Hospital.DTOs;
using Silaf_Hospital.Services;
using System;

namespace Silaf_Hospital.Menus
{
    public static class ClinicBranchMenu
    {
        public static void Show(string branchId, ClinicService clinicService)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("======= CLINIC MANAGEMENT (Branch) =======");
                Console.ResetColor();

                Console.WriteLine("1. Add Clinic");
                Console.WriteLine("2. View Clinics");
                Console.WriteLine("3. Update Clinic");
                Console.WriteLine("4. Delete Clinic");
                Console.WriteLine("5. Search by ID");
                Console.WriteLine("6. Search by Name");
                Console.WriteLine("0. Back");

                Console.Write("\nSelect option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddClinic(clinicService, branchId);
                        break;
                    case "2":
                        ViewClinics(clinicService, branchId);
                        break;
                    case "3":
                        UpdateClinic(clinicService, branchId);
                        break;
                    case "4":
                        DeleteClinic(clinicService, branchId);
                        break;
                    case "5":
                        SearchById(clinicService, branchId);
                        break;
                    case "6":
                        SearchByName(clinicService, branchId);
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

        private static void AddClinic(ClinicService service, string branchId)
        {
            Console.Write("Enter clinic name: ");
            string name = Console.ReadLine();

            Console.Write("Enter department ID (must exist in this branch): ");
            string departmentId = Console.ReadLine();

            ClinicInputDTO input = new ClinicInputDTO
            {
                Name = name,
                BranchId = branchId,
                DepartmentId = departmentId
            };

            service.AddClinic(input);
            Console.WriteLine("✅ Clinic added.");
            Console.ReadKey();
        }

        private static void ViewClinics(ClinicService service, string branchId)
        {
            var clinics = service.GetClinicsByBranchName(branchId);

            Console.WriteLine($"\nClinics in Branch '{branchId}':");
            foreach (var clinic in clinics)
            {
                Console.WriteLine($"🆔 {clinic.Id} | 🏥 {clinic.Name} | Dept: {clinic.DepartmentId}");
            }

            Console.ReadKey();
        }

        private static void UpdateClinic(ClinicService service, string branchId)
        {
            Console.Write("Enter clinic ID to update: ");
            string id = Console.ReadLine();

            var clinic = service.GetClinicById(id);
            if (clinic != null && clinic.BranchId == branchId)
            {
                Console.Write("New name: ");
                string name = Console.ReadLine();

                service.UpdateClinicName(id, name);
                Console.WriteLine("✅ Clinic updated.");
            }
            else
            {
                Console.WriteLine("❌ Clinic not found in your branch.");
            }

            Console.ReadKey();
        }

        private static void DeleteClinic(ClinicService service, string branchId)
        {
            Console.Write("Enter clinic ID to delete: ");
            string id = Console.ReadLine();

            var clinic = service.GetClinicById(id);
            if (clinic != null && clinic.BranchId == branchId)
            {
                service.DeleteClinic(id);
                Console.WriteLine("🗑️ Clinic deleted.");
            }
            else
            {
                Console.WriteLine("❌ Not in your branch.");
            }

            Console.ReadKey();
        }

        private static void SearchById(ClinicService service, string branchId)
        {
            Console.Write("Enter clinic ID: ");
            string id = Console.ReadLine();

            var clinic = service.GetClinicById(id);
            if (clinic != null && clinic.BranchId == branchId)
            {
                Console.WriteLine($"✅ Found: {clinic.Name} in Dept {clinic.DepartmentId}");
            }
            else
            {
                Console.WriteLine("❌ Not found in your branch.");
            }

            Console.ReadKey();
        }

        private static void SearchByName(ClinicService service, string branchId)
        {
            Console.Write("Enter clinic name: ");
            string name = Console.ReadLine();

            var clinic = service.GetClinicByName(name);
            if (clinic != null && clinic.BranchId == branchId)
            {
                Console.WriteLine($"✅ Found: {clinic.Name} | Dept {clinic.DepartmentId}");
            }
            else
            {
                Console.WriteLine("❌ Not found in your branch.");
            }

            Console.ReadKey();
        }
    }
}
