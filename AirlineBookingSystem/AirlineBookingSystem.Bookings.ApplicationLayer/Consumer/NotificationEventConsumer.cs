using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineBookingSystem.Bookings.Application.Consumer
{
    public class NotificationEventConsumer : IConsumer<NotificationEvent>
    {
        public async Task Consume(ConsumeContext<NotificationEvent> context)
        {
            var message = context.Message;
            Console.WriteLine($"Received Notification Event: Recipient-{message.Recipient}, " +
                $"Message-{message.Message}, Type-{message.Type}");
            // Here you can add logic to handle the notification, e.g., log it, update a database, etc.
            await Task.CompletedTask;
        }
    }
}
