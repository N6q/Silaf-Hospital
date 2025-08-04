namespace Silaf_Hospital.DTOs
{
    public class DoctorInputDTO : UserInputDTO
    {
    
        public string Specialization { get; set; }
        public string DepartmentId { get; set; }
        public string ClinicId { get; set; }
        public string WorkingHours { get; set; }
        public bool IsAvailable { get; set; } = true; 
        public string BranchId { get; set; }
    }
}
