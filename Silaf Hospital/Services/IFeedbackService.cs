using Silaf_Hospital.DTOs;
using Silaf_Hospital.Models;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public interface IFeedbackService
    {
        void SubmitFeedback(FeedbackInputDTO input, string patientId);
        void DeleteFeedback(string feedbackId);
        IEnumerable<FeedbackOutputDTO> GetAllFeedback();
        IEnumerable<FeedbackOutputDTO> GetFeedbackByPatientId(string patientId);
        Feedback GetFeedbackById(string feedbackId);
        void MarkAsReviewed(string feedbackId);
    }
}
