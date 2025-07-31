using Silaf_Hospital.DTOs;
using Silaf_Hospital.Services;
using System;

namespace Silaf_Hospital.Menus
{
    public static class DoctorBranchMenu
    {
        public static void Show(string branchId, DoctorService doctorService)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("===== DOCTOR MANAGEMENT IN BRANCH =====");
                Console.ResetColor();

                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. View Doctors");
                Console.WriteLine("3. Update Doctor");
                Console.WriteLine("4. Delete Doctor");
                Console.WriteLine("5. Search by ID");
                Console.WriteLine("6. Search by Name");
                Console.WriteLine("0. Back");

                Console.Write("\nSelect an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddDoctor(doctorService, branchId);
                        break;
                    case "2":
                        ViewAll(doctorService, branchId);
                        break;
                    case "3":
                        UpdateDoctor(doctorService, branchId);
                        break;
                    case "4":
                        DeleteDoctor(doctorService, branchId);
                        break;
                    case "5":
                        SearchById(doctorService, branchId);
                        break;
                    case "6":
                        SearchByName(doctorService, branchId);
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

        private static void AddDoctor(DoctorService service, string branchId)
        {
            DoctorInputDTO input = new DoctorInputDTO();

            Console.Write("Full Name: ");
            input.FullName = Console.ReadLine();

            Console.Write("Email: ");
            input.Email = Console.ReadLine();

            Console.Write("Password: ");
            input.Password = Console.ReadLine();

            Console.Write("Phone Number: ");
            input.PhoneNumber = Console.ReadLine();

            Console.Write("National ID: ");
            input.NationalId = Console.ReadLine();

            Console.Write("Specialization: ");
            input.Specialization = Console.ReadLine();

            // ClinicId must belong to this branch
            Console.Write("Clinic ID (must belong to your branch): ");
            input.ClinicId = Console.ReadLine();

            service.AddDoctor(input);
            Console.ReadKey();
        }

        private static void ViewAll(DoctorService service, string branchId)
        {
            var doctors = service.GetDoctorsByBranchName(branchId); // assumes ClinicId contains branch info
            Console.WriteLine("\nDoctors in Your Branch:");
            foreach (var doc in doctors)
            {
                Console.WriteLine($"👨‍⚕️ {doc.FullName} | 📧 {doc.Email} | 🏥 Clinic: {doc.ClinicId}");
            }
            Console.ReadKey();
        }

        private static void UpdateDoctor(DoctorService service, string branchId)
        {
            Console.Write("Enter National ID: ");
            string nationalId = Console.ReadLine();

            var doctor = service.GetDoctorById(nationalId);
            if (doctor != null && doctor.ClinicId.StartsWith(branchId))
            {
                DoctorUpdateDTO input = new DoctorUpdateDTO();
                input.NationalId = nationalId;

                Console.Write("New Full Name: ");
                input.FullName = Console.ReadLine();

                Console.Write("New Email: ");
                input.Email = Console.ReadLine();

                Console.Write("New Password: ");
                input.Password = Console.ReadLine();

                Console.Write("New Phone Number: ");
                input.PhoneNumber = Console.ReadLine();

                Console.Write("New Specialization: ");
                input.Specialization = Console.ReadLine();

                Console.Write("New Clinic ID (must match your branch): ");
                input.ClinicId = Console.ReadLine();

                service.UpdateDoctorDetails(input);
            }
            else
            {
                Console.WriteLine("❌ Doctor not in your branch.");
            }

            Console.ReadKey();
        }

        private static void DeleteDoctor(DoctorService service, string branchId)
        {
            Console.Write("Enter National ID: ");
            string id = Console.ReadLine();

            var doctor = service.GetDoctorById(id);
            if (doctor != null && doctor.ClinicId.StartsWith(branchId))
            {
                service.DeleteDoctor(id);
                Console.WriteLine("✅ Doctor deleted.");
            }
            else
            {
                Console.WriteLine("❌ Doctor not in your branch.");
            }

            Console.ReadKey();
        }

        private static void SearchById(DoctorService service, string branchId)
        {
            Console.Write("Enter Doctor ID: ");
            string id = Console.ReadLine();

            var doc = service.GetDoctorById(id);
            if (doc != null && doc.ClinicId.StartsWith(branchId))
            {
                Console.WriteLine($"✅ Found: {doc.FullName}");
            }
            else
            {
                Console.WriteLine("❌ Not in your branch.");
            }

            Console.ReadKey();
        }

        private static void SearchByName(DoctorService service, string branchId)
        {
            Console.Write("Enter Doctor Name: ");
            string name = Console.ReadLine();

            var doc = service.GetDoctorByName(name);
            if (doc != null && doc.ClinicId.StartsWith(branchId))
            {
                Console.WriteLine($"✅ Found: {doc.FullName}");
            }
            else
            {
                Console.WriteLine("❌ Not in your branch.");
            }

            Console.ReadKey();
        }
    }
}
