using Silaf_Hospital.DTOs;
using Silaf_Hospital.Services;
using System;

namespace Silaf_Hospital.Menus
{
    public static class DoctorManagementMenu
    {
        public static void Show(DoctorService doctorService)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("======= DOCTOR MANAGEMENT =======");
                Console.ResetColor();

                Console.WriteLine("1. Add Doctor");
                Console.WriteLine("2. View All Doctors");
                Console.WriteLine("3. Update Doctor");
                Console.WriteLine("4. Delete Doctor");
                Console.WriteLine("5. Search by National ID");
                Console.WriteLine("6. Search by Name");
                Console.WriteLine("0. Back");

                Console.Write("\nChoose an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        AddDoctor(doctorService);
                        break;
                    case "2":
                        ViewAllDoctors(doctorService);
                        break;
                    case "3":
                        UpdateDoctor(doctorService);
                        break;
                    case "4":
                        DeleteDoctor(doctorService);
                        break;
                    case "5":
                        SearchById(doctorService);
                        break;
                    case "6":
                        SearchByName(doctorService);
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

        private static void AddDoctor(DoctorService service)
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

            Console.Write("Clinic ID: ");
            input.ClinicId = Console.ReadLine();

            service.AddDoctor(input);
            Console.ReadKey();
        }

        private static void ViewAllDoctors(DoctorService service)
        {
            var doctors = service.GetAllDoctors();
            Console.WriteLine("\n=== Doctor List ===");
            foreach (var doc in doctors)
            {
                Console.WriteLine($"🆔 {doc.NationalId} | 👨‍⚕️ {doc.FullName} | 📞 {doc.PhoneNumber} | 📧 {doc.Email} | 🏥 {doc.ClinicId}");
            }
            Console.ReadKey();
        }

        private static void UpdateDoctor(DoctorService service)
        {
            Console.Write("Enter National ID of doctor to update: ");
            string nationalId = Console.ReadLine();

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

            Console.Write("New Clinic ID: ");
            input.ClinicId = Console.ReadLine();

            service.UpdateDoctorDetails(input);
            Console.ReadKey();
        }

        private static void DeleteDoctor(DoctorService service)
        {
            Console.Write("Enter National ID of doctor to delete: ");
            string id = Console.ReadLine();

            service.DeleteDoctor(id);
            Console.ReadKey();
        }

        private static void SearchById(DoctorService service)
        {
            Console.Write("Enter National ID: ");
            string id = Console.ReadLine();

            var doc = service.GetDoctorById(id);
            if (doc != null)
            {
                Console.WriteLine($"✅ Found: {doc.FullName}, {doc.Email}, {doc.ClinicId}");
            }
            else
            {
                Console.WriteLine("❌ Doctor not found.");
            }
            Console.ReadKey();
        }

        private static void SearchByName(DoctorService service)
        {
            Console.Write("Enter Doctor Name: ");
            string name = Console.ReadLine();

            var doc = service.GetDoctorByName(name);
            if (doc != null)
            {
                Console.WriteLine($"✅ Found: {doc.FullName}, {doc.Email}, {doc.ClinicId}");
            }
            else
            {
                Console.WriteLine("❌ Doctor not found.");
            }
            Console.ReadKey();
        }
    }
}
