using System;

namespace Silaf_Hospital.DTOs
{
    public class BookingOutputDTO
    {
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public string ClinicId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public bool IsBooked { get; set; }

    }
}
