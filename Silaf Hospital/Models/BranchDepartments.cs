using System;

namespace Silaf_Hospital.Models
{
    public class BranchDepartments
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string BranchId { get; set; }
        public string DepartmentId { get; set; }

        public DateTime AssignedAt { get; set; } = DateTime.Now;
        public string? Notes { get; set; }

        public void DisplayInfo()
        {
            Console.WriteLine($" Branch-Department Link ID: {Id}");
            Console.WriteLine($" Branch ID: {BranchId} → Department ID: {DepartmentId}");
            Console.WriteLine($" Assigned: {AssignedAt}");
            if (!string.IsNullOrWhiteSpace(Notes))
                Console.WriteLine($" Notes: {Notes}");
        }
    }
}
