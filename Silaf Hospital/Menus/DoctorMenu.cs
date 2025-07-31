using Silaf_Hospital.Services;
using System;

namespace Silaf_Hospital.Menus
{
    public static class DoctorMenu
    {
        public static void Show(string doctorId, BookingService bookingService, PatientRecordService recordService)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("======= DOCTOR MENU =======");
                Console.ResetColor();

                Console.WriteLine("1. View Appointments");
                Console.WriteLine("2. Manage Patient Records");
                Console.WriteLine("0. Logout");

                Console.Write("\nChoose an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ViewAppointments(bookingService, doctorId);
                        break;
                    case "2":
                        ManagePatientRecords(recordService, doctorId);
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

        private static void ViewAppointments(BookingService service, string doctorId)
        {
            var bookings = service.GetBookingsByDoctorId(doctorId);
            Console.WriteLine("\n📅 Appointments:");

            foreach (var b in bookings)
            {
                Console.WriteLine($"📅 {b.Slot.ToShortDateString()} {b.Slot.ToShortTimeString()} | Patient: {b.PatientId}");
            }

            Console.ReadKey();
        }

        private static void ManagePatientRecords(PatientRecordService service, string doctorId)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Manage Patient Records ===");

                var records = service.GetRecordsByDoctorId(doctorId);

                Console.WriteLine("\n1. View All Records");
                Console.WriteLine("2. Filter by Patient ID");
                Console.WriteLine("3. Add Record");
                Console.WriteLine("4. Back");
                Console.Write("\n> ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        foreach (var r in records)
                        {
                            Console.WriteLine($"📄 {r.Id} | Patient: {r.PatientId} | Date: {r.Date.ToShortDateString()}");
                        }
                        Console.ReadKey();
                        break;

                    case "2":
                        Console.Write("Enter Patient ID: ");
                        string pid = Console.ReadLine();
                        var filtered = service.GetRecordsByPatientId(pid);
                        foreach (var r in filtered)
                        {
                            Console.WriteLine($"📄 {r.Id} | Date: {r.Date.ToShortDateString()} | Note: {r.Note}");
                        }
                        Console.ReadKey();
                        break;

                    case "3":
                        Console.Write("Patient ID: ");
                        string patientId = Console.ReadLine();

                        Console.Write("Diagnosis: ");
                        string note = Console.ReadLine();

                        service.AddRecord(doctorId, patientId, note);
                        Console.WriteLine("✅ Record added.");
                        Console.ReadKey();
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("❌ Invalid.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
