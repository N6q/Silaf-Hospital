using System;
using Silaf_Hospital.Menus;

namespace Silaf_Hospital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Welcome to Silaf Hospital System ===");
                Console.WriteLine("1. Super Admin");
                Console.WriteLine("2. Admin");
                Console.WriteLine("3. Doctor");
                Console.WriteLine("4. Patient");
                Console.WriteLine("0. Exit");
                Console.Write("Select your role: ");
                string choice = Console.ReadLine();

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
                        Console.WriteLine("Exiting... Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Press any key to try again...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
