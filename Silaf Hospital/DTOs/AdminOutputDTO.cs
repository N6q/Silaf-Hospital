namespace Silaf_Hospital.DTOs
{
    public class AdminOutputDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AssignedBranchId { get; set; }
        public int DepartmentsCount { get; set; }
        public int ClinicsCount { get; set; }
    }
}
