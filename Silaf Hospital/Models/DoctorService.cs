using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public class DoctorService : IDoctorService
    {
        private List<Doctor> doctors = new List<Doctor>();
        private readonly DoctorFileHandler fileHandler = new DoctorFileHandler();

        public DoctorService()
        {
            doctors = fileHandler.LoadDoctors();
        }

        public void AddDoctor(DoctorInputDTO input)
        {
            var doctor = new Doctor
            {
                Id = Guid.NewGuid().ToString(),
                FullName = input.FullName,
                Email = input.Email,
                Password = input.Password,
                NationalId = input.NationalId,
                PhoneNumber = input.PhoneNumber,
                Specialization = input.Specialization,
                DepartmentId = input.DepartmentId,
                ClinicId = input.ClinicId,
                WorkingHours = input.WorkingHours
            };

            doctors.Add(doctor);
            fileHandler.SaveDoctors(doctors);
        }

        public bool EmailExists(string email)
        {
            foreach (Doctor d in doctors)
            {
                if (d.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        public List<Doctor> GetAllDoctors()
        {
            return doctors;
        }

        public List<Doctor> GetDoctorByBrancDep(string branchId, string departmentId)
        {
            List<Doctor> result = new List<Doctor>();
            foreach (Doctor d in doctors)
            {
                if (d.ClinicId == branchId && d.DepartmentId == departmentId)
                    result.Add(d);
            }
            return result;
        }

        public Doctor GetDoctorByEmail(string email)
        {
            foreach (Doctor d in doctors)
            {
                if (d.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                    return d;
            }
            return null;
        }

        public Doctor GetDoctorById(string id)
        {
            foreach (Doctor d in doctors)
            {
                if (d.Id == id)
                    return d;
            }
            return null;
        }

        public Doctor GetDoctorByName(string name)
        {
            foreach (Doctor d in doctors)
            {
                if (d.FullName.Equals(name, StringComparison.OrdinalIgnoreCase))
                    return d;
            }
            return null;
        }

        public DoctorOutputDTO GetDoctorData(string name, string id)
        {
            Doctor d = null;

            if (!string.IsNullOrWhiteSpace(name))
                d = GetDoctorByName(name);

            if (d == null && !string.IsNullOrWhiteSpace(id))
                d = GetDoctorById(id);

            if (d == null) return null;

            return new DoctorOutputDTO
            {
                Id = d.Id,
                FullName = d.FullName,
                Specialization = d.Specialization,
                DepartmentId = d.DepartmentId,
                ClinicId = d.ClinicId,
                WorkingHours = d.WorkingHours
            };
        }

        public List<DoctorOutputDTO> GetDoctorsByBranchName(string branchName)
        {
            List<DoctorOutputDTO> results = new List<DoctorOutputDTO>();
            foreach (Doctor d in doctors)
            {
                if (d.ClinicId.Equals(branchName, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(new DoctorOutputDTO
                    {
                        Id = d.Id,
                        FullName = d.FullName,
                        Specialization = d.Specialization,
                        DepartmentId = d.DepartmentId,
                        ClinicId = d.ClinicId,
                        WorkingHours = d.WorkingHours
                    });
                }
            }
            return results;
        }

        public List<DoctorOutputDTO> GetDoctorsByDepartmentName(string departmentName)
        {
            List<DoctorOutputDTO> results = new List<DoctorOutputDTO>();
            foreach (Doctor d in doctors)
            {
                if (d.DepartmentId.Equals(departmentName, StringComparison.OrdinalIgnoreCase))
                {
                    results.Add(new DoctorOutputDTO
                    {
                        Id = d.Id,
                        FullName = d.FullName,
                        Specialization = d.Specialization,
                        DepartmentId = d.DepartmentId,
                        ClinicId = d.ClinicId,
                        WorkingHours = d.WorkingHours
                    });
                }
            }
            return results;
        }

        public void UpdateDoctor(Doctor updated)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Id == updated.Id)
                {
                    doctors[i] = updated;
                    fileHandler.SaveDoctors(doctors);
                    return;
                }
            }
        }

        public void UpdateDoctorDetails(DoctorUpdateDTO input)
        {
            Doctor d = GetDoctorById(input.Id);
            if (d != null)
            {
                d.DepartmentId = input.DepartmentId;
                d.ClinicId = input.ClinicId;
                d.WorkingHours = input.WorkingHours;
                fileHandler.SaveDoctors(doctors);
            }
        }

        public DoctorOutputDTO GetDoctorDetailsById(string id)
        {
            Doctor d = GetDoctorById(id);
            if (d == null) return null;

            return new DoctorOutputDTO
            {
                Id = d.Id,
                FullName = d.FullName,
                Specialization = d.Specialization,
                DepartmentId = d.DepartmentId,
                ClinicId = d.ClinicId,
                WorkingHours = d.WorkingHours
            };
        }

        public void SaveToFile()
        {
            fileHandler.SaveDoctors(doctors);
        }

        public void LoadFromFile()
        {
            doctors = fileHandler.LoadDoctors();
        }

        public bool DeleteDoctor(string id)
        {
            Doctor d = GetDoctorById(id);
            if (d != null)
            {
                doctors.Remove(d);
                fileHandler.SaveDoctors(doctors);
                return true;
            }
            return false;
        }
    }
}
