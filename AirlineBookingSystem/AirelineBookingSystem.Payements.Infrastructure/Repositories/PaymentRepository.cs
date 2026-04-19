using AirelineBookingSystem.Payements.Core.Entities;
using AirelineBookingSystem.Payements.Core.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirelineBookingSystem.Payements.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDbConnection _dbConnetion;

        public PaymentRepository(IDbConnection dbConnetion)
        {
            _dbConnetion = dbConnetion;
        }

        public async Task ProcessPaymentAsync(Payement payment)
        {
            const string sql = @"INSERT INTO Payments (Id, BookingId, Amount, PaymentDate) 
                                VALUES (@Id, @BookingId, @Amount, @PaymentDate)";

            await _dbConnetion.ExecuteAsync(sql, payment);
        }

        public async Task RefundPayementAsync(Guid id)
        {
            const string sql = @"DELETE FROM Payments WHERE Id = @Id";
            await _dbConnetion.ExecuteAsync(sql, new { Id = id });
        }
    }
}
