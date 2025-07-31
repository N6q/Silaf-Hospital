using System;

namespace Silaf_Hospital.DTOs
{
    public class NotificationOutputDTO
    {
        public string Id { get; set; }
        public string RecipientId { get; set; }
        public string Role { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
        public bool IsRead { get; set; }
    }
}
