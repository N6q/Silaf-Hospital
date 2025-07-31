using System;

namespace Silaf_Hospital.DTOs
{
    public class FeedbackInputDTO
    {
        public string PatientId { get; set; }
        public string? DoctorId { get; set; }
        public string? AppointmentId { get; set; }
        public int Rating { get; set; }         // 1 to 5
        public string Comment { get; set; }
    }
}
