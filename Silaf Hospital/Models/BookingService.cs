using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public class BookingService : IBookingService
    {
        private List<Booking> bookings = new List<Booking>();
        private readonly BookingFileHandler fileHandler = new BookingFileHandler();

        public BookingService()
        {
            bookings = fileHandler.LoadBookings();
        }

        public void BookAppointment(BookingInputDTO input, int patientId)
        {
            var booking = new Booking
            {
                Id = Guid.NewGuid().ToString(),
                PatientId = patientId.ToString(),
                ClinicId = input.ClinicId.ToString(),
                AppointmentDate = input.AppointmentDate,
                IsBooked = true
            };

            bookings.Add(booking);
            fileHandler.SaveBookings(bookings);
            Console.WriteLine(" Appointment booked.");
        }

        public void CancelAppointment(BookingInputDTO input, int patientId)
        {
            foreach (var booking in bookings)
            {
                if (booking.PatientId == patientId.ToString() &&
                    booking.ClinicId == input.ClinicId.ToString() &&
                    booking.AppointmentDate == input.AppointmentDate &&
                    booking.IsBooked)
                {
                    booking.IsBooked = false;
                    fileHandler.SaveBookings(bookings);
                    Console.WriteLine(" Appointment cancelled.");
                    return;
                }
            }

            Console.WriteLine(" Appointment not found.");
        }

        public void DeleteAppointments(BookingInputDTO input)
        {
            bookings.RemoveAll(b =>
                b.ClinicId == input.ClinicId.ToString() &&
                b.AppointmentDate == input.AppointmentDate);

            fileHandler.SaveBookings(bookings);
            Console.WriteLine(" Appointment(s) deleted.");
        }

        public IEnumerable<BookingInputDTO> GetAvailableAppointmentsBy(int? clinicId, int? departmentId)
        {
            List<BookingInputDTO> result = new List<BookingInputDTO>();

            foreach (var booking in bookings)
            {
                if (!booking.IsBooked &&
                    (clinicId == null || booking.ClinicId == clinicId.Value.ToString()))
                {
                    result.Add(new BookingInputDTO
                    {
                        ClinicId = booking.ClinicId,
                        AppointmentDate = booking.AppointmentDate
                    });
                }
            }


            return result;
        }

        public IEnumerable<BookingOutputDTO> GetBookedAppointments(int patientId)
        {
            List<BookingOutputDTO> result = new List<BookingOutputDTO>();

            foreach (var booking in bookings)
            {
                if (booking.PatientId == patientId.ToString() && booking.IsBooked)
                {
                    result.Add(new BookingOutputDTO
                    {
                        Id = booking.Id,
                        ClinicId = booking.ClinicId,
                        AppointmentDate = booking.AppointmentDate,
                        IsBooked = booking.IsBooked
                    });
                }
            }

            return result;
        }

        public Booking GetBookingById(int bookingId)
        {
            foreach (var booking in bookings)
            {
                if (booking.Id == bookingId.ToString())
                    return booking;
            }

            return null;
        }

        public IEnumerable<Booking> GetBookingsByClinicAndDate(int clinicId, DateTime date)
        {
            List<Booking> result = new List<Booking>();

            foreach (var booking in bookings)
            {
                if (booking.ClinicId == clinicId.ToString() &&
                    booking.AppointmentDate.Date == date.Date)
                {
                    result.Add(booking);
                }
            }

            return result;
        }

        public IEnumerable<Booking> ScheduledAppointments(int cid, DateTime appointmentDate)
        {
            List<Booking> result = new List<Booking>();

            foreach (var booking in bookings)
            {
                if (booking.ClinicId == cid.ToString() &&
                    booking.AppointmentDate.Date == appointmentDate.Date &&
                    booking.IsBooked)
                {
                    result.Add(booking);
                }
            }

            return result;
        }

        public void UpdateBookedAppointment(BookingInputDTO previousAppointment, BookingInputDTO newAppointment, int patientId)
        {
            foreach (var booking in bookings)
            {
                if (booking.PatientId == patientId.ToString() &&
                    booking.ClinicId == previousAppointment.ClinicId.ToString() &&
                    booking.AppointmentDate == previousAppointment.AppointmentDate &&
                    booking.IsBooked)
                {
                    booking.ClinicId = newAppointment.ClinicId.ToString();
                    booking.AppointmentDate = newAppointment.AppointmentDate;

                    fileHandler.SaveBookings(bookings);
                    Console.WriteLine(" Appointment updated.");
                    return;
                }
            }

            Console.WriteLine(" Appointment not found.");
        }

        public IEnumerable<BookingOutputDTO> GetAllBooking()
        {
            List<BookingOutputDTO> result = new List<BookingOutputDTO>();

            foreach (var booking in bookings)
            {
                result.Add(new BookingOutputDTO
                {
                    Id = booking.Id,
                    ClinicId = booking.ClinicId,
                    AppointmentDate = booking.AppointmentDate,
                    IsBooked = booking.IsBooked
                });
            }

            return result;
        }
    }
}
