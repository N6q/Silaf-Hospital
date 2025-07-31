using Silaf_Hospital.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Silaf_Hospital.Models
{
    public class AuthService
    {
        private readonly IPatientService patientService;
        private readonly IDoctorService doctorService;
        private readonly IAdminService adminService;
        private readonly ISuperAdminService superAdminService;

        private Dictionary<string, int> failedAttempts = new Dictionary<string, int>();
        private const int MaxAttempts = 3;

        public AuthService(
            IPatientService patientService,
            IDoctorService doctorService,
            IAdminService adminService,
            ISuperAdminService superAdminService)
        {
            this.patientService = patientService;
            this.doctorService = doctorService;
            this.adminService = adminService;
            this.superAdminService = superAdminService;
        }

        public bool Login(string nationalId, string password)
        {
            foreach (var patient in patientService.GetAllPatients())
            {
                if (patient.NationalId == nationalId && patient.Password == password)
                {
                    LoginSession.SignIn(patient.Id, patient.FullName, patient.Role);
                    return true;
                }
            }

            foreach (var doctor in doctorService.GetAllDoctors())
            {
                if (doctor.NationalId == nationalId && doctor.Password == password)
                {
                    LoginSession.SignIn(doctor.Id, doctor.FullName, doctor.Role);
                    return true;
                }
            }

            foreach (var admin in adminService.GetAllAdmins())
            {
                if (admin.NationalId == nationalId && admin.Password == password)
                {
                    LoginSession.SignIn(admin.Id, admin.FullName, admin.Role);
                    return true;
                }
            }

            foreach (var superAdmin in superAdminService.GetAllSuperAdmins())
            {
                if (superAdmin.NationalId == nationalId && superAdmin.Password == password)
                {
                    if (failedAttempts.ContainsKey(superAdmin.NationalId) &&
                        failedAttempts[superAdmin.NationalId] >= MaxAttempts)
                    {
                        Console.WriteLine(" SuperAdmin account is locked due to multiple failed attempts.");
                        return false;
                    }

                    Console.Write("Enter MasterKey: ");
                    string inputKey = Console.ReadLine();

                    if (superAdmin.MasterKey == inputKey)
                    {
                        LoginSession.SignIn(superAdmin.Id, superAdmin.FullName, superAdmin.Role);
                        failedAttempts[superAdmin.NationalId] = 0;
                        Console.WriteLine(" SuperAdmin logged in successfully.");
                        return true;
                    }
                    else
                    {
                        if (!failedAttempts.ContainsKey(superAdmin.NationalId))
                        {
                            failedAttempts[superAdmin.NationalId] = 1;
                        }
                        else
                        {
                            failedAttempts[superAdmin.NationalId]++;
                        }

                        int remaining = MaxAttempts - failedAttempts[superAdmin.NationalId];
                        Console.WriteLine(" Incorrect MasterKey. Attempts left: " + remaining);
                        return false;
                    }
                }
            }

            return false;
        }

        public void Logout()
        {
            LoginSession.SignOut();
        }

        public bool IsLoggedIn()
        {
            return LoginSession.IsLoggedIn();
        }

        public Role? CurrentRole()
        {
            return LoginSession.CurrentUserRole;
        }
    }
}
