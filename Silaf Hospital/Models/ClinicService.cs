
using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public class ClinicService : IClinicService
    {
        private List<Clinic> clinics = new List<Clinic>();
        private ClinicFileHandler fileHandler = new ClinicFileHandler();

        public ClinicService()
        {
            LoadFromFile();
        }

        public void AddClinic(ClinicInputDTO input)
        {
            Clinic clinic = new Clinic();
            clinic.Name = input.Name;
            clinic.BranchId = input.BranchId;
            clinic.DepartmentId = input.DepartmentId;
            clinic.OpeningHours = input.OpeningHours;

            clinics.Add(clinic);
            SaveToFile();
        }

        public IEnumerable<Clinic> GetAllClinic()
        {
            return clinics;
        }

        public IEnumerable<Clinic> GetClinicByBranchDep(int branchId, int departmentId)
        {
            List<Clinic> result = new List<Clinic>();
            foreach (Clinic clinic in clinics)
            {
                if (clinic.BranchId == branchId.ToString() && clinic.DepartmentId == departmentId.ToString())
                {
                    result.Add(clinic);
                }
            }
            return result;
        }

        public Clinic GetClinicById(int clinicId)
        {
            foreach (Clinic clinic in clinics)
            {
                if (clinic.Id == clinicId.ToString())
                {
                    return clinic;
                }
            }
            return null;
        }

        public Clinic GetClinicByName(string clinicName)
        {
            foreach (Clinic clinic in clinics)
            {
                if (clinic.Name != null && clinic.Name.Equals(clinicName, StringComparison.OrdinalIgnoreCase))
                {
                    return clinic;
                }
            }
            return null;
        }

        public string GetClinicName(int clinicId)
        {
            Clinic clinic = GetClinicById(clinicId);
            if (clinic != null)
            {
                return clinic.Name;
            }
            return "Unknown";
        }

        public IEnumerable<Clinic> GetClinicsByBranchName(string branchName)
        {
            List<Clinic> result = new List<Clinic>();
            foreach (Clinic clinic in clinics)
            {
                if (clinic.BranchId != null && clinic.BranchId.Equals(branchName, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(clinic);
                }
            }
            return result;
        }

        public IEnumerable<Clinic> GetClinicsByDepartmentId(int departmentId)
        {
            List<Clinic> result = new List<Clinic>();
            foreach (Clinic clinic in clinics)
            {
                if (clinic.DepartmentId == departmentId.ToString())
                {
                    result.Add(clinic);
                }
            }
            return result;
        }

        public decimal GetPrice(int clinicId)
        {
            return 20.0m; // Static pricing logic
        }

        public void SetClinicStatus(int clinicId)
        {
            Clinic clinic = GetClinicById(clinicId);
            if (clinic != null)
            {
                clinic.DisplayInfo();
                Console.WriteLine("Clinic status toggled (demo message).");
            }
        }

        public void UpdateClinicDetails(int clinicId, ClinicInputDTO input)
        {
            Clinic clinic = GetClinicById(clinicId);
            if (clinic != null)
            {
                clinic.Name = input.Name;
                clinic.BranchId = input.BranchId;
                clinic.DepartmentId = input.DepartmentId;
                clinic.OpeningHours = input.OpeningHours;
                SaveToFile();
            }
        }

        public ClinicOutputDTO GetClinicData(string name, string id)
        {
            foreach (Clinic clinic in clinics)
            {
                if ((!string.IsNullOrWhiteSpace(name) && clinic.Name != null && clinic.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) ||
                    (!string.IsNullOrWhiteSpace(id) && clinic.Id == id))
                {
                    ClinicOutputDTO dto = new ClinicOutputDTO();
                    dto.Id = clinic.Id;
                    dto.Name = clinic.Name;
                    dto.BranchId = clinic.BranchId;
                    dto.DepartmentId = clinic.DepartmentId;
                    dto.OpeningHours = clinic.OpeningHours;
                    return dto;
                }
            }
            return null;
        }

        public void SaveToFile()
        {
            fileHandler.Save(clinics);
        }

        public void LoadFromFile()
        {
            clinics = fileHandler.Load();
        }

        public bool DeleteClinic(string id)
        {
            for (int i = 0; i < clinics.Count; i++)
            {
                if (clinics[i].Id == id)
                {
                    clinics.RemoveAt(i);
                    SaveToFile();
                    return true;
                }
            }
            return false;
        }
    }
}
