using System;

namespace Silaf_Hospital.Models
{
    public class Diagnosis
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }                    // e.g., "Diabetes Type 2"
        public string Notes { get; set; }                   // description or doctor observations

        public string PatientId { get; set; }
        public string? DoctorId { get; set; }

        public DateTime DateDiagnosed { get; set; } = DateTime.Now;
        public string? Severity { get; set; }               // e.g., "Mild", "Moderate", "Severe"

        public void DisplayInfo()
        {
            Console.WriteLine($"Diagnosis: {Name} (ID: {Id})");
            Console.WriteLine($" Patient: {PatientId} | Doctor: {DoctorId ?? "N/A"}");
            Console.WriteLine($" Diagnosed: {DateDiagnosed}");
            Console.WriteLine($" Notes: {Notes}");
            if (!string.IsNullOrWhiteSpace(Severity))
                Console.WriteLine($" Severity: {Severity}");
        }
    }
}
