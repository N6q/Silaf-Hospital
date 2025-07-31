using System;
using System.Collections.Generic;
using System.IO;
using Silaf_Hospital.Models;

namespace Silaf_Hospital.FilesHandling
{
    public class ClinicFileHandler
    {
        private readonly string filePath = "data/clinics.txt";

        public void Save(List<Clinic> clinics)
        {
            Directory.CreateDirectory("data");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var clinic in clinics)
                {
                    writer.WriteLine($"{clinic.Id},{clinic.Name},{clinic.BranchId},{clinic.DepartmentId},{clinic.OpeningHours}");
                }
            }
        }

        public List<Clinic> Load()
        {
            List<Clinic> clinics = new List<Clinic>();
            if (!File.Exists(filePath)) return clinics;

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                if (parts.Length >= 5)
                {
                    clinics.Add(new Clinic
                    {
                        Id = parts[0],
                        Name = parts[1],
                        BranchId = parts[2],
                        DepartmentId = parts[3],
                        OpeningHours = parts[4]
                    });
                }
            }

            return clinics;
        }
    }
}
