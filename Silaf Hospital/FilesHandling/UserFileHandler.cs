using Silaf_Hospital.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Silaf_Hospital.FilesHandling
{
    public class UserFileHandler
    {
        private readonly string filePath = "data/users.txt";

        public void SaveUsers(List<User> users)
        {
            Directory.CreateDirectory("data");

            using StreamWriter writer = new(filePath);
            foreach (var user in users)
            {
                writer.WriteLine($"{user.Id},{user.FullName},{user.NationalId},{user.Email},{user.PhoneNumber},{user.Password},{user.Role},{user.IsActive}");
            }

            Console.WriteLine(" User data saved.");
        }

        public List<User> LoadUsers()
        {
            List<User> users = new();

            if (!File.Exists(filePath))
                return users;

            foreach (var line in File.ReadAllLines(filePath))
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 8)
                {
                    string role = parts[6].ToLower(); // e.g., "admin", "doctor", "patient"
                    bool isActive = bool.TryParse(parts[7], out var active) && active;

                    if (role == "admin")
                    {
                        users.Add(new Admin
                        {
                            Id = parts[0],
                            FullName = parts[1],
                            NationalId = parts[2],
                            Email = parts[3],
                            PhoneNumber = parts[4],
                            Password = parts[5],
                            Role = Enum.TryParse(parts[6], out Role parsedRole) ? parsedRole : Role.Patient,
                            IsActive = isActive
                        });
                    }
                    else if (role == "doctor")
                    {
                        users.Add(new Doctor
                        {
                            Id = parts[0],
                            FullName = parts[1],
                            NationalId = parts[2],
                            Email = parts[3],
                            PhoneNumber = parts[4],
                            Password = parts[5],
                            Role = Enum.TryParse(parts[6], out Role parsedRole) ? parsedRole : Role.Patient,
                            IsActive = isActive
                        });
                    }
                    else if (role == "patient")
                    {
                        users.Add(new Patient
                        {
                            Id = parts[0],
                            FullName = parts[1],
                            NationalId = parts[2],
                            Email = parts[3],
                            PhoneNumber = parts[4],
                            Password = parts[5],
                            Role = Enum.TryParse(parts[6], out Role parsedRole) ? parsedRole : Role.Patient,
                            IsActive = isActive
                        });
                    }
                }
            }

            Console.WriteLine(" User data loaded.");
            return users;
        }

    }
}
