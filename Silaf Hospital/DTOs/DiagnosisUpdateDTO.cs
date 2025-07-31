namespace Silaf_Hospital.DTOs
{
    public class DiagnosisUpdateDTO
    {
        public string Id { get; set; }               // Diagnosis ID to identify
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
    }
}
