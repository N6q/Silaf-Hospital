using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;

public interface ISuperAdminService
{
    void AddSuperAdmin(SuperAdminInputDTO input);
    bool DeleteSuperAdmin(string id);
    void UpdateSuperAdmin(SuperAdmin updated);
    List<SuperAdmin> GetAllSuperAdmins();
    SuperAdminOutputDTO GetSuperAdminById(string id);
    SuperAdminOutputDTO GetSuperAdminByName(string name);
    SuperAdminOutputDTO GetSuperAdminDetailsById(string id);
    void SaveToFile();
    void LoadFromFile();
}