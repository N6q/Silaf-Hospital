using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public interface IBranchDepartmentService
    {
        void AddDepartmentToBranch(BranchDepDTO department);
        void UpdateBranchDepartment(BranchDepartments updatedRelation);
        BranchDepartments GetBranchDep(string departmentId, string branchId);
        IEnumerable<DepartmentOutputDTO> GetDepartmentsByBranch(string branchId);
        IEnumerable<DepartmentOutputDTO> GetDepartmentsByBranchName(string branchName);
        IEnumerable<Branch> GetBranchsByDepartment(string departmentId);
    }
}
