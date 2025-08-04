
using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public class ClinicService
    {
        private List<Clinic> clinics = new List<Clinic>();
        private readonly ClinicFileHandler fileHandler = new ClinicFileHandler();

        public ClinicService()
        {
            LoadClinics();
        }

        public void AddClinic(ClinicInputDTO input)
        {
            Clinic newClinic = new Clinic();
            newClinic.Id = Guid.NewGuid().ToString();
            newClinic.Name = input.Name;
            newClinic.BranchId = input.BranchId;
            newClinic.DepartmentId = input.DepartmentId;

            clinics.Add(newClinic);
            SaveClinics();
            Console.WriteLine("Clinic added successfully.");
        }

        public List<Clinic> GetAllClinic()
        {
            return clinics;
        }

        public Clinic GetClinicById(string clinicId)
        {
            for (int i = 0; i < clinics.Count; i++)
            {
                if (clinics[i].Id == clinicId)
                {
                    return clinics[i];
                }
            }
            return null;
        }

        public Clinic GetClinicByName(string clinicName)
        {
            for (int i = 0; i < clinics.Count; i++)
            {
                if (clinics[i].Name == clinicName)
                {
                    return clinics[i];
                }
            }
            return null;
        }

        public string GetClinicName(string clinicId)
        {
            for (int i = 0; i < clinics.Count; i++)
            {
                if (clinics[i].Id == clinicId)
                {
                    return clinics[i].Name;
                }
            }
            return null;
        }

        public List<Clinic> GetClinicsByBranchName(string branchName)
        {
            List<Clinic> result = new List<Clinic>();
            for (int i = 0; i < clinics.Count; i++)
            {
                if (clinics[i].BranchId == branchName)
                {
                    result.Add(clinics[i]);
                }
            }
            return result;
        }

        public List<Clinic> GetClinicsByDepartmentId(int departmentId)
        {
            List<Clinic> result = new List<Clinic>();
            for (int i = 0; i < clinics.Count; i++)
            {
                if (clinics[i].DepartmentId == departmentId.ToString())
                {
                    result.Add(clinics[i]);
                }
            }
            return result;
        }

        public List<Clinic> GetClinicByBranchDep(int branchId, int departmentId)
        {
            List<Clinic> result = new List<Clinic>();
            for (int i = 0; i < clinics.Count; i++)
            {
                if (clinics[i].BranchId == branchId.ToString() && clinics[i].DepartmentId == departmentId.ToString())
                {
                    result.Add(clinics[i]);
                }
            }
            return result;
        }

        public void UpdateClinicName(string clinicId, string newName)
        {
            for (int i = 0; i < clinics.Count; i++)
            {
                if (clinics[i].Id == clinicId)
                {
                    clinics[i].Name = newName;
                    SaveClinics();
                    Console.WriteLine("Clinic name updated.");
                    return;
                }
            }
            Console.WriteLine("Clinic not found.");
        }

        public void DeleteClinic(string clinicId)
        {
            Clinic target = null;
            for (int i = 0; i < clinics.Count; i++)
            {
                if (clinics[i].Id == clinicId)
                {
                    target = clinics[i];
                    break;
                }
            }

            if (target != null)
            {
                clinics.Remove(target);
                SaveClinics();
                Console.WriteLine("Clinic deleted.");
            }
            else
            {
                Console.WriteLine("Clinic not found.");
            }
        }

        public void SaveClinics()
        {
            fileHandler.Save(clinics);
        }

        public void LoadClinics()
        {
            clinics = fileHandler.Load();
            if (clinics == null)
            {
                clinics = new List<Clinic>();
            }
        }
    }
}
