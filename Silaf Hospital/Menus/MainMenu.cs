using System;
using Silaf_Hospital.Models;
using Silaf_Hospital.Services;

namespace Silaf_Hospital.Menus
{
    public static class MainMenu
    {
        public static void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=====================");
                Console.WriteLine("  SILAF HOSPITAL 🏥  ");
                Console.WriteLine("=====================");
                Console.WriteLine("1. Login as Super Admin");
                Console.WriteLine("2. Login as Admin");
                Console.WriteLine("3. Login as Doctor");
                Console.WriteLine("4. Login as Patient");
                Console.WriteLine("0. Exit");
                Console.Write("Select your role: ");

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice)
                {
                    case "1":
                        SuperAdminMenu.Show();
                        break;
                    case "2":
                        AdminMenu.Show();
                        break;
                    case "3":
                        DoctorMenu.Show();
                        break;
                    case "4":
                        PatientMenu.Show();
                        break;
                    case "0":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
