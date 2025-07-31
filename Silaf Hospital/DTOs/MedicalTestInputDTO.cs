namespace Silaf_Hospital.DTOs
{
    public class MedicalTestInputDTO
    {
        public string TestName { get; set; }
        public string Result { get; set; }
        public DateTime TestDate { get; set; }
        public string DoctorId { get; set; }
        public string Description { get; set; }
        public DateTime ScheduledDate { get; set; }
    }
}
