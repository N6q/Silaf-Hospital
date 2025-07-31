using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Models
{
    public class PatientRecord
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string PatientId { get; set; }
        public DateTime VisitDate { get; set; }
        public string DiagnosisSummary { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public ICollection<Diagnosis> Diagnoses { get; set; } = new List<Diagnosis>();

        public PatientRecord() { }

        public PatientRecord(string patientId, DateTime visitDate, string summary)
        {
            Id = Guid.NewGuid().ToString();
            PatientId = patientId;
            VisitDate = visitDate;
            DiagnosisSummary = summary;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($" Record ID: {Id}");
            Console.WriteLine($" Patient ID: {PatientId} |  Visit: {VisitDate}");
            Console.WriteLine($" Summary: {DiagnosisSummary}");

            Console.WriteLine($"🩺 Diagnoses ({Diagnoses.Count}):");
            foreach (var d in Diagnoses)
            {
                d.DisplayInfo();
            }

            Console.WriteLine($" Prescriptions ({Prescriptions.Count}):");
            foreach (var p in Prescriptions)
            {
                p.DisplayInfo();
            }
        }
    }
}
