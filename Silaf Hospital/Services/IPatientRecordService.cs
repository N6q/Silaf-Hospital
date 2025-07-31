using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;

namespace Silaf_Hospital.Services
{
    public interface IPatientRecordService
    {
        IEnumerable<PatientRecordOutputDTO> GetAllRecords(); 
        void CreateRecord(PatientRecordInputDTO record, int doctorId);
        void UpdateRecord(int rid, string? treatment, string? inspection, int doctorId);
        void DeleteRecord(int rid);
        public IEnumerable<PatientRecordOutputDTO> GetRecords(int patientId);
    }
}
