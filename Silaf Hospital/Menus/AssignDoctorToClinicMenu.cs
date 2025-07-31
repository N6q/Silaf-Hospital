using Silaf_Hospital.Services;
using Silaf_Hospital.Models;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Menus
{
    public static class AssignDoctorToClinicMenu
    {
        public static void Show(string branchId, DoctorService doctorService, ClinicService clinicService)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("======= ASSIGN DOCTOR TO CLINIC =======");
                Console.ResetColor();

                Console.WriteLine("1. View Clinics in Your Branch");
                Console.WriteLine("2. View Unassigned Doctors in Branch");
                Console.WriteLine("3. Assign Doctor to Clinic");
                Console.WriteLine("0. Back");

                Console.Write("\nChoose an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewClinics(clinicService, branchId);
                        break;
                    case "2":
                        ViewUnassignedDoctors(doctorService, branchId);
                        break;
                    case "3":
                        AssignDoctor(doctorService, clinicService, branchId);
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

        private static void ViewClinics(ClinicService service, string branchId)
        {
            var clinics = service.GetClinicsByBranchName(branchId);
            Console.WriteLine($"\nClinics in Branch {branchId}:");

            foreach (var clinic in clinics)
            {
                Console.WriteLine($"🏥 ID: {clinic.Id} | Name: {clinic.Name}");
            }

            Console.ReadKey();
        }

        private static void ViewUnassignedDoctors(DoctorService service, string branchId)
        {
            var allDoctors = service.GetDoctorsByBranchName(branchId);
            Console.WriteLine("\nDoctors in your branch WITHOUT a clinic:");

            foreach (var doc in allDoctors)
            {
                if (string.IsNullOrWhiteSpace(doc.ClinicId))
                {
                    Console.WriteLine($"👨‍⚕️ {doc.FullName} | ID: {doc.NationalId}");
                }
            }

            Console.ReadKey();
        }

        private static void AssignDoctor(DoctorService doctorService, ClinicService clinicService, string branchId)
        {
            Console.Write("Enter Doctor National ID: ");
            string docId = Console.ReadLine();

            Doctor doctor = doctorService.GetDoctorById(docId);

            if (doctor == null || !doctor.ClinicId.StartsWith(branchId) && !string.IsNullOrWhiteSpace(doctor.ClinicId))
            {
                Console.WriteLine("❌ Doctor either not in your branch or already assigned.");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter Clinic ID to assign: ");
            string clinicId = Console.ReadLine();

            var clinic = clinicService.GetClinicById(clinicId);
            if (clinic == null || clinic.BranchId != branchId)
            {
                Console.WriteLine("❌ Clinic not in your branch.");
                Console.ReadKey();
                return;
            }

            doctor.ClinicId = clinicId;
            doctorService.UpdateDoctor(doctor);

            Console.WriteLine("✅ Doctor assigned to clinic.");
            Console.ReadKey();
        }
    }
}
