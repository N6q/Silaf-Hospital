using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Models
{
    public class Doctor : User
    {
        public string Specialization { get; set; }
        public string DepartmentId { get; set; }
        public string ClinicId { get; set; }
        public string WorkingHours { get; set; }

        public string BranchId { get; set; }
        public bool IsAvailable { get; set; } = true;

        public ICollection<Booking> Appointments { get; set; } = new List<Booking>();
        public ICollection<MedicalTest> OrderedTests { get; set; } = new List<MedicalTest>();

        public ICollection<BranchDepartments> LinkedDepartments { get; set; } = new List<BranchDepartments>();

        public Doctor()
        {
            this.Role = Role.Doctor;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($" Doctor: {FullName} | ID: {Id}");
            Console.WriteLine($" Specialty: {Specialization} | Department ID: {DepartmentId} | Clinic ID: {ClinicId}");
            Console.WriteLine($" Working Hours: {WorkingHours} | Available: {(IsAvailable ? "Yes" : "No")}");
        }
    }
}
