using AirelineBookingSystem.Flights.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirelineBookingSystem.Flights.Core.Repositories
{
    public interface IFlightRepository
    {
        //Task<Entities.Flight> GetFlightByIdAsync(Guid id);
        Task<IEnumerable<Flight>> GetFlightsAsync();
        Task AddFlightAsync(Flight flight);
        //Task UpdateFlightAsync(Entities.Flight flight);
        Task DeleteFlightAsync(Guid id);
    }
}
