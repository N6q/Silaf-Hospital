using Silaf_Hospital.DTOs;
using Silaf_Hospital.Services;
using Silaf_Hospital.Models;
using System;

namespace Silaf_Hospital.Menus
{
    public static class PatientBranchMenu
    {
        public static void Show(string branchId, PatientService patientService)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("===== PATIENT MANAGEMENT IN BRANCH =====");
                Console.ResetColor();

                Console.WriteLine("1. Add Patient");
                Console.WriteLine("2. View All Patients");
                Console.WriteLine("3. Update Patient");
                Console.WriteLine("4. Delete Patient");
                Console.WriteLine("5. Search by ID");
                Console.WriteLine("6. Search by Name");
                Console.WriteLine("0. Back");

                Console.Write("\nSelect option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddPatient(patientService, branchId);
                        break;
                    case "2":
                        ViewPatients(patientService, branchId);
                        break;
                    case "3":
                        UpdatePatient(patientService, branchId);
                        break;
                    case "4":
                        DeletePatient(patientService, branchId);
                        break;
                    case "5":
                        SearchById(patientService, branchId);
                        break;
                    case "6":
                        SearchByName(patientService, branchId);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("❌ Invalid input.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void AddPatient(PatientService service, string branchId)
        {
            PatientInputDTO input = new PatientInputDTO();

            Console.Write("Full Name: ");
            input.FullName = Console.ReadLine();

            Console.Write("Email: ");
            input.Email = Console.ReadLine();

            Console.Write("Password: ");
            input.Password = Console.ReadLine();

            Console.Write("Phone Number: ");
            input.PhoneNumber = Console.ReadLine();

            Console.Write("Gender: ");
            input.Gender = Console.ReadLine();

            Console.Write("Age: ");
            input.Age = int.Parse(Console.ReadLine());

            Console.Write("National ID: ");
            input.NationalID = Console.ReadLine();

            input.BranchId = branchId;

            service.AddPatient(input);
            Console.WriteLine("✅ Patient added.");
            Console.ReadKey();
        }

        private static void ViewPatients(PatientService service, string branchId)
        {
            var patients = service.GetPatientsByBranch(branchId);
            Console.WriteLine($"\nPatients in Branch '{branchId}':");

            foreach (var p in patients)
            {
                Console.WriteLine($"🧑 {p.FullName} | ID: {p.UserID} | 📞 {p.PhoneNumber}");
            }

            Console.ReadKey();
        }

        private static void UpdatePatient(PatientService service, string branchId)
        {
            Console.Write("Enter National ID: ");
            string nationalId = Console.ReadLine();

            var patient = service.GetPatientByNationalId(nationalId);
            if (patient != null && patient.BranchId == branchId)
            {
                PatientInputDTO input = new PatientInputDTO();
                input.NationalID = nationalId;

                Console.Write("New Full Name: ");
                input.FullName = Console.ReadLine();

                Console.Write("New Email: ");
                input.Email = Console.ReadLine();

                Console.Write("New Password: ");
                input.Password = Console.ReadLine();

                Console.Write("New Phone Number: ");
                input.PhoneNumber = Console.ReadLine();

                Console.Write("New Gender: ");
                input.Gender = Console.ReadLine();

                Console.Write("New Age: ");
                input.Age = int.Parse(Console.ReadLine());

                input.BranchId = branchId;

                service.UpdatePatient(input);
                Console.WriteLine("✅ Patient updated.");
            }
            else
            {
                Console.WriteLine("❌ Patient not found or not in your branch.");
            }

            Console.ReadKey();
        }

        private static void DeletePatient(PatientService service, string branchId)
        {
            Console.Write("Enter National ID: ");
            string id = Console.ReadLine();

            var patient = service.GetPatientByNationalId(id);
            if (patient != null && patient.BranchId == branchId)
            {
                service.DeletePatient(id);
                Console.WriteLine("✅ Patient deleted.");
            }
            else
            {
                Console.WriteLine("❌ Not found in your branch.");
            }

            Console.ReadKey();
        }

        private static void SearchById(PatientService service, string branchId)
        {
            Console.Write("Enter National ID: ");
            string id = Console.ReadLine();

            var p = service.GetPatientByNationalId(id);
            if (p != null && p.BranchId == branchId)
            {
                Console.WriteLine($"✅ Found: {p.FullName}, {p.Email}");
            }
            else
            {
                Console.WriteLine("❌ Not found in your branch.");
            }

            Console.ReadKey();
        }

        private static void SearchByName(PatientService service, string branchId)
        {
            Console.Write("Enter patient name: ");
            string name = Console.ReadLine();

            var p = service.GetPatientByName(name);
            if (p != null && p.BranchId == branchId)
            {
                Console.WriteLine($"✅ Found: {p.FullName}, {p.Email}");
            }
            else
            {
                Console.WriteLine("❌ Not found in your branch.");
            }

            Console.ReadKey();
        }
    }
}
