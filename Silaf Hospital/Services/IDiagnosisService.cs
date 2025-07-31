using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public interface IDiagnosisService
    {
        void AddDiagnosis(DiagnosisInputDTO input, string patientId, string doctorId);
        void DeleteDiagnosis(string diagnosisId);
        void UpdateDiagnosis(string diagnosisId, DiagnosisInputDTO input);
        IEnumerable<DiagnosisOutputDTO> GetDiagnosesByPatientId(string patientId);
        IEnumerable<DiagnosisOutputDTO> GetDiagnosesByDoctorId(string doctorId);
        IEnumerable<DiagnosisOutputDTO> FilterDiagnoses(string? patientId, string? doctorId, DateTime? date);
        Diagnosis GetDiagnosisById(string diagnosisId);
    }
}
