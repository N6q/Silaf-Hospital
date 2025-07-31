namespace Silaf_Hospital.DTOs
{
    public class RoomInputDTO
    {
        public int RoomNumber { get; set; }
        public string BranchId { get; set; }
        public string DepartmentId { get; set; }
        public string RoomType { get; set; }       // e.g., "ICU", "Single"
    }
}
