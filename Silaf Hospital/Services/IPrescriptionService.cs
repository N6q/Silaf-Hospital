using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public interface IPrescriptionService
    {
        void AddPrescription(PrescriptionInputDTO input, string doctorId, string patientId);
        void DeletePrescription(string prescriptionId);
        void UpdatePrescription(string prescriptionId, PrescriptionInputDTO input);
        IEnumerable<PrescriptionOutputDTO> GetPrescriptionsByPatientId(string patientId);
        IEnumerable<PrescriptionOutputDTO> GetPrescriptionsByDoctorId(string doctorId);
        IEnumerable<PrescriptionOutputDTO> GetAllPrescriptions();
        Prescription GetPrescriptionById(string prescriptionId);
    }
}
