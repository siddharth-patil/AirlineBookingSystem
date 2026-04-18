using AirelineBookingSystem.Notifications.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirelineBookingSystem.Notifications.Core.Repositories
{
    public interface INotificationRepository
    {
        Task LogNotificationAsync(Notification notification);
    }
}
