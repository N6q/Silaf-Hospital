namespace Silaf_Hospital.DTOs
{
    public class DepartmentOutputDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string BranchId { get; set; }
        public string? Specialty { get; set; }
        public int DoctorCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
