namespace Silaf_Hospital.DTOs
{
    public class BranchOutputDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string AdminId { get; set; }
        public int DepartmentCount { get; set; }
        public bool IsOpen { get; set; }
    }
}
