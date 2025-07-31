using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public class DepartmentService : IDepartmentService
    {
        private List<Departments> departments = new List<Departments>();
        private readonly DepartmentFileHandler fileHandler = new DepartmentFileHandler();

        public DepartmentService()
        {
            departments = fileHandler.LoadDepartments();
        }

        public void AddDepartment(DepartmentInputDTO input)
        {
            var department = new Departments
            {
                Id = Guid.NewGuid().ToString(),
                Name = input.Name
            };

            departments.Add(department);
            fileHandler.SaveDepartments(departments);
            Console.WriteLine("Department added successfully.");
        }

        public void UpdateDepartment(int departmentId, DepartmentInputDTO input)
        {
            var department = GetDepartmentById(departmentId.ToString());
            if (department != null)
            {
                department.Name = input.Name;
                fileHandler.SaveDepartments(departments);
                Console.WriteLine("Department updated.");
            }
        }

        public void DeleteDepartment(int departmentId)
        {
            var department = GetDepartmentById(departmentId.ToString());
            if (department != null)
            {
                departments.Remove(department);
                fileHandler.SaveDepartments(departments);
                Console.WriteLine("Department deleted.");
            }
        }

        public Departments GetDepartmentById(string departmentId)
        {
            foreach (var dept in departments)
            {
                if (dept.Id == departmentId)
                    return dept;
            }

            return null;
        }

        public DepartmentOutputDTO GetDepartmentDetailsById(string departmentId)
        {
            var dept = GetDepartmentById(departmentId);
            if (dept == null) return null;

            return new DepartmentOutputDTO
            {
                Id = dept.Id,
                Name = dept.Name
            };
        }

        public IEnumerable<DepartmentOutputDTO> GetAllDepartments()
        {
            List<DepartmentOutputDTO> result = new List<DepartmentOutputDTO>();
            foreach (var d in departments)
            {
                result.Add(new DepartmentOutputDTO
                {
                    Id = d.Id,
                    Name = d.Name
                });
            }
            return result;
        }

        public IEnumerable<DepartmentOutputDTO> GetDepartmentsByBranchId(int branchId)
        {
            throw new NotImplementedException();
        }

        public Departments GetDepartmentByName(string departmentName)
        {
            foreach (var d in departments)
            {
                if (d.Name.Equals(departmentName, StringComparison.OrdinalIgnoreCase))
                    return d;
            }

            return null;
        }

        public void SaveToFile()
        {
            fileHandler.SaveDepartments(departments);
        }

        public void LoadFromFile()
        {
            departments = fileHandler.LoadDepartments();
        }
    }
}
