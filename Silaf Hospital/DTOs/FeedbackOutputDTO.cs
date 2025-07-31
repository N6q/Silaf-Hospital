using System;

namespace Silaf_Hospital.DTOs
{
    public class FeedbackOutputDTO
    {
        public string Id { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public string AppointmentId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public DateTime SubmittedAt { get; set; }
        public bool IsRead { get; set; }

    }
}
