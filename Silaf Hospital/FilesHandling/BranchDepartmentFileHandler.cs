
using Silaf_Hospital.Models;
using System.Collections.Generic;
using System.IO;

namespace Silaf_Hospital.FilesHandling
{
    public class BranchDepartmentFileHandler
    {
        private readonly string filePath = "data/branchdepartments.txt";

        public void Save(List<BranchDepartments> data)
        {
            Directory.CreateDirectory("data");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var item in data)
                {
                    writer.WriteLine($"{item.Id},{item.BranchId},{item.DepartmentId},{item.AssignedAt},{item.Notes}");
                }
            }
        }

        public List<BranchDepartments> Load()
        {
            List<BranchDepartments> list = new List<BranchDepartments>();

            if (!File.Exists(filePath)) return list;

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 4)
                {
                    var obj = new BranchDepartments
                    {
                        Id = parts[0],
                        BranchId = parts[1],
                        DepartmentId = parts[2],
                        AssignedAt = DateTime.Parse(parts[3]),
                        Notes = parts.Length > 4 ? parts[4] : null
                    };

                    list.Add(obj);
                }
            }

            return list;
        }
    }
}
