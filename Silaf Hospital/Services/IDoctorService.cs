using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public interface IDoctorService
    {
        void AddDoctor(DoctorInputDTO input);
        bool EmailExists(string email);
        List<Doctor> GetAllDoctors();
        List<Doctor> GetDoctorByBrancDep(string branchId, string departmentId);
        Doctor GetDoctorByEmail(string email);
        Doctor GetDoctorById(string id);
        Doctor GetDoctorByName(string name);
        DoctorOutputDTO GetDoctorData(string docName, string docId);
        List<DoctorOutputDTO> GetDoctorsByBranchName(string branchName);
        List<DoctorOutputDTO> GetDoctorsByDepartmentName(string departmentName);
        void UpdateDoctor(Doctor doctor);
        void UpdateDoctorDetails(DoctorUpdateDTO input);
        DoctorOutputDTO GetDoctorDetailsById(string id);
        void SaveToFile();
        void LoadFromFile();
        bool DeleteDoctor(string id);
    }
}
