using Silaf_Hospital.Services;
using System;

namespace Silaf_Hospital.Menus
{
    public static class BranchReports
    {
        public static void Show(string branchId,
            IPatientService patientService,
            IDoctorService doctorService,
            IClinicService clinicService,
            IBookingService bookingService)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════╗");
            Console.WriteLine($"║ 📊 Branch Report for Branch ID: {branchId,-15} ║");
            Console.WriteLine("╠══════════════════════════════════════╣");
            Console.ResetColor();

            int totalPatients = patientService.GetAllPatients().Count(p => p.BranchId == branchId);
            int totalDoctors = doctorService.GetAllDoctors().Count(d => d.BranchId == branchId);
            int totalClinics = clinicService.GetAllClinic().Count(c => c.BranchId == branchId);
            int totalAppointments = bookingService.GetAllBookings().Count(b => b.BranchId == branchId);

            Console.WriteLine($"🧍‍♂️ Total Patients     : {totalPatients}");
            Console.WriteLine($"🧑‍⚕️ Total Doctors      : {totalDoctors}");
            Console.WriteLine($"🏥 Total Clinics       : {totalClinics}");
            Console.WriteLine($"📅 Total Appointments  : {totalAppointments}");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╚══════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }
    }
}
