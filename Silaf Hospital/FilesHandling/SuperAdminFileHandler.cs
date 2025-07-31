using Silaf_Hospital.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Silaf_Hospital.FilesHandling
{
    public class SuperAdminFileHandler
    {
        private readonly string filePath = "data/superadmins.txt";

        public void SaveSuperAdmins(List<SuperAdmin> superAdmins)
        {
            Directory.CreateDirectory("data");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (SuperAdmin superAdmin in superAdmins)
                {
                    writer.WriteLine($"{superAdmin.Id},{superAdmin.FullName},{superAdmin.NationalId},{superAdmin.Email},{superAdmin.PhoneNumber},{superAdmin.Password},{superAdmin.MasterKey}");
                }
            }

            Console.WriteLine(" SuperAdmin data saved.");
        }

        public List<SuperAdmin> LoadSuperAdmins()
        {
            List<SuperAdmin> superAdmins = new List<SuperAdmin>();

            if (!File.Exists(filePath))
                return superAdmins;

            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 7)
                {
                    SuperAdmin superAdmin = new SuperAdmin
                    {
                        Id = parts[0],
                        FullName = parts[1],
                        NationalId = parts[2],
                        Email = parts[3],
                        PhoneNumber = parts[4],
                        Password = parts[5],
                        MasterKey = parts[6]
                    };

                    superAdmins.Add(superAdmin);
                }
            }

            Console.WriteLine(" SuperAdmin data loaded.");
            return superAdmins;
        }
    }
}
