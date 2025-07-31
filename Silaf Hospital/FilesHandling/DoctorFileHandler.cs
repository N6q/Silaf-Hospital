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
                    writer.WriteLine($"{doctor.Id}," +
                                     $"{doctor.FullName}," +
                                     $"{doctor.NationalId}," +
                                     $"{doctor.Email}," +
                                     $"{doctor.PhoneNumber}," +
                                     $"{doctor.Password}," +
                                     $"{doctor.Specialization}," +
                                     $"{doctor.DepartmentId}," +
                                     $"{doctor.ClinicId}," +
                                     $"{doctor.WorkingHours}," +
                                     $"{doctor.IsAvailable}");
                }
            }

            Console.WriteLine(" Doctor data saved to file.");
        }

        public List<Doctor> LoadDoctors()
        {
            List<Doctor> doctors = new List<Doctor>();

            if (!File.Exists(filePath))
            {
                return doctors;
            }

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 11)
                {
                    Doctor doctor = new Doctor();
                    doctor.Id = parts[0];
                    doctor.FullName = parts[1];
                    doctor.NationalId = parts[2];
                    doctor.Email = parts[3];
                    doctor.PhoneNumber = parts[4];
                    doctor.Password = parts[5];
                    doctor.Specialization = parts[6];
                    doctor.DepartmentId = parts[7];
                    doctor.ClinicId = parts[8];
                    doctor.WorkingHours = parts[9];
                    doctor.IsAvailable = bool.Parse(parts[10]);

                    doctors.Add(doctor);
                }
            }

            return doctors;
        }
    }
}
