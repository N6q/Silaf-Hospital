using Silaf_Hospital.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Silaf_Hospital.FilesHandling
{
    public class NotificationFileHandler
    {
        private readonly string filePath = "data/notifications.txt";

        public void SaveNotifications(List<Notification> notifications)
        {
            Directory.CreateDirectory("data");

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Notification n in notifications)
                {
                    writer.WriteLine($"{n.Id},{n.UserId},{n.Message},{n.Timestamp},{n.IsRead}");
                }
            }

            Console.WriteLine(" Notifications saved.");
        }

        public List<Notification> LoadNotifications()
        {
            List<Notification> notifications = new List<Notification>();

            if (!File.Exists(filePath))
                return notifications;

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');

                if (parts.Length >= 5)
                {
                    Notification note = new Notification
                    {
                        Id = parts[0],
                        UserId = parts[1],
                        Message = parts[2],
                        Timestamp = DateTime.TryParse(parts[3], out DateTime dt) ? dt : DateTime.Now,
                        IsRead = bool.TryParse(parts[4], out bool isRead) && isRead
                    };

                    notifications.Add(note);
                }
            }

            Console.WriteLine(" Notifications loaded.");
            return notifications;
        }
    }
}
