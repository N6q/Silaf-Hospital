using System;

namespace Silaf_Hospital.Models
{
    public class Feedback
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string PatientId { get; set; }
        public string? DoctorId { get; set; }
        public string? AppointmentId { get; set; } //  linked to a booking

        private int rating;
        public int Rating
        {
            get { return rating; }
            set
            {
                if (value < 1) rating = 1;
                else if (value > 5) rating = 5;
                else rating = value;
            }
        }

        public string Comment { get; set; }
        public DateTime SubmittedAt { get; set; } = DateTime.Now;
        public bool IsRead { get; set; } = false;

        public Feedback() { }

        public Feedback(string patientId, string comment, int rating, string doctorId = null, string appointmentId = null)
        {
            Id = Guid.NewGuid().ToString();
            PatientId = patientId;
            Comment = comment;
            Rating = rating;
            DoctorId = doctorId;
            AppointmentId = appointmentId;
            SubmittedAt = DateTime.Now;
        }

        public void DisplayFeedback()
        {
            Console.WriteLine($"⭐ Feedback ID: {Id}");
            Console.WriteLine($"Patient ID: {PatientId} | Doctor ID: {DoctorId ?? "N/A"} | Appointment ID: {AppointmentId ?? "N/A"}");
            Console.WriteLine($"Rating: {Rating} ★ | Comment: {Comment}");
            Console.WriteLine($"Submitted on: {SubmittedAt}");
        }
    }
}
