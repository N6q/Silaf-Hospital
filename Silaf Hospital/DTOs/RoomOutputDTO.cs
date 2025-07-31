namespace Silaf_Hospital.DTOs
{
    public class RoomOutputDTO
    {
        public string Id { get; set; }
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }
        public string BranchId { get; set; }
        public string DepartmentId { get; set; }
        public bool IsOccupied { get; set; }
    }
}
