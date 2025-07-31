namespace Silaf_Hospital.DTOs
{
    public class SuperAdminOutputDTO
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string MasterKey { get; set; }
        public string PhoneNumber { get; set; }
        public int CreatedAdminsCount { get; set; }
        public int CreatedDoctorsCount { get; set; }
    }
}
