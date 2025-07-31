namespace Silaf_Hospital.DTOs
{
    public class RoomUpdateDTO
    {
        public string Id { get; set; }
        public string? RoomType { get; set; }
        public string? DepartmentId { get; set; }
        public bool? IsOccupied { get; set; }
    }
}
