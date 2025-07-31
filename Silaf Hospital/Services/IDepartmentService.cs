using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public interface IDepartmentService
    {
        void AddDepartment(DepartmentInputDTO input);
        void DeleteDepartment(int departmentId);
        void UpdateDepartment(int departmentId, DepartmentInputDTO input);

        Departments GetDepartmentById(string departmentId);  
        DepartmentOutputDTO GetDepartmentDetailsById(string departmentId);
        IEnumerable<DepartmentOutputDTO> GetAllDepartments();
        IEnumerable<DepartmentOutputDTO> GetDepartmentsByBranchId(int branchId);
        Departments GetDepartmentByName(string departmentName);

        void SaveToFile();
        void LoadFromFile();
    }
}
