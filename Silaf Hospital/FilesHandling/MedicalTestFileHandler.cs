using Silaf_Hospital.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Silaf_Hospital.FilesHandling
{
    public class MedicalTestFileHandler
    {
        private readonly string filePath = "data/medical_tests.txt";

        public void SaveMedicalTests(List<MedicalTest> tests)
        {
            Directory.CreateDirectory("data");
            using StreamWriter writer = new(filePath);
            foreach (var t in tests)
            {
                writer.WriteLine($"{t.Id},{t.PatientId},{t.DoctorId},{t.TestName},{t.Description},{t.ScheduledDate},{t.TestDate},{t.Result},{t.IsCompleted}");
            }
            Console.WriteLine(" Medical test data saved.");
        }

        public List<MedicalTest> LoadMedicalTests()
        {
            List<MedicalTest> tests = new();
            if (!File.Exists(filePath)) return tests;

            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(',');

                if (parts.Length >= 9)
                {
                    tests.Add(new MedicalTest
                    {
                        Id = parts[0],
                        PatientId = parts[1],
                        DoctorId = parts[2],
                        TestName = parts[3],
                        Description = parts[4],
                        ScheduledDate = DateTime.TryParse(parts[5], out var sched) ? sched : DateTime.Now,
                        TestDate = DateTime.TryParse(parts[6], out var testDate) ? testDate : null,
                        Result = parts[7],
                        IsCompleted = bool.TryParse(parts[8], out var done) && done
                    });
                }
            }

            Console.WriteLine(" Medical test data loaded.");
            return tests;
        }
    }
}
