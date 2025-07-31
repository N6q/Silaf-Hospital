using Silaf_Hospital.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Silaf_Hospital.FilesHandling
{
    public class AdminFileHandler
    {
        private readonly string filePath = "data/admins.txt";

        public void SaveAdmins(List<Admin> admins)
        {
            Directory.CreateDirectory("data");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Admin admin in admins)
                {
                    writer.WriteLine($"{admin.Id},{admin.FullName},{admin.NationalId},{admin.Email},{admin.PhoneNumber},{admin.Password},{admin.AssignedBranchId}");
                }
            }

            Console.WriteLine(" Admin data saved.");
        }

        public List<Admin> LoadAdmins()
        {
            List<Admin> admins = new List<Admin>();

            if (!File.Exists(filePath))
                return admins;

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 7)
                {
                    Admin admin = new Admin
                    {
                        Id = parts[0],
                        FullName = parts[1],
                        NationalId = parts[2],
                        Email = parts[3],
                        PhoneNumber = parts[4],
                        Password = parts[5],
                        AssignedBranchId = parts[6]
                    };

                    admins.Add(admin);
                }
            }

            Console.WriteLine(" Admin data loaded.");
            return admins;
        }
    }
}
