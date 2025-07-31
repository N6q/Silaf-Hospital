using Silaf_Hospital.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Silaf_Hospital.FilesHandling
{
    public class BranchFileHandler
    {
        private readonly string filePath = "data/branches.txt";

        public void SaveBranches(List<Branch> branches)
        {
            Directory.CreateDirectory("data");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Branch branch in branches)
                {
                    writer.WriteLine($"{branch.Id},{branch.Name},{branch.Address},{branch.PhoneNumber},{branch.AdminId},{branch.CreatedAt},{branch.IsOpen}");
                }
            }

            Console.WriteLine(" Branch data saved.");
        }

        public List<Branch> LoadBranches()
        {
            List<Branch> branches = new List<Branch>();

            if (!File.Exists(filePath))
                return branches;

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 7)
                {
                    DateTime createdAt = DateTime.TryParse(parts[5], out var dt) ? dt : DateTime.Now;
                    bool isOpen = bool.TryParse(parts[6], out var open) && open;

                    Branch branch = new Branch
                    {
                        Id = parts[0],
                        Name = parts[1],
                        Address = parts[2],
                        PhoneNumber = parts[3],
                        AdminId = parts[4],
                        CreatedAt = createdAt,
                        IsOpen = isOpen
                    };

                    branches.Add(branch);
                }
            }

            Console.WriteLine(" Branch data loaded.");
            return branches;
        }
    }
}
