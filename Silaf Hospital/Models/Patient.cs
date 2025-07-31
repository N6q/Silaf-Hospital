using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Models
{
    public class Patient : User
    {
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        public List<string> MedicalConditions { get; set; } = new List<string>();
        public ICollection<Booking> Appointments { get; set; } = new List<Booking>();
        public ICollection<MedicalTest> MedicalTests { get; set; } = new List<MedicalTest>();
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

        public Patient()
        {
            Role = Role.Patient;
        }

        public Patient(string fullName, string nationalId, string email, string phone, string password, int age, string gender, string address)
        {
            Id = Guid.NewGuid().ToString();
            FullName = fullName;
            NationalId = nationalId;
            Email = email;
            PhoneNumber = phone;
            Password = password;
            Age = age;
            Gender = gender;
            Address = address;
            Role = Role.Patient;
            CreatedAt = DateTime.Now;
            IsActive = true;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($" Patient: {FullName} (ID: {Id})");
            Console.WriteLine($" National ID: {NationalId} |  Phone: {PhoneNumber}");
            Console.WriteLine($" Address: {Address} | Age: {Age} | Gender: {Gender}");
        }
    }
}
