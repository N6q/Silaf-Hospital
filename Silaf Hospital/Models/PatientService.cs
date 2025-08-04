
using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public class PatientService
    {
        private List<Patient> patients = new List<Patient>();
        private readonly PatientFileHandler fileHandler = new PatientFileHandler();

        public PatientService()
        {
            LoadPatients();
        }

        public void AddPatient(PatientInputDTO input)
        {
            Patient newPatient = new Patient();
            newPatient.FullName = input.FullName;
            newPatient.Email = input.Email;
            newPatient.Password = input.Password;
            newPatient.PhoneNumber = input.PhoneNumber;
            newPatient.Gender = input.Gender;
            newPatient.Age = input.Age;
            newPatient.NationalId = input.NationalId;
            newPatient.BranchId = input.BranchId;

           

            patients.Add(newPatient);
            SavePatients();
            Console.WriteLine("Patient added successfully.");
        }

        public void UpdatePatient(PatientInputDTO input)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].NationalId == input.NationalId)
                {
                    patients[i].FullName = input.FullName;
                    patients[i].Email = input.Email;
                    patients[i].Password = input.Password;
                    patients[i].PhoneNumber = input.PhoneNumber;
                    patients[i].Gender = input.Gender;
                    patients[i].Age = input.Age;
                    patients[i].BranchId = input.BranchId;

                    SavePatients();
                    Console.WriteLine("Patient updated.");
                    return;
                }
            }
            Console.WriteLine("Patient not found.");
        }



        public Patient GetPatientByNationalId(string nationalId)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].NationalId == nationalId)
                {
                    return patients[i];
                }
            }
            return null;
        }

        public Patient GetPatientByName(string name)
        {
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].FullName == name)
                {
                    return patients[i];
                }
            }
            return null;
        }

        public List<Patient> GetPatientsByBranch(string branchId)
        {
            List<Patient> result = new List<Patient>();
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].BranchId == branchId)
                {
                    result.Add(patients[i]);
                }
            }
            return result;
        }

        public void DeletePatient(string nationalId)
        {
            Patient target = null;
            for (int i = 0; i < patients.Count; i++)
            {
                if (patients[i].NationalId == nationalId)
                {
                    target = patients[i];
                    break;
                }
            }

            if (target != null)
            {
                patients.Remove(target);
                SavePatients();
                Console.WriteLine("Patient deleted.");
            }
            else
            {
                Console.WriteLine("Patient not found.");
            }
        }

        public void SavePatients()
        {
            fileHandler.SavePatients(patients);
        }

        public void LoadPatients()
        {
            patients = fileHandler.LoadPatients();
            if (patients == null)
            {
                patients = new List<Patient>();
            }
        }
    }
}
