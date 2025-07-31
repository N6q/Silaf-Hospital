using Silaf_Hospital.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Silaf_Hospital.FilesHandling
{
    public class BookingFileHandler
    {
        private readonly string filePath = "data/bookings.txt";

        public void SaveBookings(List<Booking> bookings)
        {
            Directory.CreateDirectory("data");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Booking booking in bookings)
                {
                    writer.WriteLine($"{booking.Id},{booking.PatientId},{booking.DoctorId},{booking.ClinicId},{booking.AppointmentDate},{booking.Status},{booking.Notes}");
                }
            }

            Console.WriteLine(" Booking data saved.");
        }

        public List<Booking> LoadBookings()
        {
            List<Booking> bookings = new List<Booking>();

            if (!File.Exists(filePath))
                return bookings;

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 7)
                {
                    Booking booking = new Booking
                    {
                        Id = parts[0],
                        PatientId = parts[1],
                        DoctorId = parts[2],
                        ClinicId = parts[3],
                        AppointmentDate = DateTime.TryParse(parts[4], out var dt) ? dt : DateTime.Now,
                        Status = Enum.TryParse(parts[5], out BookingStatus status) ? status : BookingStatus.Pending,
                        Notes = parts[6]
                    };

                    bookings.Add(booking);
                }
            }

            Console.WriteLine(" Booking data loaded.");
            return bookings;
        }
    }
}
