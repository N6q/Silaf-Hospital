using System;

namespace Silaf_Hospital.Models
{
    public abstract class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string FullName { get; set; } = null!;
        public string NationalId { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Password { get; set; } = null!;

        public Role Role { get; set; }    
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public User() { }

        public User(string fullName, string email, string password, string nationalId, string phone, string urole)
        {
            FullName = fullName;
            Email = email;
            Password = password;
            NationalId = nationalId;
            PhoneNumber = phone;
            IsActive = true;
            CreatedAt = DateTime.Now;

            try
            {
                this.Role = Enum.Parse<Role>(urole); 
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Invalid role '{urole}': {ex.Message}");
                this.Role = Role.Patient;  
            }
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"User: {FullName} | ID: {Id} | Role: {Role} | National ID: {NationalId}");
        }
    }
}
