using System;

namespace Silaf_Hospital.Models
{
    public class Prescription
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string MedicineName { get; set; }
        public string Dosage { get; set; }
        public int DurationDays { get; set; }

        public Prescription() { }

        public Prescription(string medicineName, string dosage, int durationDays)
        {
            Id = Guid.NewGuid().ToString();
            MedicineName = medicineName;
            Dosage = dosage;
            DurationDays = durationDays;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($" Medicine: {MedicineName}");
            Console.WriteLine($" Dosage: {Dosage} |  Duration: {DurationDays} days");
        }
    }
}
