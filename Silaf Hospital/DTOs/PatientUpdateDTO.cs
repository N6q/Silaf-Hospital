namespace Silaf_Hospital.DTOs
{
    public class PatientUpdateDTO
    {
        public string Id { get; set; }           // For lookup
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }
    }
}
