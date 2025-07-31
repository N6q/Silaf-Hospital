namespace Silaf_Hospital.DTOs
{
    public class DepartmentUpdateDTO
    {
        public string Id { get; set; }                   // Required for lookup
        public string? Name { get; set; }
        public string? Specialty { get; set; }
    }
}
