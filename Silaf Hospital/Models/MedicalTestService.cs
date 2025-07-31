using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public class MedicalTestService : IMedicalTestService
    {
        private List<MedicalTest> tests = new();
        private readonly MedicalTestFileHandler fileHandler = new();

        public MedicalTestService()
        {
            tests = fileHandler.LoadMedicalTests();
        }

        public void AddMedicalTest(MedicalTestInputDTO input, string patientId)
        {
            var test = new MedicalTest
            {
                Id = Guid.NewGuid().ToString(),
                PatientId = patientId,
                DoctorId = input.DoctorId,
                TestName = input.TestName,
                Description = input.Description,
                ScheduledDate = input.ScheduledDate,
                IsCompleted = false,
                TestDate = null,
                Result = null
            };

            tests.Add(test);
            fileHandler.SaveMedicalTests(tests);
            Console.WriteLine(" Medical test added.");
        }

        public void DeleteMedicalTest(string testId)
        {
            var test = GetMedicalTestById(testId);
            if (test != null)
            {
                tests.Remove(test);
                fileHandler.SaveMedicalTests(tests);
                Console.WriteLine(" Medical test deleted.");
            }
        }

        public void UpdateMedicalTest(string testId, MedicalTestInputDTO input)
        {
            var test = GetMedicalTestById(testId);
            if (test != null)
            {
                test.TestName = input.TestName;
                test.Description = input.Description;
                test.ScheduledDate = input.ScheduledDate;
                test.DoctorId = input.DoctorId;

                fileHandler.SaveMedicalTests(tests);
                Console.WriteLine(" Medical test updated.");
            }
        }

        public IEnumerable<MedicalTestOutputDTO> GetAllMedicalTests()
        {
            var result = new List<MedicalTestOutputDTO>();

            foreach (var test in tests)
            {
                result.Add(new MedicalTestOutputDTO
                {
                    Id = test.Id,
                    TestName = test.TestName,
                    Description = test.Description,
                    ScheduledDate = test.ScheduledDate,
                    TestDate = test.TestDate,
                    Result = test.Result,
                    DoctorId = test.DoctorId,
                    PatientId = test.PatientId,
                    IsCompleted = test.IsCompleted
                });
            }

            return result;
        }

        public IEnumerable<MedicalTestOutputDTO> GetTestsByPatientId(string patientId)
        {
            var result = new List<MedicalTestOutputDTO>();

            foreach (var test in tests)
            {
                if (test.PatientId == patientId)
                {
                    result.Add(new MedicalTestOutputDTO
                    {
                        Id = test.Id,
                        TestName = test.TestName,
                        Description = test.Description,
                        ScheduledDate = test.ScheduledDate,
                        TestDate = test.TestDate,
                        Result = test.Result,
                        DoctorId = test.DoctorId,
                        PatientId = test.PatientId,
                        IsCompleted = test.IsCompleted
                    });
                }
            }

            return result;
        }

        public IEnumerable<MedicalTestOutputDTO> GetTestsByDoctorId(string doctorId)
        {
            var result = new List<MedicalTestOutputDTO>();

            foreach (var test in tests)
            {
                if (test.DoctorId == doctorId)
                {
                    result.Add(new MedicalTestOutputDTO
                    {
                        Id = test.Id,
                        TestName = test.TestName,
                        Description = test.Description,
                        ScheduledDate = test.ScheduledDate,
                        TestDate = test.TestDate,
                        Result = test.Result,
                        DoctorId = test.DoctorId,
                        PatientId = test.PatientId,
                        IsCompleted = test.IsCompleted
                    });
                }
            }

            return result;
        }

        public IEnumerable<MedicalTestOutputDTO> FilterTests(string? patientId, string? doctorId, DateTime? date)
        {
            var result = new List<MedicalTestOutputDTO>();

            foreach (var test in tests)
            {
                bool match = true;

                if (!string.IsNullOrWhiteSpace(patientId) && test.PatientId != patientId)
                    match = false;
                if (!string.IsNullOrWhiteSpace(doctorId) && test.DoctorId != doctorId)
                    match = false;
                if (date.HasValue && test.ScheduledDate.Date != date.Value.Date)
                    match = false;

                if (match)
                {
                    result.Add(new MedicalTestOutputDTO
                    {
                        Id = test.Id,
                        TestName = test.TestName,
                        Description = test.Description,
                        ScheduledDate = test.ScheduledDate,
                        TestDate = test.TestDate,
                        Result = test.Result,
                        DoctorId = test.DoctorId,
                        PatientId = test.PatientId,
                        IsCompleted = test.IsCompleted
                    });
                }
            }

            return result;
        }

        public MedicalTest GetMedicalTestById(string testId)
        {
            foreach (var test in tests)
            {
                if (test.Id == testId)
                    return test;
            }

            return null;
        }
    }
}
