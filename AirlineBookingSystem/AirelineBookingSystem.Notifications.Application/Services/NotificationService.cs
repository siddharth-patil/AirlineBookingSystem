using AirelineBookingSystem.Notifications.Application.Interfaces;
using AirelineBookingSystem.Notifications.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirelineBookingSystem.Notifications.Application.Services
{
    public class NotificationService : INotificationService
    {
        public async Task SendNotificationAsync(Notification notification)
        {
            Console.WriteLine($"Notification sent to {notification.Recipient}: {notification.Message}");
        }
    }
}
