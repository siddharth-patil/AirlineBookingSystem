using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirelineBookingSystem.Payements.Application.Commands
{
    public record RefundPayementCommand(Guid PaymentId) : IRequest;
}
