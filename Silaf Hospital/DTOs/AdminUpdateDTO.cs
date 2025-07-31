namespace Silaf_Hospital.DTOs
{
    public class AdminUpdateDTO
    {
        public string Id { get; set; }                  // Required
        public string? PhoneNumber { get; set; }
        public string? AssignedBranchId { get; set; }
        public string? Password { get; set; }
    }
}
