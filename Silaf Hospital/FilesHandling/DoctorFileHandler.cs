using Silaf_Hospital.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Silaf_Hospital.FilesHandling
{
    public class DoctorFileHandler
    {
        private readonly string filePath = "data/doctors.txt";

        public void SaveDoctors(List<Doctor> doctors)
        {
            Directory.CreateDirectory("data");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Doctor doctor in doctors)
                {
                    writer.WriteLine($"{doctor.Id},{doctor.FullName},{doctor.NationalId},{doctor.Email},{doctor.PhoneNumber},{doctor.Password},{doctor.Specialization},{doctor.DepartmentId},{doctor.ClinicId},{doctor.WorkingHours}");
                }
            }

            Console.WriteLine(" Doctor data saved to file.");
        }

        public List<Doctor> LoadDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();

            if (!File.Exists(filePath))
                return doctors;

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 10)
                {
                    Doctor doctor = new Doctor
                    {
                        Id = parts[0],
                        FullName = parts[1],
                        NationalId = parts[2],
                        Email = parts[3],
                        PhoneNumber = parts[4],
                        Password = parts[5],
                        Specialization = parts[6],
                        DepartmentId = parts[7],
                        ClinicId = parts[8],
                        WorkingHours = parts[9]
                    };

                    doctors.Add(doctor);
                }
            }

            Console.WriteLine(" Doctor data loaded from file.");
            return doctors;
        }
    }
}
