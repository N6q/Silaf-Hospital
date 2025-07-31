using System;

namespace Silaf_Hospital.Models
{
    public class MedicalTest
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string PatientId { get; set; }
        public string? DoctorId { get; set; }

        public string TestName { get; set; }
        public string? Description { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime? TestDate { get; set; } = null; 
        public string? Result { get; set; }
        public bool IsCompleted { get; set; } = false;

        public MedicalTest() { }

        public MedicalTest(string patientId, string testName, DateTime scheduledDate, string doctorId = null, string description = null)
        {
            Id = Guid.NewGuid().ToString();
            PatientId = patientId;
            TestName = testName;
            ScheduledDate = scheduledDate;
            DoctorId = doctorId;
            Description = description;
        }

        public void CompleteTest(string result)
        {
            IsCompleted = true;
            Result = result;
            TestDate = DateTime.Now; 
            Console.WriteLine($" Test '{TestName}' completed. Result: {Result}");
        }

        public void Display()
        {
            Console.WriteLine($" Test: {TestName} | Patient: {PatientId} | Doctor: {DoctorId ?? "N/A"}");
            Console.WriteLine($" Scheduled: {ScheduledDate} | Status: {(IsCompleted ? " Done" : " Pending")}");
            if (IsCompleted && !string.IsNullOrWhiteSpace(Result))
            {
                Console.WriteLine($" Result: {Result}");
                Console.WriteLine($" Done on: {TestDate}");
            }
        }
    }
}
