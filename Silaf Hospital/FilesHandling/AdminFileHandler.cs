using Silaf_Hospital.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Silaf_Hospital.FilesHandling
{
    public class AdminFileHandler
    {
        private readonly string filePath = "admins.txt";

        public void SaveAdmins(List<Admin> admins)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Admin admin in admins)
                {
                    string line = admin.FullName + "," +
                                  admin.Email + "," +
                                  admin.Password + "," +
                                  admin.PhoneNumber + "," +
                                  admin.NationalId + "," +
                                  admin.AssignedBranchId;

                    writer.WriteLine(line);
                }
            }
        }

        public List<Admin> LoadAdmins()
        {
            List<Admin> admins = new List<Admin>();

            if (!File.Exists(filePath))
            {
                return admins;
            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 6)
                {
                    Admin admin = new Admin();
                    admin.FullName = parts[0];
                    admin.Email = parts[1];
                    admin.Password = parts[2];
                    admin.PhoneNumber = parts[3];
                    admin.NationalId = parts[4];

                    int branchId;
                    if (int.TryParse(parts[5], out branchId))
                    {
                        admin.AssignedBranchId = branchId.ToString();
                    }

                    admins.Add(admin);
                }
            }

            return admins;
        }
    }
}
