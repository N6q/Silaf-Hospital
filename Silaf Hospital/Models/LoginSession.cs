using System;

namespace Silaf_Hospital.Models
{
    public static class LoginSession
    {
        public static string? CurrentUserId { get; private set; }
        public static string? CurrentUserName { get; private set; }
        public static Role? CurrentUserRole { get; private set; }

        public static void SignIn(string userId, string fullName, Role role)
        {
            CurrentUserId = userId;
            CurrentUserName = fullName;
            CurrentUserRole = role;

            Console.WriteLine($" User {CurrentUserName} ({CurrentUserRole}) signed in.");
        }

        public static void SignOut()
        {
            Console.WriteLine($" User {CurrentUserName} logged out.");
            CurrentUserId = null;
            CurrentUserName = null;
            CurrentUserRole = null;
        }

        public static bool IsLoggedIn()
        {
            return CurrentUserId != null;
        }

        public static void DisplayCurrentUser()
        {
            if (IsLoggedIn())
            {
                Console.WriteLine($" Logged in as: {CurrentUserName} | Role: {CurrentUserRole}");
            }
            else
            {
                Console.WriteLine(" No user is currently logged in.");
            }
        }
    }
}
