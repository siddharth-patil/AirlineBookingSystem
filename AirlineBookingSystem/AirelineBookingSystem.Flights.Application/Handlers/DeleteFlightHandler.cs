using AirelineBookingSystem.Flights.Application.Commands;
using AirelineBookingSystem.Flights.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirelineBookingSystem.Flights.Application.Handlers
{
    public class DeleteFlightHandler : IRequestHandler<DeleteFlightCommand>
    {
        private readonly IFlightRepository _repository;
        public DeleteFlightHandler(IFlightRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteFlightAsync(request.Id);
        }
    }
}
