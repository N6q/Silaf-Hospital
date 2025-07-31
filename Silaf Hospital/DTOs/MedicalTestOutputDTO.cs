using System;

namespace Silaf_Hospital.DTOs
{
    public class MedicalTestOutputDTO
    {
        public string Id { get; set; }
        public string TestName { get; set; }
        public string? Description { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime? TestDate { get; set; }
        public string? Result { get; set; }
        public string? DoctorId { get; set; }
        public string PatientId { get; set; }
        public bool IsCompleted { get; set; }
    }
}
