using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Models
{
    public class Clinic
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string BranchId { get; set; }
        public string DepartmentId { get; set; }
        public string OpeningHours { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public bool IsActive { get; set; } = true;

        public int RoomCount { get; set; }

        public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

        public void DisplayInfo()
        {
            Console.WriteLine($"Clinic: {Name} (ID: {Id})");
            Console.WriteLine($"Branch: {BranchId} | Department: {DepartmentId}");
            Console.WriteLine($"Hours: {OpeningHours} | Active: {IsActive}");
            Console.WriteLine($"Doctors: {Doctors.Count} | Rooms: {RoomCount} | 📅 Created: {CreatedAt}");
        }
    }
}
