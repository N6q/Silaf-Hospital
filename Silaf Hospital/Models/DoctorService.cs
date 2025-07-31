
using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public class DoctorService
    {
        private List<Doctor> doctors = new List<Doctor>();
        private readonly DoctorFileHandler fileHandler = new DoctorFileHandler();

        public DoctorService()
        {
            LoadDoctors();
        }

        public void AddDoctor(DoctorInputDTO input)
        {
            Doctor newDoctor = new Doctor();
            newDoctor.FullName = input.FullName;
            newDoctor.Email = input.Email;
            newDoctor.Password = input.Password;
            newDoctor.PhoneNumber = input.PhoneNumber;
            newDoctor.Gender = input.Gender;
            newDoctor.Age = input.Age;
            newDoctor.NationalId = input.NationalID;
            newDoctor.DepartmentId = input.DepartmentId;
            newDoctor.ClinicId = input.ClinicId;
            newDoctor.BranchId = input.BranchId;
            newDoctor.IsAvailable = input.IsAvailable;

            int highestId = 0;
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].UserID > highestId)
                {
                    highestId = doctors[i].UserID;
                }
            }
            newDoctor.UserID = highestId + 1;

            doctors.Add(newDoctor);
            SaveDoctors();
            Console.WriteLine("Doctor added successfully.");
        }

        public void UpdateDoctor(Doctor doctor)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].NationalId == doctor.NationalId)
                {
                    doctors[i] = doctor;
                    SaveDoctors();
                    Console.WriteLine("Doctor updated.");
                    return;
                }
            }
            Console.WriteLine("Doctor not found.");
        }

        public void UpdateDoctorDetails(DoctorUpdateDTO input)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].NationalId == input.NationalId)
                {
                    doctors[i].FullName = input.FullName;
                    doctors[i].Email = input.Email;
                    doctors[i].Password = input.Password;
                    doctors[i].PhoneNumber = input.PhoneNumber;
                    doctors[i].Gender = input.Gender;
                    doctors[i].Age = input.Age;
                    doctors[i].IsAvailable = input.IsAvailable;
                    SaveDoctors();
                    Console.WriteLine("Doctor details updated.");
                    return;
                }
            }
            Console.WriteLine("Doctor not found.");
        }

        public Doctor GetDoctorById(string id)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].UserID.ToString() == id)
                {
                    return doctors[i];
                }
            }
            return null;
        }

        public Doctor GetDoctorByName(string name)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].FullName == name)
                {
                    return doctors[i];
                }
            }
            return null;
        }

        public Doctor GetDoctorByEmail(string email)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Email == email)
                {
                    return doctors[i];
                }
            }
            return null;
        }

        public List<Doctor> GetAllDoctors()
        {
            return doctors;
        }

        public List<Doctor> GetDoctorByBrancDep(string branchId, string departmentId)
        {
            List<Doctor> result = new List<Doctor>();
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].BranchId == branchId && doctors[i].DepartmentId == departmentId)
                {
                    result.Add(doctors[i]);
                }
            }
            return result;
        }

        public List<DoctorOutputDTO> GetDoctorsByBranchName(string branchName)
        {
            List<DoctorOutputDTO> result = new List<DoctorOutputDTO>();
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].BranchId == branchName)
                {
                    DoctorOutputDTO dto = new DoctorOutputDTO();
                    dto.FullName = doctors[i].FullName;
                    dto.Email = doctors[i].Email;
                    dto.PhoneNumber = doctors[i].PhoneNumber;
                    dto.NationalId = doctors[i].NationalId;
                    dto.BranchId = doctors[i].BranchId;
                    result.Add(dto);
                }
            }
            return result;
        }

        public List<DoctorOutputDTO> GetDoctorsByDepartmentName(string departmentName)
        {
            List<DoctorOutputDTO> result = new List<DoctorOutputDTO>();
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].DepartmentId == departmentName)
                {
                    DoctorOutputDTO dto = new DoctorOutputDTO();
                    dto.FullName = doctors[i].FullName;
                    dto.Email = doctors[i].Email;
                    dto.PhoneNumber = doctors[i].PhoneNumber;
                    dto.NationalId = doctors[i].NationalId;
                    dto.BranchId = doctors[i].BranchId;
                    result.Add(dto);
                }
            }
            return result;
        }

        public DoctorOutputDTO GetDoctorDetailsById(string id)
        {
            Doctor doc = GetDoctorById(id);
            if (doc != null)
            {
                DoctorOutputDTO dto = new DoctorOutputDTO();
                dto.FullName = doc.FullName;
                dto.Email = doc.Email;
                dto.PhoneNumber = doc.PhoneNumber;
                dto.NationalId = doc.NationalId;
                dto.BranchId = doc.BranchId;
                return dto;
            }
            return null;
        }

        public bool EmailExists(string email)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        public bool DeleteDoctor(string id)
        {
            Doctor target = null;
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].NationalId == id)
                {
                    target = doctors[i];
                    break;
                }
            }

            if (target != null)
            {
                doctors.Remove(target);
                SaveDoctors();
                Console.WriteLine("Doctor deleted.");
                return true;
            }

            Console.WriteLine("Doctor not found.");
            return false;
        }

        public void SaveDoctors()
        {
            fileHandler.SaveDoctors(doctors);
        }

        public void LoadDoctors()
        {
            doctors = fileHandler.LoadDoctors();
            if (doctors == null)
            {
                doctors = new List<Doctor>();
            }
        }
    }
}
