using Silaf_Hospital.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Silaf_Hospital.FilesHandling
{
    public class FeedbackFileHandler
    {
        private readonly string filePath = "data/feedback.txt";

        public void SaveFeedbacks(List<Feedback> feedbacks)
        {
            Directory.CreateDirectory("data");
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var f in feedbacks)
                {
                    writer.WriteLine($"{f.Id},{f.PatientId},{f.DoctorId},{f.AppointmentId},{f.Rating},{f.Comment},{f.SubmittedAt},{f.IsRead}");
                }
            }

            Console.WriteLine(" Feedback data saved.");
        }

        public List<Feedback> LoadFeedbacks()
        {
            List<Feedback> feedbacks = new List<Feedback>();

            if (!File.Exists(filePath))
                return feedbacks;

            foreach (var line in File.ReadAllLines(filePath))
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 8)
                {
                    Feedback feedback = new Feedback
                    {
                        Id = parts[0],
                        PatientId = parts[1],
                        DoctorId = parts[2],
                        AppointmentId = parts[3],
                        Rating = int.TryParse(parts[4], out int r) ? r : 0,
                        Comment = parts[5],
                        SubmittedAt = DateTime.TryParse(parts[6], out var dt) ? dt : DateTime.Now,
                        IsRead = bool.TryParse(parts[7], out var read) && read
                    };

                    feedbacks.Add(feedback);
                }
            }

            Console.WriteLine(" Feedback data loaded.");
            return feedbacks;
        }
    }
}
