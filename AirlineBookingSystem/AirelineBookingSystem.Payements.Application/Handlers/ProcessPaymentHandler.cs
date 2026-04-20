using AirelineBookingSystem.Payements.Application.Commands;
using AirelineBookingSystem.Payements.Core.Entities;
using AirelineBookingSystem.Payements.Core.Repositories;
using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using MassTransit;
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
        private readonly IPublishEndpoint _publishEndpoint;
        public ProcessPaymentHandler(IPaymentRepository repository, IPublishEndpoint publishEndpoint)
        {
            _repository = repository;
            _publishEndpoint = publishEndpoint;
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

            // Publish an PaymentProcessedEvent to notify other services about the processed payment
            await _publishEndpoint.Publish(new PaymentProcessedEvent
            (
                payment.Id,
                payment.BookingId,
                payment.Amount,
                payment.PaymentDate
            ));

            return payment.Id;
        }
    }
}
