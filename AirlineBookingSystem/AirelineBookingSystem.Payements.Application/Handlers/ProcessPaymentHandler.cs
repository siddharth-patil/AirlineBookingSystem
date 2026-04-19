using AirelineBookingSystem.Payements.Application.Commands;
using AirelineBookingSystem.Payements.Core.Entities;
using AirelineBookingSystem.Payements.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirelineBookingSystem.Payements.Application.Handlers
{
    public class ProcessPaymentHandler : IRequestHandler<ProcessPayementCommand, Guid>
    {
        private readonly IPaymentRepository _repository;

        public ProcessPaymentHandler(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> Handle(ProcessPayementCommand request, CancellationToken cancellationToken)
        {
            var payment = new Payement
            {
                Id = Guid.NewGuid(),
                BookingId = request.BookingId,
                Amount = request.Amount,
               PaymentDate = DateTime.UtcNow
            };

            await _repository.ProcessPaymentAsync(payment);
            return payment.Id;
        }
    }
}
