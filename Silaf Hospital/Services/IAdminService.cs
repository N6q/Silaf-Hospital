using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public interface IAdminService
    {
        void AddAdmin(AdminInputDTO input);
        List<Admin> GetAllAdmins();
        Admin GetAdminById(string id);
        Admin GetAdminByName(string name);
        void UpdateAdmin(AdminUpdateDTO input);
        bool DeleteAdmin(string id);
        AdminOutputDTO GetAdminData(string name, string id);
        void SaveToFile();
        void LoadFromFile();
    }
}
