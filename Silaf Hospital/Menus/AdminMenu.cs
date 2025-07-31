using Silaf_Hospital.Services;
using System;

namespace Silaf_Hospital.Menus
{
    public static class AdminMenu
    {
        public static void Show(string branchId)
        {
            DepartmentService departmentService = new DepartmentService();
            DoctorService doctorService = new DoctorService();
            ClinicService clinicService = new ClinicService();
            PatientService patientService = new PatientService();
            BookingService bookingService = new BookingService();

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("========== ADMIN MENU ==========");
                Console.ResetColor();

                Console.WriteLine("1. Manage Departments");
                Console.WriteLine("2. Manage Doctors");
                Console.WriteLine("3. Manage Clinics");
                Console.WriteLine("4. Assign Doctor to Clinic");
                Console.WriteLine("5. Manage Patients");
                Console.WriteLine("6. Manage Bookings");
                Console.WriteLine("7. View Branch Records");
                Console.WriteLine("0. Logout");

                Console.Write("\nSelect an option: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DepartmentBranchMenu.Show(branchId, departmentService);
                        break;
                    case "2":
                        DoctorBranchMenu.Show(branchId, doctorService);
                        break;
                    case "3":
                        ClinicBranchMenu.Show(branchId, clinicService);
                        break;
                    case "4":
                        AssignDoctorToClinicMenu.Show(branchId, doctorService, clinicService);
                        break;
                    case "5":
                        PatientBranchMenu.Show(branchId, patientService);
                        break;
                    case "6":
                        BookingMenu.Show(branchId, bookingService);
                        break;
                    case "7":
                        BranchReports.Show(branchId);
                        break;
                    case "0":
                        return;

                    default:
                        Console.WriteLine("❌ Invalid choice.");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
