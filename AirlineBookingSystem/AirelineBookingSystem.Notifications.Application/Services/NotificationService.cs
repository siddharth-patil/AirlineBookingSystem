using AirelineBookingSystem.Notifications.Application.Interfaces;
using AirelineBookingSystem.Notifications.Core.Entities;
using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirelineBookingSystem.Notifications.Application.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public NotificationService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task SendNotificationAsync(Notification notification)
        {
            Console.WriteLine($"Notification sent to {notification.Recipient}: {notification.Message}");

            // Publish the notification to the message bus
            var notificationEvent = new NotificationEvent(notification.Recipient, notification.Message, notification.Type);

            await _publishEndpoint.Publish(notificationEvent);
        }
    }
}
