using AirelineBookingSystem.Payements.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirelineBookingSystem.Payements.Core.Repositories
{
    public interface IPaymentRepository
    {
        Task ProcessPaymentAsync(Payement payment);
        Task RefundPayementAsync(Guid id);
    }
}
