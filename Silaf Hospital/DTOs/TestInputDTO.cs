namespace Silaf_Hospital.DTOs
{
    public class TestInputDTO
    {
        public string PatientId { get; set; }
        public string? DoctorId { get; set; }
        public string TestName { get; set; }
        public string? Description { get; set; }
        public DateTime ScheduledDate { get; set; }
    }
}
