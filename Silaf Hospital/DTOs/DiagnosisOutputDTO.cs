namespace Silaf_Hospital.DTOs
{
    public class DiagnosisOutputDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string? Severity { get; set; }
        public DateTime DateDiagnosed { get; set; }
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
    }
}
