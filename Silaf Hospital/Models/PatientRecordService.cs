
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public class PatientRecordService
    {
        private List<PatientRecord> records = new List<PatientRecord>();
        private readonly PatientRecordFileHandler fileHandler = new PatientRecordFileHandler();

        public PatientRecordService()
        {
            LoadRecords();
        }

        public void AddRecord(string doctorId, string patientId, string clinicId, string summary)
        {
            PatientRecord record = new PatientRecord();
            record.DoctorId = doctorId;
            record.PatientId = patientId;
            record.ClinicId = clinicId;
            record.VisitDate = DateTime.Now;
            record.DiagnosisSummary = summary;

            records.Add(record);
            SaveRecords();
            Console.WriteLine("Patient record added successfully.");
        }

        public void AddDiagnosisToRecord(string recordId, Diagnosis diagnosis)
        {
            PatientRecord record = null;
            foreach (var r in records)
            {
                if (r.Id == recordId)
                {
                    record = r;
                    break;
                }
            }

            if (record != null)
            {
                record.Diagnoses.Add(diagnosis);
                SaveRecords();
                Console.WriteLine("Diagnosis added.");
            }
            else
            {
                Console.WriteLine("Record not found.");
            }
        }

        public void AddPrescriptionToRecord(string recordId, Prescription prescription)
        {
            PatientRecord record = null;
            foreach (var r in records)
            {
                if (r.Id == recordId)
                {
                    record = r;
                    break;
                }
            }

            if (record != null)
            {
                record.Prescriptions.Add(prescription);
                SaveRecords();
                Console.WriteLine("Prescription added.");
            }
            else
            {
                Console.WriteLine("Record not found.");
            }
        }

        public List<PatientRecord> GetRecordsByDoctorId(string doctorId)
        {
            List<PatientRecord> result = new List<PatientRecord>();
            foreach (var r in records)
            {
                if (r.DoctorId == doctorId)
                {
                    result.Add(r);
                }
            }
            return result;
        }

        public List<PatientRecord> GetRecordsByPatientId(string patientId)
        {
            List<PatientRecord> result = new List<PatientRecord>();
            foreach (var r in records)
            {
                if (r.PatientId == patientId)
                {
                    result.Add(r);
                }
            }
            return result;
        }

        public void SaveRecords()
        {
            fileHandler.SaveRecords(records);
        }

        public void LoadRecords()
        {
            records = fileHandler.LoadRecords();
            if (records == null)
            {
                records = new List<PatientRecord>();
            }
        }
    }
}
