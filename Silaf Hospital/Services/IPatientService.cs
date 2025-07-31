using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public interface IPatientService
    {
        void AddPatient(PatientInputDTO input);
        IEnumerable<Patient> GetAllPatients();
        Patient GetPatientById(string id);                    
        Patient GetPatientByName(string name);                
        void UpdatePatientDetails(string id, string phoneNumber);
        PatientOutputDTO GetPatientData(string name, string id);   
        bool DeletePatient(string id);                       
        void SaveToFile();
        void LoadFromFile();
    }
}
