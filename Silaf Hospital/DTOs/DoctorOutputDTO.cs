namespace Silaf_Hospital.DTOs
{
    public class DoctorOutputDTO : UserOutputDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Specialization { get; set; }
        public string DepartmentId { get; set; }
        public bool IsAvailable { get; set; }
        public string NationalId { get; set; }
        public string ClinicId { get; set; }
        public string WorkingHours { get; set; }
        public string BranchId { get; set; }
    }
}
