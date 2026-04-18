using AirelineBookingSystem.Notifications.Core.Entities;
using AirelineBookingSystem.Notifications.Core.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirelineBookingSystem.Notifications.Infrastructure.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly IDbConnection _dbConnetion;

        public NotificationRepository(IDbConnection dbConnetion)
        {
            _dbConnetion = dbConnetion;
        }

        public async Task LogNotificationAsync(Notification notification)
        {
            const string sql = @"INSERT INTO Notifications (Id, Recipient, Message, Type, SentAt)
                                 VALUES (@Id, @Recipient, @Message, @Type, @SentAt)";

            await _dbConnetion.ExecuteAsync(sql, notification);
        }
    }
}
