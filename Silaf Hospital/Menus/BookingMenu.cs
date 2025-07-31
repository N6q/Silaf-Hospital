using Silaf_Hospital.DTOs;
using Silaf_Hospital.Services;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Menus
{
    public static class BookingMenu
    {
        public static void Show(string branchId, BookingService bookingService)
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("======== BOOKING MANAGEMENT ========");
                Console.ResetColor();

                Console.WriteLine("1. View Available Slots");
                Console.WriteLine("2. Add Booking");
                Console.WriteLine("3. View All Bookings");
                Console.WriteLine("4. Delete Booking");
                Console.WriteLine("0. Back");

                Console.Write("\nSelect an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        ShowAvailableSlots(bookingService, branchId);
                        break;
                    case "2":
                        AddBooking(bookingService, branchId);
                        break;
                    case "3":
                        ViewAllBookings(bookingService, branchId);
                        break;
                    case "4":
                        DeleteBooking(bookingService, branchId);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("❌ Invalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private static void ShowAvailableSlots(BookingService service, string branchId)
        {
            Console.Write("Enter Doctor ID: ");
            string doctorId = Console.ReadLine();

            Console.Write("Enter Date (yyyy-MM-dd): ");
            string dateInput = Console.ReadLine();
            DateTime date;
            if (!DateTime.TryParse(dateInput, out date))
            {
                Console.WriteLine("❌ Invalid date.");
                Console.ReadKey();
                return;
            }

            var availableSlots = service.GetAvailableSlots(doctorId, date);
            Console.WriteLine($"\nAvailable Slots for {date.ToShortDateString()}:");
            foreach (var slot in availableSlots)
            {
                Console.WriteLine("🕒 " + slot.ToString("hh:mm tt"));
            }

            Console.ReadKey();
        }

        private static void AddBooking(BookingService service, string branchId)
        {
            BookingInputDTO input = new BookingInputDTO();

            Console.Write("Enter Doctor ID: ");
            input.DoctorId = Console.ReadLine();

            Console.Write("Enter Patient ID: ");
            input.PatientId = Console.ReadLine();

            Console.Write("Enter Date (yyyy-MM-dd): ");
            string dateInput = Console.ReadLine();
            if (!DateTime.TryParse(dateInput, out DateTime date))
            {
                Console.WriteLine("❌ Invalid date.");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter Time Slot (e.g. 06:15): ");
            string time = Console.ReadLine();

            input.Slot = DateTime.Parse($"{date.ToShortDateString()} {time}");

            service.AddBooking(input);
            Console.ReadKey();
        }

        private static void ViewAllBookings(BookingService service, string branchId)
        {
            var bookings = service.GetBookingsByBranch(branchId);
            Console.WriteLine("\nAll Bookings:");
            foreach (var b in bookings)
            {
                Console.WriteLine($"📅 {b.Slot.ToShortDateString()} {b.Slot.ToShortTimeString()} | Doctor: {b.DoctorId} | Patient: {b.PatientId}");
            }
            Console.ReadKey();
        }

        private static void DeleteBooking(BookingService service, string branchId)
        {
            Console.Write("Enter Booking ID to delete: ");
            string id = Console.ReadLine();

            service.DeleteBooking(id);
            Console.WriteLine("🗑️ Booking deleted.");
            Console.ReadKey();
        }
    }
}
