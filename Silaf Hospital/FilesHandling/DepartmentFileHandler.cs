using Silaf_Hospital.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Silaf_Hospital.FilesHandling
{
    public class DepartmentFileHandler
    {
        private readonly string filePath = "data/departments.txt";

        public void SaveDepartments(List<Departments> departments)
        {
            Directory.CreateDirectory("data");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Departments department in departments)
                {
                    writer.WriteLine($"{department.Id},{department.Name},{department.BranchId},{department.Specialty},{department.CreatedAt}");
                }
            }

            Console.WriteLine(" Department data saved.");
        }

        public List<Departments> LoadDepartments()
        {
            List<Departments> departments = new List<Departments>();

            if (!File.Exists(filePath))
                return departments;

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 5)
                {
                    Departments dept = new Departments
                    {
                        Id = parts[0],
                        Name = parts[1],
                        BranchId = parts[2],
                        Specialty = parts[3],
                        CreatedAt = DateTime.TryParse(parts[4], out var dt) ? dt : DateTime.Now
                    };

                    departments.Add(dept);
                }
            }

            Console.WriteLine(" Department data loaded.");
            return departments;
        }
    }
}
