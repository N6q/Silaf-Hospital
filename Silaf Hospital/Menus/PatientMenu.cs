using Silaf_Hospital.Services;
using Silaf_Hospital.DTOs;
using System;

namespace Silaf_Hospital.Menus
{
    public static class PatientMenu
    {
        public static void Show(string patientId, PatientService patientService, BookingService bookingService, PatientRecordService recordService)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("======= PATIENT MENU =======");
                Console.ResetColor();

                Console.WriteLine("1. View My Profile");
                Console.WriteLine("2. Update My Info");
                Console.WriteLine("3. Book Appointment");
                Console.WriteLine("4. View My Bookings");
                Console.WriteLine("5. View My Medical Records");
                Console.WriteLine("0. Logout");

                Console.Write("\nChoose an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewProfile(patientService, patientId);
                        break;
                    case "2":
                        UpdateProfile(patientService, patientId);
                        break;
                    case "3":
                        BookAppointment(bookingService, patientId);
                        break;
                    case "4":
                        ViewMyBookings(bookingService, patientId);
                        break;
                    case "5":
                        ViewMyRecords(recordService, patientId);
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

        private static void ViewProfile(PatientService service, string patientId)
        {
            var patient = service.GetPatientById(patientId);
            if (patient != null)
            {
                Console.WriteLine($"\n🧑 Name: {patient.FullName}");
                Console.WriteLine($"📧 Email: {patient.Email}");
                Console.WriteLine($"📞 Phone: {patient.PhoneNumber}");
                Console.WriteLine($"🎂 Age: {patient.Age}");
                Console.WriteLine($"🪪 National ID: {patient.NationalId}");
                Console.WriteLine($"🏢 Branch: {patient.BranchId}");
            }
            Console.ReadKey();
        }

        private static void UpdateProfile(PatientService service, string patientId)
        {
            var patient = service.GetPatientById(patientId);
            if (patient == null)
            {
                Console.WriteLine("❌ Patient not found.");
                Console.ReadKey();
                return;
            }

            PatientInputDTO dto = new PatientInputDTO();
            dto.NationalId = patient.NationalId;

            Console.Write("New Full Name: ");
            dto.FullName = Console.ReadLine();

            Console.Write("New Email: ");
            dto.Email = Console.ReadLine();

            Console.Write("New Password: ");
            dto.Password = Console.ReadLine();

            Console.Write("New Phone Number: ");
            dto.PhoneNumber = Console.ReadLine();

            Console.Write("New Gender: ");
            dto.Gender = Console.ReadLine();

            Console.Write("New Age: ");
            dto.Age = int.Parse(Console.ReadLine());

            dto.BranchId = patient.BranchId;

            service.UpdatePatient(dto);
            Console.WriteLine("✅ Profile updated.");
            Console.ReadKey();
        }

        private static void BookAppointment(BookingService service, string patientId)
        {
            BookingInputDTO dto = new BookingInputDTO();

            Console.Write("Enter Doctor ID: ");
            dto.DoctorId = Console.ReadLine();

            Console.Write("Enter Date (yyyy-MM-dd): ");
            string dateStr = Console.ReadLine();
            if (!DateTime.TryParse(dateStr, out DateTime date))
            {
                Console.WriteLine("❌ Invalid date.");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter Time (e.g. 06:30): ");
            string time = Console.ReadLine();
            dto.Slot = DateTime.Parse($"{date:yyyy-MM-dd} {time}");
            dto.PatientId = patientId;

            service.AddBooking(dto);
            Console.ReadKey();
        }

        private static void ViewMyBookings(BookingService service, string patientId)
        {
            var bookings = service.GetBookingsByPatientId(patientId);
            Console.WriteLine("\n📅 My Appointments:");

            foreach (var b in bookings)
            {
                Console.WriteLine($"📆 {b.Slot.ToShortDateString()} | 🕒 {b.Slot.ToShortTimeString()} | 👨‍⚕️ Doctor: {b.DoctorId}");
            }

            Console.ReadKey();
        }

        private static void ViewMyRecords(PatientRecordService service, string patientId)
        {
            var records = service.GetRecordsByPatientId(patientId);

            Console.WriteLine("\n📄 Medical Records:");
            foreach (var record in records)
            {
                Console.WriteLine($"📝 {record.VisitDate.ToShortDateString()} | Doctor: {record.DoctorId} | Note: {record.DiagnosisSummary}");
            }

            Console.ReadKey();
        }
    }
}
