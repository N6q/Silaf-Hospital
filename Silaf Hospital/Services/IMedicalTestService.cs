using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public interface IMedicalTestService
    {
        void AddMedicalTest(MedicalTestInputDTO input, string patientId);
        void DeleteMedicalTest(string testId);
        void UpdateMedicalTest(string testId, MedicalTestInputDTO input);
        IEnumerable<MedicalTestOutputDTO> GetAllMedicalTests();
        IEnumerable<MedicalTestOutputDTO> GetTestsByPatientId(string patientId);
        IEnumerable<MedicalTestOutputDTO> GetTestsByDoctorId(string doctorId);
        IEnumerable<MedicalTestOutputDTO> FilterTests(string? patientId, string? doctorId, DateTime? date);
        MedicalTest GetMedicalTestById(string testId);
    }
}
