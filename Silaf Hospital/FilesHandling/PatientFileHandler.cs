using Silaf_Hospital.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Silaf_Hospital.FilesHandling
{
    public class PatientFileHandler
    {
        private readonly string filePath = "data/patients.txt";

        public void SavePatients(List<Patient> patients)
        {
            Directory.CreateDirectory("data");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Patient patient in patients)
                {
                    writer.WriteLine($"{patient.Id},{patient.FullName},{patient.NationalId},{patient.Email},{patient.PhoneNumber},{patient.Password},{patient.Age},{patient.Gender},{patient.Address}");
                }
            }

            Console.WriteLine(" Patient data saved.");
        }

        public List<Patient> LoadPatients()
        {
            List<Patient> patients = new List<Patient>();

            if (!File.Exists(filePath))
                return patients;

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 9)
                {
                    Patient patient = new Patient
                    {
                        Id = parts[0],
                        FullName = parts[1],
                        NationalId = parts[2],
                        Email = parts[3],
                        PhoneNumber = parts[4],
                        Password = parts[5],
                        Age = int.Parse(parts[6]),
                        Gender = parts[7],
                        Address = parts[8]
                    };

                    patients.Add(patient);
                }
            }

            Console.WriteLine(" Patient data loaded.");
            return patients;
        }
    }
}
