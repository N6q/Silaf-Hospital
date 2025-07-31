using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Models
{
    public class Admin : User
    {
        public string AssignedBranchId { get; set; }

        public string? CreatedBySuperAdminId { get; set; }

        public ICollection<Departments> ManagedDepartments { get; set; } = new List<Departments>();
        public ICollection<Clinic> ManagedClinics { get; set; } = new List<Clinic>();

        public Admin()
        {
            this.Role = Role.Admin;
            this.IsActive = true;
        }

        public void Deactivate()
        {
            this.IsActive = false;
            Console.WriteLine($" Admin {FullName} has been deactivated.");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Admin: {FullName} | Branch: {AssignedBranchId} | Created By: {CreatedBySuperAdminId ?? "N/A"}");
            Console.WriteLine($"Manages {ManagedDepartments.Count} departments and {ManagedClinics.Count} clinics");
        }
    }
}
