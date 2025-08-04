using System;

namespace Silaf_Hospital.Models
{
    public enum BookingStatus
    {
        Pending,
        Confirmed,
        Cancelled,
        Completed
    }

    public class Booking
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public string ClinicId { get; set; }

        public DateTime AppointmentDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public BookingStatus Status { get; set; } = BookingStatus.Pending;
        public string Notes { get; set; }
        public bool IsBooked { get; set; }
        public DateTime Slot { get; set; }

        public bool IsFirstVisit { get; set; } = false;

        public void MarkAsCompleted()
        {
            Status = BookingStatus.Completed;
            Console.WriteLine($" Booking {Id} marked as completed.");
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"Booking ID: {Id}");
            Console.WriteLine($"Doctor ID: {DoctorId} | Patient ID: {PatientId}");
            Console.WriteLine($"Clinic: {ClinicId} | Date: {AppointmentDate} | Status: {Status}");
            Console.WriteLine($"First Visit: {(IsFirstVisit ? "Yes" : "No")} | Created At: {CreatedAt}");
        }
    }
}
