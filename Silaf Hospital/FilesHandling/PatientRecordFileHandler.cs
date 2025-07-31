using Silaf_Hospital.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Silaf_Hospital.FilesHandling
{
    public class PatientRecordFileHandler
    {
        private readonly string filePath = "data/patient_records.txt";

        public void SaveRecords(List<PatientRecord> records)
        {
            Directory.CreateDirectory("data");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var record in records)
                {
                    string diagnoses = string.Join(";", record.Diagnoses.Select(d => d.Name));
                    string prescriptions = string.Join(";", record.Prescriptions.Select(p => $"{p.MedicineName}|{p.Dosage}|{p.DurationDays}"));

                    writer.WriteLine($"{record.Id},{record.PatientId},{record.VisitDate},{record.DiagnosisSummary},{diagnoses},{prescriptions}");
                }
            }

            Console.WriteLine(" Patient records saved.");
        }

        public List<PatientRecord> LoadRecords()
        {
            List<PatientRecord> records = new List<PatientRecord>();

            if (!File.Exists(filePath))
                return records;

            foreach (var line in File.ReadAllLines(filePath))
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 6)
                {
                    var record = new PatientRecord
                    {
                        Id = parts[0],
                        PatientId = parts[1],
                        VisitDate = DateTime.TryParse(parts[2], out var dt) ? dt : DateTime.Now,
                        DiagnosisSummary = parts[3]
                    };

                    string[] diagnoses = parts[4].Split(';');
                    foreach (string d in diagnoses)
                    {
                        record.Diagnoses.Add(new Diagnosis { Name = d });
                    }

                    string[] prescriptions = parts[5].Split(';');
                    foreach (string p in prescriptions)
                    {
                        string[] detail = p.Split('|');
                        if (detail.Length == 3)
                        {
                            record.Prescriptions.Add(new Prescription
                            {
                                MedicineName = detail[0],
                                Dosage = detail[1],
                                DurationDays = int.TryParse(detail[2], out var days) ? days : 0
                            });
                        }
                    }

                    records.Add(record);
                }
            }

            Console.WriteLine(" Patient records loaded.");
            return records;
        }
    }
}
