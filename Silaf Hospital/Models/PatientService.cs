using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public class PatientService : IPatientService
    {
        private List<Patient> patients = new List<Patient>();
        private readonly PatientFileHandler fileHandler = new PatientFileHandler();

        public PatientService()
        {
            patients = fileHandler.LoadPatients();
        }

        public void AddPatient(PatientInputDTO input)
        {
            var patient = new Patient
            {
                Id = input.Id,
                FullName = input.FullName,
                NationalId = input.NationalId,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                Password = input.Password,
                Address = input.Address,
                Age = input.Age,
                Gender = input.Gender
            };

            patients.Add(patient);
            fileHandler.SavePatients(patients);
        }

        public IEnumerable<Patient> GetAllPatients()
        {
            return patients;
        }

        public Patient GetPatientById(string id)
        {
            foreach (Patient p in patients)
            {
                if (p.Id == id) return p;
            }
            return null;
        }

        public Patient GetPatientByName(string name)
        {
            foreach (Patient p in patients)
            {
                if (p.FullName != null && p.FullName.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return p;
            }
            return null;
        }

        public void UpdatePatientDetails(string id, string phoneNumber)
        {
            Patient patient = GetPatientById(id);
            if (patient != null)
            {
                patient.PhoneNumber = phoneNumber;
                fileHandler.SavePatients(patients);
            }
        }

        public PatientOutputDTO GetPatientData(string userName, string id)
        {
            Patient found = null;

            if (!string.IsNullOrWhiteSpace(userName))
                found = GetPatientByName(userName);

            if (!string.IsNullOrWhiteSpace(id) && found == null)
                found = GetPatientById(id);

            if (found == null) return null;

            return new PatientOutputDTO
            {
                FullName = found.FullName,
                Email = found.Email,
                PhoneNumber = found.PhoneNumber,
                Age = found.Age,
                Gender = found.Gender,
                Address = found.Address
            };
        }

        public bool DeletePatient(string id)
        {
            Patient patient = GetPatientById(id);
            if (patient != null)
            {
                patients.Remove(patient);
                fileHandler.SavePatients(patients);
                return true;
            }
            return false;
        }

        public void SaveToFile()
        {
            fileHandler.SavePatients(patients);
        }

        public void LoadFromFile()
        {
            patients = fileHandler.LoadPatients();
        }
    }
}

