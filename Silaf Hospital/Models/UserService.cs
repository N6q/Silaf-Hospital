using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public class UserService : IUserService
    {
        private List<User> users = new();
        private readonly UserFileHandler fileHandler = new();

        public UserService()
        {
            users = fileHandler.LoadUsers();
        }

        public int AddStaff(User inputUser)
        {
            inputUser.Id = Guid.NewGuid().ToString();
            users.Add(inputUser);
            fileHandler.SaveUsers(users);
            Console.WriteLine(" Staff user added.");
            return 1;
        }

        public void AddSuperAdmin(UserInputDTO input)
        {
            var user = new SuperAdmin
            {
                Id = Guid.NewGuid().ToString(),
                FullName = input.FullName,
                NationalId = input.NationalId,
                Email = input.Email,
                PhoneNumber = input.PhoneNumber,
                Password = input.Password,
                Role = Role.SuperAdmin,
                IsActive = true
            };

            users.Add(user);
            fileHandler.SaveUsers(users);
            Console.WriteLine(" SuperAdmin added.");
        }

        public void AddUser(User user)
        {
            users.Add(user);
            fileHandler.SaveUsers(users);
            Console.WriteLine(" User added.");
        }

        public User AuthenticateUser(string email, string password)
        {
            foreach (var user in users)
            {
                if (user.Email == email && user.Password == password && user.IsActive)
                    return user;
            }
            return null;
        }

        public void DeactivateUser(int uid)
        {
            var user = users.Find(u => u.Id == uid.ToString());
            if (user != null)
            {
                user.IsActive = false;
                fileHandler.SaveUsers(users);
                Console.WriteLine(" User deactivated.");
            }
        }

        public bool EmailExists(string email)
        {
            foreach (var u in users)
            {
                if (u.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        public User GetUserById(int uid)
        {
            return users.Find(u => u.Id == uid.ToString());
        }

        public User GetUserByName(string userName)
        {
            return users.Find(u => u.FullName.Equals(userName, StringComparison.OrdinalIgnoreCase));
        }

        public string GetUserName(int userId)
        {
            var user = users.Find(u => u.Id == userId.ToString());
            return user != null ? user.FullName : null;
        }

        public void UpdatePassword(int uid, string currentPassword, string newPassword)
        {
            var user = GetUserById(uid);
            if (user != null && user.Password == currentPassword)
            {
                user.Password = newPassword;
                fileHandler.SaveUsers(users);
                Console.WriteLine(" Password updated.");
            }
        }

        public void UpdateUser(User user)
        {
            var existing = users.Find(u => u.Id == user.Id);
            if (existing != null)
            {
                existing.FullName = user.FullName;
                existing.PhoneNumber = user.PhoneNumber;
                existing.Email = user.Email;
                existing.NationalId = user.NationalId;
                fileHandler.SaveUsers(users);
                Console.WriteLine(" User updated.");
            }
        }

        public UserOutputDTO GetUserData(string userName, int? uid)
        {
            User user = null;

            if (!string.IsNullOrWhiteSpace(userName))
                user = GetUserByName(userName);

            if (user == null && uid.HasValue)
                user = GetUserById(uid.Value);

            if (user == null) return null;

            return new UserOutputDTO
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Role = user.Role.ToString()
            };
        }

        public IEnumerable<UserOutputDTO> GetUserByRole(string roleName)
        {
            var result = new List<UserOutputDTO>();
            foreach (var u in users)
            {
                if (u.Role.ToString().Equals(roleName, StringComparison.OrdinalIgnoreCase))
                {
                    result.Add(new UserOutputDTO
                    {
                        Id = u.Id,
                        FullName = u.FullName,
                        Email = u.Email,
                        PhoneNumber = u.PhoneNumber,
                        Role = u.Role.ToString()
                    });
                }
            }

            return result;
        }
    }
}
