
using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public class BookingService
    {
        private List<Booking> bookings = new List<Booking>();
        private readonly BookingFileHandler fileHandler = new BookingFileHandler();

        public BookingService()
        {
            LoadBookings();
        }

        public List<DateTime> GetAvailableSlots(string doctorId, DateTime date)
        {
            List<TimeSpan> bookedSlots = new List<TimeSpan>();
            foreach (var b in bookings)
            {
                if (b.DoctorId == doctorId && b.AppointmentDate.Date == date.Date)
                {
                    bookedSlots.Add(b.AppointmentDate.TimeOfDay);
                }
            }

            List<DateTime> slots = new List<DateTime>();
            DateTime start = date.Date.AddHours(6); // 6 AM
            for (int i = 0; i < 48; i++)
            {
                if (!bookedSlots.Contains(start.TimeOfDay))
                {
                    slots.Add(start);
                }
                start = start.AddMinutes(15);
            }

            return slots;
        }

        public void AddBooking(BookingInputDTO input)
        {
            Booking newBooking = new Booking();
            newBooking.PatientId = input.PatientId;
            newBooking.DoctorId = input.DoctorId;
            newBooking.ClinicId = input.ClinicId;
            newBooking.AppointmentDate = input.Slot;
            newBooking.Notes = input.Notes;
            newBooking.IsFirstVisit = input.IsFirstVisit;
            newBooking.IsBooked = true;
            newBooking.Status = BookingStatus.Confirmed;

            bookings.Add(newBooking);
            SaveBookings();
            Console.WriteLine("Booking added successfully.");
        }

        public List<Booking> GetBookingsByBranch(string branchId)
        {
            List<Booking> branchBookings = new List<Booking>();
            foreach (var booking in bookings)
            {
                if (booking.ClinicId != null && booking.ClinicId.Length >= branchId.Length)
                {
                    bool match = true;
                    for (int i = 0; i < branchId.Length; i++)
                    {
                        if (booking.ClinicId[i] != branchId[i])
                        {
                            match = false;
                            break;
                        }
                    }

                    if (match)
                    {
                        branchBookings.Add(booking);
                    }
                }
            }
            return branchBookings;
        }

        public List<Booking> GetBookingsByDoctorId(string doctorId)
        {
            List<Booking> result = new List<Booking>();
            foreach (var b in bookings)
            {
                if (b.DoctorId == doctorId)
                {
                    result.Add(b);
                }
            }
            return result;
        }

        public List<Booking> GetBookingsByPatientId(string patientId)
        {
            List<Booking> result = new List<Booking>();
            foreach (var b in bookings)
            {
                if (b.PatientId == patientId)
                {
                    result.Add(b);
                }
            }
            return result;
        }

        public void DeleteBooking(string bookingId)
        {
            Booking target = null;
            foreach (var b in bookings)
            {
                if (b.Id == bookingId)
                {
                    target = b;
                    break;
                }
            }

            if (target != null)
            {
                bookings.Remove(target);
                SaveBookings();
                Console.WriteLine("Booking deleted.");
            }
            else
            {
                Console.WriteLine("Booking not found.");
            }
        }

        public void SaveBookings()
        {
            fileHandler.SaveBookings(bookings);
        }

        public void LoadBookings()
        {
            bookings = fileHandler.LoadBookings();
            if (bookings == null)
            {
                bookings = new List<Booking>();
            }
        }
    }
}
