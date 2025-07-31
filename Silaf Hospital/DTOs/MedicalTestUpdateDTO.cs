namespace Silaf_Hospital.DTOs
{
    public class MedicalTestUpdateDTO
    {
        public string Id { get; set; }                    
        public string? Result { get; set; }              
        public DateTime? TestDate { get; set; }
    }
}
