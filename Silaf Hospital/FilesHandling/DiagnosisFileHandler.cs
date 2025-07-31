using Silaf_Hospital.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Silaf_Hospital.FilesHandling
{
    public class DiagnosisFileHandler
    {
        private readonly string filePath = "data/diagnoses.txt";

        public void SaveDiagnoses(List<Diagnosis> diagnoses)
        {
            Directory.CreateDirectory("data");
            using (StreamWriter writer = new(filePath))
            {
                foreach (var d in diagnoses)
                {
                    writer.WriteLine($"{d.Id},{d.Name},{d.Notes},{d.PatientId},{d.DoctorId},{d.DateDiagnosed},{d.Severity}");
                }
            }
            Console.WriteLine(" Diagnosis data saved.");
        }

        public List<Diagnosis> LoadDiagnoses()
        {
            var diagnoses = new List<Diagnosis>();
            if (!File.Exists(filePath)) return diagnoses;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(',');
                if (parts.Length >= 7)
                {
                    diagnoses.Add(new Diagnosis
                    {
                        Id = parts[0],
                        Name = parts[1],
                        Notes = parts[2],
                        PatientId = parts[3],
                        DoctorId = parts[4],
                        DateDiagnosed = DateTime.TryParse(parts[5], out var dt) ? dt : DateTime.Now,
                        Severity = parts[6]
                    });
                }
            }

            Console.WriteLine(" Diagnosis data loaded.");
            return diagnoses;
        }
    }
}
