namespace Silaf_Hospital.DTOs
{
    public class ClinicOutputDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string BranchId { get; set; }
        public string DepartmentId { get; set; }
        public string OpeningHours { get; set; }
        public int DoctorCount { get; set; }
    }
}
