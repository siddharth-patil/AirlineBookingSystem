using AirelineBookingSystem.Notifications.Application.Commands;
using AirelineBookingSystem.Notifications.Application.Interfaces;
using AirelineBookingSystem.Notifications.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirelineBookingSystem.Notifications.Application.Handlers
{
    public record SendNotificationHandler: IRequestHandler<SendNotificationCommand>
    {
        private readonly INotificationService _notificationService;

        public SendNotificationHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task Handle(SendNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = new Notification
            {
                Id = Guid.NewGuid(),
                Recipient = request.Recipient,
                Message = request.Message,
                Type = request.Type
            };
            await _notificationService.SendNotificationAsync(notification);
        }
    }
}
