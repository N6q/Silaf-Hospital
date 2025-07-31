using System;
using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.Services;

namespace Silaf_Hospital.Menus
{
    public static class PatientMenu
    {
        private static BookingService bookingService = new BookingService();
        private static DiagnosisService diagnosisService = new DiagnosisService();
        private static FeedbackService feedbackService = new FeedbackService();

        public static void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=======================");
                Console.WriteLine("     PATIENT PANEL     ");
                Console.WriteLine("=======================");
                Console.WriteLine("1. Book Appointment");
                Console.WriteLine("2. View My Appointments");
                Console.WriteLine("3. View My Diagnoses");
                Console.WriteLine("4. Submit Feedback");
                Console.WriteLine("0. Back to Main Menu");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        BookAppointment();
                        break;
                    case "2":
                        ViewAppointments();
                        break;
                    case "3":
                        ViewDiagnoses();
                        break;
                    case "4":
                        SubmitFeedback();
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

        private static void BookAppointment()
        {
            Console.Write("Enter Clinic ID: ");
            int clinicId = int.Parse(Console.ReadLine());
            Console.Write("Enter Appointment Date (yyyy-MM-dd): ");
            DateTime date = DateTime.Parse(Console.ReadLine());

            BookingInputDTO input = new BookingInputDTO
            {
                ClinicId = clinicId.ToString(),
                AppointmentDate = date
            };

            Console.Write("Enter your Patient ID: ");
            int patientId = int.Parse(Console.ReadLine());

            bookingService.BookAppointment(input, patientId);
            Console.WriteLine("Appointment booked. Press any key to continue...");
            Console.ReadKey();
        }

        private static void ViewAppointments()
        {
            Console.Write("Enter your Patient ID: ");
            int patientId = int.Parse(Console.ReadLine());

            var appointments = bookingService.GetBookedAppointments(patientId);
            foreach (var b in appointments)
            {
                Console.WriteLine($"Booking ID: {b.Id} | Clinic ID: {b.ClinicId} | Date: {b.AppointmentDate} | Status: {(b.IsBooked ? "Booked" : "Canceled")}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void ViewDiagnoses()
        {
            Console.Write("Enter your Patient ID: ");
            string patientId = Console.ReadLine();

            var diagnoses = diagnosisService.GetDiagnosesByPatientId(patientId);
            foreach (var d in diagnoses)
            {
                Console.WriteLine($"Diagnosis ID: {d.Id} | Name: {d.Name} | Date: {d.DateDiagnosed} | Severity: {d.Severity} | Notes: {d.Notes}");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void SubmitFeedback()
        {
            FeedbackInputDTO input = new FeedbackInputDTO();
            Console.Write("Enter your Patient ID: ");
            string patientId = Console.ReadLine();
            Console.Write("Doctor ID: ");
            input.DoctorId = Console.ReadLine();
            Console.Write("Appointment ID: ");
            input.AppointmentId = Console.ReadLine();
            Console.Write("Rating (1-5): ");
            input.Rating = int.Parse(Console.ReadLine());
            Console.Write("Comment: ");
            input.Comment = Console.ReadLine();

            feedbackService.SubmitFeedback(input, patientId);
            Console.WriteLine("Feedback submitted. Press any key to continue...");
            Console.ReadKey();
        }
    }
}
