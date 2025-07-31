namespace Silaf_Hospital.DTOs
{
    public class DoctorUpdateDTO
    {
        public string Id { get; set; }           // Required for identifying the doctor
        public string DepartmentId { get; set; }
        public string ClinicId { get; set; }
        public string WorkingHours { get; set; }
    }
}
