using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public class AdminService : IAdminService
    {
        private List<Admin> admins = new List<Admin>();
        private readonly AdminFileHandler fileHandler = new AdminFileHandler();

        public AdminService()
        {
            LoadFromFile();
        }

        public void AddAdmin(AdminInputDTO input)
        {
            Admin admin = new Admin();
            admin.FullName = input.FullName;
            admin.Email = input.Email;
            admin.Password = input.Password;
            admin.PhoneNumber = input.PhoneNumber;
            admin.NationalId = input.NationalId;
            admin.AssignedBranchId = input.AssignedBranchId;

            admins.Add(admin);
            SaveToFile();
            Console.WriteLine(" Admin added successfully.");
        }

        public List<Admin> GetAllAdmins()
        {
            return admins;
        }

        public Admin GetAdminById(string id)
        {
            foreach (Admin admin in admins)
            {
                if (admin.NationalId == id)
                {
                    return admin;
                }
            }
            return null;
        }

        public Admin GetAdminByName(string name)
        {
            foreach (Admin admin in admins)
            {
                if (admin.FullName == name)
                {
                    return admin;
                }
            }
            return null;
        }

        public void UpdateAdmin(AdminUpdateDTO input)
        {
            Admin target = GetAdminById(input.NationalId);
            if (target != null)
            {
                target.FullName = input.FullName;
                target.Email = input.Email;
                target.Password = input.Password;
                target.PhoneNumber = input.PhoneNumber;
                target.AssignedBranchId = input.AssignedBranchId;

                SaveToFile();
                Console.WriteLine(" Admin updated successfully.");
            }
            else
            {
                Console.WriteLine(" Admin not found.");
            }
        }

        public bool DeleteAdmin(string id)
        {
            Admin target = GetAdminById(id);
            if (target != null)
            {
                admins.Remove(target);
                SaveToFile();
                Console.WriteLine(" Admin deleted successfully.");
                return true;
            }

            Console.WriteLine(" Admin not found.");
            return false;
        }

        public AdminOutputDTO GetAdminData(string name, string id)
        {
            Admin admin = GetAdminById(id);
            if (admin != null && admin.FullName == name)
            {
                AdminOutputDTO output = new AdminOutputDTO();
                output.FullName = admin.FullName;
                output.Email = admin.Email;
                output.PhoneNumber = admin.PhoneNumber;
                output.NationalId = admin.NationalId;
                output.AssignedBranchId = admin.AssignedBranchId;
                return output;
            }
            return null;
        }

        public void SaveToFile()
        {
            fileHandler.SaveAdmins(admins);
        }

        public void LoadFromFile()
        {
            admins = fileHandler.LoadAdmins();
            if (admins == null)
            {
                admins = new List<Admin>();
            }
        }
    }
}
