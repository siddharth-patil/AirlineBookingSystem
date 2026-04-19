using AirelineBookingSystem.Notifications.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirelineBookingSystem.Notifications.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendNotificationAsync(Notification notifications);
    }
}
