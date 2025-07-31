using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public interface IClinicService
    {
        void AddClinic(ClinicInputDTO input);
        IEnumerable<Clinic> GetAllClinic();
        IEnumerable<Clinic> GetClinicByBranchDep(int branchId, int departmentId);
        Clinic GetClinicById(int clinicId);
        Clinic GetClinicByName(string clinicName);
        string GetClinicName(int clinicId);
        IEnumerable<Clinic> GetClinicsByBranchName(string branchName);
        IEnumerable<Clinic> GetClinicsByDepartmentId(int departmentId);
        decimal GetPrice(int clinicId);
        void SetClinicStatus(int clinicId);
        void UpdateClinicDetails(int clinicId, ClinicInputDTO input);
        ClinicOutputDTO GetClinicData(string name, string id);
        void SaveToFile();
        void LoadFromFile();
        bool DeleteClinic(string id);
    }
}
