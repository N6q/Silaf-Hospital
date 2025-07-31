using Silaf_Hospital.Models;
using System.Collections.Generic;

namespace Silaf_Hospital.Services
{
    public interface INotificationService
    {
        void SendNotification(string userId, string message);
        List<Notification> GetNotifications(string userId);
        void MarkAllAsRead(string userId);
        void SaveToFile();
        void LoadFromFile();
    }
}
