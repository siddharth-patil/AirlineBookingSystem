using AirelineBookingSystem.Payements.Application.Commands;
using AirelineBookingSystem.Payements.Core.Entities;
using AirelineBookingSystem.Payements.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AirelineBookingSystem.Payements.Application.Handlers
{
    public class RefundPaymentHandler : IRequestHandler<RefundPayementCommand>
    {
        private readonly IPaymentRepository _repository;

        public RefundPaymentHandler(IPaymentRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(RefundPayementCommand request, CancellationToken cancellationToken)
        {
            await _repository.RefundPayementAsync(request.PaymentId);
        }
    }
}
