using Silaf_Hospital.Models;
using Silaf_Hospital.FilesHandling;
using System;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public class NotificationService : INotificationService
    {
        private List<Notification> notifications = new List<Notification>();
        private readonly NotificationFileHandler fileHandler = new NotificationFileHandler();

        public NotificationService()
        {
            LoadFromFile();
        }

        public void SendNotification(string userId, string message)
        {
            Notification note = new Notification
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                Message = message,
                Timestamp = DateTime.Now,
                IsRead = false
            };

            notifications.Add(note);
            SaveToFile();
            Console.WriteLine(" Notification sent.");
        }

        public List<Notification> GetNotifications(string userId)
        {
            List<Notification> result = new List<Notification>();
            foreach (Notification note in notifications)
            {
                if (note.UserId == userId)
                    result.Add(note);
            }
            return result;
        }

        public void MarkAllAsRead(string userId)
        {
            foreach (Notification note in notifications)
            {
                if (note.UserId == userId)
                    note.IsRead = true;
            }
            SaveToFile();
            Console.WriteLine(" All notifications marked as read.");
        }

        public void SaveToFile()
        {
            fileHandler.SaveNotifications(notifications);
        }

        public void LoadFromFile()
        {
            notifications = fileHandler.LoadNotifications();
        }
    }
}
