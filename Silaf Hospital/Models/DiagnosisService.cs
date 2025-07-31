using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public class DiagnosisService : IDiagnosisService
    {
        private List<Diagnosis> diagnoses = new();
        private readonly DiagnosisFileHandler fileHandler = new();

        public DiagnosisService()
        {
            diagnoses = fileHandler.LoadDiagnoses();
        }

        public void AddDiagnosis(DiagnosisInputDTO input, string patientId, string doctorId)
        {
            var diagnosis = new Diagnosis
            {
                Id = Guid.NewGuid().ToString(),
                PatientId = patientId,
                DoctorId = doctorId,
                Name = input.Name,
                Notes = input.Notes,
                Severity = input.Severity,
                DateDiagnosed = input.DateDiagnosed
            };

            diagnoses.Add(diagnosis);
            fileHandler.SaveDiagnoses(diagnoses);
            Console.WriteLine(" Diagnosis added.");
        }

        public void DeleteDiagnosis(string diagnosisId)
        {
            var d = GetDiagnosisById(diagnosisId);
            if (d != null)
            {
                diagnoses.Remove(d);
                fileHandler.SaveDiagnoses(diagnoses);
                Console.WriteLine(" Diagnosis deleted.");
            }
        }

        public void UpdateDiagnosis(string diagnosisId, DiagnosisInputDTO input)
        {
            var d = GetDiagnosisById(diagnosisId);
            if (d != null)
            {
                d.Name = input.Name;
                d.Notes = input.Notes;
                d.Severity = input.Severity;
                d.DateDiagnosed = input.DateDiagnosed;

                fileHandler.SaveDiagnoses(diagnoses);
                Console.WriteLine(" Diagnosis updated.");
            }
        }

        public IEnumerable<DiagnosisOutputDTO> GetDiagnosesByPatientId(string patientId)
        {
            var result = new List<DiagnosisOutputDTO>();
            foreach (var d in diagnoses)
            {
                if (d.PatientId == patientId)
                    result.Add(ToOutput(d));
            }
            return result;
        }

        public IEnumerable<DiagnosisOutputDTO> GetDiagnosesByDoctorId(string doctorId)
        {
            var result = new List<DiagnosisOutputDTO>();
            foreach (var d in diagnoses)
            {
                if (d.DoctorId == doctorId)
                    result.Add(ToOutput(d));
            }
            return result;
        }

        public IEnumerable<DiagnosisOutputDTO> FilterDiagnoses(string? patientId, string? doctorId, DateTime? date)
        {
            var result = new List<DiagnosisOutputDTO>();

            foreach (var d in diagnoses)
            {
                bool match = true;
                if (!string.IsNullOrWhiteSpace(patientId) && d.PatientId != patientId)
                    match = false;
                if (!string.IsNullOrWhiteSpace(doctorId) && d.DoctorId != doctorId)
                    match = false;
                if (date.HasValue && d.DateDiagnosed.Date != date.Value.Date)
                    match = false;

                if (match)
                    result.Add(ToOutput(d));
            }

            return result;
        }

        public Diagnosis GetDiagnosisById(string diagnosisId)
        {
            return diagnoses.Find(d => d.Id == diagnosisId);
        }

        private DiagnosisOutputDTO ToOutput(Diagnosis d)
        {
            return new DiagnosisOutputDTO
            {
                Id = d.Id,
                Name = d.Name,
                Notes = d.Notes,
                PatientId = d.PatientId,
                DoctorId = d.DoctorId,
                Severity = d.Severity,
                DateDiagnosed = d.DateDiagnosed
            };
        }
    }
}
