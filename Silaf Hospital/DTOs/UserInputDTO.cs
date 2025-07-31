namespace Silaf_Hospital.DTOs
{
    public class UserInputDTO
    {
        public string FullName { get; set; }
        public string NationalId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }  
        public string Address { get; set; }
        public int Age { get; set; }

        public string Role { get; set; }  // as string input, later parsed to enum
    }
}
