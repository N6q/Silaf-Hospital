namespace Silaf_Hospital.DTOs
{
    public class BranchUpdateDTO
    {
        public string Id { get; set; }                   // Required for lookup
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AdminId { get; set; }
        public bool? IsOpen { get; set; }
    }
}
