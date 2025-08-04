
using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public class BranchDepartmentService : IBranchDepartmentService
    {
        private List<BranchDepartments> links = new List<BranchDepartments>();
        private BranchDepartmentFileHandler fileHandler = new BranchDepartmentFileHandler();
        private BranchService branchService = new BranchService();
        private DepartmentService departmentService = new DepartmentService();

        public BranchDepartmentService()
        {
            LoadFromFile();
        }

        public void AddDepartmentToBranch(BranchDepDTO dto)
        {
            var link = new BranchDepartments
            {
                BranchId = dto.BranchId,
                DepartmentId = dto.DepartmentId,
                Notes = dto.Notes
            };

            links.Add(link);
            SaveToFile();
        }
        public void AssignDepartmentToBranch()
        {
            Console.Write("Enter Branch Name: ");
            string branchName = Console.ReadLine();
            var branch = branchService.GetBranchByName(branchName);

            if (branch == null)
            {
                Console.WriteLine("❌ Branch not found.");
                return;
            }

            Console.Write("Enter Department Name: ");
            string depName = Console.ReadLine();
            var department = departmentService.GetDepartmentByName(depName);

            if (department == null)
            {
                Console.WriteLine("❌ Department not found.");
                return;
            }

            Console.Write("Optional Notes: ");
            string notes = Console.ReadLine();

            var link = GetBranchDep(department.Id, branch.Id);
            if (link != null)
            {
                Console.WriteLine("⚠️ Department already assigned to this branch.");
                return;
            }

            AddDepartmentToBranch(new DTOs.BranchDepDTO
            {
                BranchId = branch.Id,
                DepartmentId = department.Id,
                Notes = notes
            });

            Console.WriteLine("✅ Department assigned to branch successfully.");
        }


        public IEnumerable<DepartmentOutputDTO> GetDepartmentsByBranch(string branchId)
        {
            List<DepartmentOutputDTO> result = new List<DepartmentOutputDTO>();

            foreach (var link in links)
            {
                if (link.BranchId == branchId)
                {
                    var dto = departmentService.GetDepartmentDetailsById(link.DepartmentId);
                    if (dto != null)
                    {
                        result.Add(dto);
                    }
                }
            }

            return result;
        }

        public IEnumerable<DepartmentOutputDTO> GetDepartmentsByBranchName(string branchName)
        {
            var branch = branchService.GetBranchByName(branchName);
            if (branch != null)
            {
                return GetDepartmentsByBranch(branch.Id);
            }

            return new List<DepartmentOutputDTO>();
        }

        public IEnumerable<Branch> GetBranchsByDepartment(string departmentId)
        {
            List<Branch> result = new List<Branch>();

            foreach (var link in links)
            {
                if (link.DepartmentId == departmentId)
                {
                    var branch = branchService.GetBranchById(link.BranchId);
                    if (branch != null)
                    {
                        result.Add(branch);
                    }
                }
            }

            return result;
        }

        public void UpdateBranchDepartment(BranchDepartments updated)
        {
            foreach (var link in links)
            {
                if (link.BranchId == updated.BranchId && link.DepartmentId == updated.DepartmentId)
                {
                    link.Notes = updated.Notes;
                    SaveToFile();
                    break;
                }
            }
        }

        public BranchDepartments GetBranchDep(string departmentId, string branchId)
        {
            foreach (var link in links)
            {
                if (link.DepartmentId == departmentId && link.BranchId == branchId)
                {
                    return link;
                }
            }

            return null;
        }

        private void SaveToFile()
        {
            fileHandler.Save(links);
        }

        private void LoadFromFile()
        {
            links = fileHandler.Load();
        }
    }
}
