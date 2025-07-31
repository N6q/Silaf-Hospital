namespace Silaf_Hospital.DTOs
{
    public class DiagnosisInputDTO
    {
        public string Name { get; set; }
        public string Notes { get; set; }
        public string? Severity { get; set; }
        public DateTime DateDiagnosed { get; set; }

    }
}
