using System;
using System.Collections.Generic;
using System.Linq;
using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;

namespace Silaf_Hospital.Services
{
    public class SuperAdminService : ISuperAdminService
    {
        private List<SuperAdmin> superAdmins = new List<SuperAdmin>();
        private SuperAdminFileHandler fileHandler = new SuperAdminFileHandler();

        public SuperAdminService()
        {
            LoadFromFile();
        }

        public void AddSuperAdmin(SuperAdminInputDTO input)
        {
            SuperAdmin newAdmin = new SuperAdmin();
            newAdmin.FullName = input.FullName;
            newAdmin.Email = input.Email;
            newAdmin.Password = input.Password;
            newAdmin.NationalId = input.NationalId;
            newAdmin.PhoneNumber = input.PhoneNumber;
            newAdmin.MasterKey = input.MasterKey;

            superAdmins.Add(newAdmin);
            SaveToFile();
        }

        public bool DeleteSuperAdmin(string id)
        {
            SuperAdmin admin = null;
            foreach (SuperAdmin a in superAdmins)
            {
                if (a.Id == id)
                {
                    admin = a;
                    break;
                }
            }

            if (admin != null)
            {
                superAdmins.Remove(admin);
                SaveToFile();
                return true;
            }

            return false;
        }

        public void UpdateSuperAdmin(SuperAdmin updated)
        {
            for (int i = 0; i < superAdmins.Count; i++)
            {
                if (superAdmins[i].Id == updated.Id)
                {
                    superAdmins[i] = updated;
                    SaveToFile();
                    break;
                }
            }
        }

        public List<SuperAdmin> GetAllSuperAdmins()
        {
            return superAdmins;
        }

        public SuperAdminOutputDTO GetSuperAdminById(string id)
        {
            foreach (SuperAdmin a in superAdmins)
            {
                if (a.Id == id)
                {
                    SuperAdminOutputDTO dto = new SuperAdminOutputDTO();
                    dto.Id = a.Id;
                    dto.FullName = a.FullName;
                    dto.Email = a.Email;
                    dto.PhoneNumber = a.PhoneNumber;
                    dto.MasterKey = a.MasterKey;
                    return dto;
                }
            }

            return null;
        }

        public SuperAdminOutputDTO GetSuperAdminByName(string name)
        {
            foreach (SuperAdmin a in superAdmins)
            {
                if (!string.IsNullOrWhiteSpace(a.FullName) && a.FullName.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    SuperAdminOutputDTO dto = new SuperAdminOutputDTO();
                    dto.Id = a.Id;
                    dto.FullName = a.FullName;
                    dto.Email = a.Email;
                    dto.PhoneNumber = a.PhoneNumber;
                    dto.MasterKey = a.MasterKey;
                    return dto;
                }
            }

            return null;
        }

        public SuperAdminOutputDTO GetSuperAdminDetailsById(string id)
        {
            return GetSuperAdminById(id);
        }

        public void SaveToFile()
        {
            fileHandler.SaveSuperAdmins(superAdmins);
        }

        public void LoadFromFile()
        {
            superAdmins = fileHandler.LoadSuperAdmins();
        }
    }
}
