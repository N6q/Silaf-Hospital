namespace Silaf_Hospital.DTOs
{
    public class DoctorUpdateDTO : UserUpdateDTO
    {
        public string Specialization { get; set; }
        public string ClinicId { get; set; }
        public bool IsAvailable { get; set; }
    }
}
