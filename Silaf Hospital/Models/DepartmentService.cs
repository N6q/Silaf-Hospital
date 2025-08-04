
using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public class DepartmentService
    {
        private List<Departments> departments = new List<Departments>();
        private readonly DepartmentFileHandler fileHandler = new DepartmentFileHandler();

        public DepartmentService()
        {
            LoadDepartments();
        }

        public void AddDepartment(DepartmentInputDTO input)
        {
            Departments newDept = new Departments();
            newDept.Id = Guid.NewGuid().ToString();
            newDept.Name = input.Name;
            newDept.BranchId = input.BranchId;

            departments.Add(newDept);
            SaveDepartments();
            Console.WriteLine("Department added.");
        }

        public List<Departments> GetAllDepartments()
        {
            return departments;
        }

        public Departments GetDepartmentById(string id)
        {
            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].Id == id)
                {
                    return departments[i];
                }
            }
            return null;
        }

        public Departments GetDepartmentByName(string name)
        {
            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].Name == name)
                {
                    return departments[i];
                }
            }
            return null;
        }

        public List<Departments> GetDepartmentsByBranch(string branchId)
        {
            List<Departments> result = new List<Departments>();
            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].BranchId == branchId)
                {
                    result.Add(departments[i]);
                }
            }
            return result;
        }

        public void UpdateDepartment(DepartmentUpdateDTO input)
        {
            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].Id == input.Id)
                {
                    departments[i].Name = input.Name;
                    SaveDepartments();
                    Console.WriteLine("Department updated.");
                    return;
                }
            }
            Console.WriteLine("Department not found.");
        }

        public void DeleteDepartment(string id)
        {
            Departments target = null;
            for (int i = 0; i < departments.Count; i++)
            {
                if (departments[i].Id == id)
                {
                    target = departments[i];
                    break;
                }
            }

            if (target != null)
            {
                departments.Remove(target);
                SaveDepartments();
                Console.WriteLine("Department deleted.");
            }
            else
            {
                Console.WriteLine("Department not found.");
            }
        }
        public DepartmentOutputDTO GetDepartmentDetailsById(string id)
        {
            var department = GetDepartmentById(id);
            if (department == null)
                return null;

            return new DepartmentOutputDTO
            {
                Id = department.Id,
                Name = department.Name
            };
        }

        public void SaveDepartments()
        {
            fileHandler.SaveDepartments(departments);
        }

        public void LoadDepartments()
        {
            departments = fileHandler.LoadDepartments();
            if (departments == null)
            {
                departments = new List<Departments>();
            }
        }
    }
}
