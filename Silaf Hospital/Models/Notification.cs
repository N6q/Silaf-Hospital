using System;

namespace Silaf_Hospital.Models
{
    public class Notification
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string RecipientId { get; set; }
        public Role RecipientRole { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; } = DateTime.Now;
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; } = false;

        public Notification() { }

        public Notification(string recipientId, Role role, string message)
        {
            Id = Guid.NewGuid().ToString();
            RecipientId = recipientId;
            RecipientRole = role;
            Message = message;
            SentAt = DateTime.Now;
            IsRead = false;
        }

        public void MarkAsRead()
        {
            IsRead = true;
            Console.WriteLine(" Notification marked as read.");
        }

        public void Display()
        {
            Console.WriteLine($" Notification for: {RecipientId} ({RecipientRole})");
            Console.WriteLine($" {SentAt:G} | {(IsRead ? " Read" : " Unread")}");
            Console.WriteLine($" Message: {Message}");
        }
    }
}
