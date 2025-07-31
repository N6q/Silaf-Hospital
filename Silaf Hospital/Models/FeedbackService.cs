using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public class FeedbackService : IFeedbackService
    {
        private List<Feedback> feedbacks = new List<Feedback>();
        private readonly FeedbackFileHandler fileHandler = new FeedbackFileHandler();

        public FeedbackService()
        {
            LoadFromFile();
        }

        public void SubmitFeedback(FeedbackInputDTO input, string patientId)
        {
            Feedback feedback = new Feedback
            {
                Id = Guid.NewGuid().ToString(),
                PatientId = patientId,
                DoctorId = input.DoctorId,
                AppointmentId = input.AppointmentId,
                Rating = input.Rating,
                Comment = input.Comment,
                SubmittedAt = DateTime.Now,
                IsRead = false
            };

            feedbacks.Add(feedback);
            SaveToFile();
            Console.WriteLine(" Feedback submitted.");
        }

        public void DeleteFeedback(string feedbackId)
        {
            Feedback f = GetFeedbackById(feedbackId);
            if (f != null)
            {
                feedbacks.Remove(f);
                SaveToFile();
                Console.WriteLine(" Feedback deleted.");
            }
        }

        public IEnumerable<FeedbackOutputDTO> GetAllFeedback()
        {
            List<FeedbackOutputDTO> result = new List<FeedbackOutputDTO>();
            foreach (Feedback f in feedbacks)
            {
                result.Add(new FeedbackOutputDTO
                {
                    Id = f.Id,
                    PatientId = f.PatientId,
                    DoctorId = f.DoctorId,
                    AppointmentId = f.AppointmentId,
                    Rating = f.Rating,
                    Comment = f.Comment,
                    SubmittedAt = f.SubmittedAt,
                    IsRead = f.IsRead
                });
            }
            return result;
        }

        public IEnumerable<FeedbackOutputDTO> GetFeedbackByPatientId(string patientId)
        {
            List<FeedbackOutputDTO> result = new List<FeedbackOutputDTO>();
            foreach (Feedback f in feedbacks)
            {
                if (f.PatientId == patientId)
                {
                    result.Add(new FeedbackOutputDTO
                    {
                        Id = f.Id,
                        PatientId = f.PatientId,
                        DoctorId = f.DoctorId,
                        AppointmentId = f.AppointmentId,
                        Rating = f.Rating,
                        Comment = f.Comment,
                        SubmittedAt = f.SubmittedAt,
                        IsRead = f.IsRead
                    });
                }
            }
            return result;
        }

        public Feedback GetFeedbackById(string feedbackId)
        {
            foreach (Feedback f in feedbacks)
            {
                if (f.Id == feedbackId)
                    return f;
            }
            return null;
        }

        public void MarkAsReviewed(string feedbackId)
        {
            Feedback f = GetFeedbackById(feedbackId);
            if (f != null)
            {
                f.IsRead = true;
                SaveToFile();
                Console.WriteLine(" Feedback marked as reviewed.");
            }
        }

        private void SaveToFile()
        {
            fileHandler.SaveFeedbacks(feedbacks);
        }

        private void LoadFromFile()
        {
            feedbacks = fileHandler.LoadFeedbacks();
        }
    }
}
