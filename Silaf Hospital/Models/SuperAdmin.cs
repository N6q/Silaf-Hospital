using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Models
{
    public class SuperAdmin : User
    {
        public string MasterKey { get; set; }

        public ICollection<Admin> CreatedAdmins { get; set; } = new List<Admin>();
        public ICollection<Doctor> CreatedDoctors { get; set; } = new List<Doctor>();

        public SuperAdmin()
        {
            this.Role = Role.SuperAdmin;
        }

        public SuperAdmin(string fullName, string email, string password, string nationalId, string phone, string masterKey)
        {
            Id = Guid.NewGuid().ToString();
            FullName = fullName;
            Email = email;
            Password = password;
            NationalId = nationalId;
            PhoneNumber = phone;
            MasterKey = masterKey;
            Role = Role.SuperAdmin;
            CreatedAt = DateTime.Now;
            IsActive = true;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($" Super Admin: {FullName} (ID: {Id})");
            Console.WriteLine($"Created Admins: {CreatedAdmins.Count} |  Created Doctors: {CreatedDoctors.Count}");
        }
    }
}
