using System;
using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.Services;

namespace Silaf_Hospital.Menus
{
    public static class DoctorMenu
    {
        private static BookingService bookingService = new BookingService();
        private static DiagnosisService diagnosisService = new DiagnosisService();
        private static PatientService patientService = new PatientService();

        public static void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=======================");
                Console.WriteLine("     DOCTOR PANEL      ");
                Console.WriteLine("=======================");
                Console.WriteLine("1. View Today's Appointments");
                Console.WriteLine("2. Add Diagnosis");
                Console.WriteLine("3. View Diagnoses by Patient");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        ViewAppointments();
                        break;
                    case "2":
                        AddDiagnosis();
                        break;
                    case "3":
                        ViewDiagnoses();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ViewAppointments()
        {
            Console.Write("Enter Clinic ID: ");
            int clinicId = int.Parse(Console.ReadLine());
            var today = DateTime.Today;
            var appointments = bookingService.ScheduledAppointments(clinicId, today);

            foreach (var b in appointments)
            {
                Console.WriteLine($"Booking ID: {b.Id} | Patient ID: {b.PatientId} | Time: {b.AppointmentDate}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void AddDiagnosis()
        {
            DiagnosisInputDTO input = new DiagnosisInputDTO();
            Console.Write("Patient ID: ");
            string patientId = Console.ReadLine();
            Console.Write("Diagnosis Name: ");
            input.Name = Console.ReadLine();
            Console.Write("Notes: ");
            input.Notes = Console.ReadLine();
            Console.Write("Severity: ");
            input.Severity = Console.ReadLine();

            string doctorId = "DOCTOR-123"; // For now hardcoded, later use logged-in doctor
            diagnosisService.AddDiagnosis(input, patientId, doctorId);

            Console.WriteLine("Diagnosis added. Press any key to continue...");
            Console.ReadKey();
        }

        private static void ViewDiagnoses()
        {
            Console.Write("Enter Patient ID: ");
            string patientId = Console.ReadLine();

            var diagnoses = diagnosisService.GetDiagnosesByPatientId(patientId);

            foreach (var d in diagnoses)
            {
                Console.WriteLine($"Diagnosis ID: {d.Id} | Name: {d.Name} | Date: {d.DateDiagnosed} | Notes: {d.Notes} | Severity: {d.Severity}");
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
