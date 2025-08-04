namespace Silaf_Hospital.DTOs
{
    public class BookingInputDTO
    {
        public string PatientId { get; set; }
        public string DoctorId { get; set; }
        public string ClinicId { get; set; }
        public DateTime Slot { get; set; } // ✅ Used for appointment slot
        public string Notes { get; set; }
        public bool IsFirstVisit { get; set; }
    }
}
