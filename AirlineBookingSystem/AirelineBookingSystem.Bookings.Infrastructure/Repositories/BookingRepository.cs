using AirlineBookingSystem.Bookings.Core.Entities;
using AirlineBookingSystem.Bookings.Core.Repositories;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirelineBookingSystem.Bookings.Infrastructure.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IDbConnection _dbConnection;

        public BookingRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task AddBookingAsync(Booking booking)
        {
            const string sql = @"INSERT INTO Bookings (Id, FlightId, PassangerName, SeatNumber, BookingDate)
                VALUES (@Id, @FlightId, @PassangerName, @SeatNumber, @BookingDate)";

            await _dbConnection.ExecuteAsync(sql, booking);
        }

        public Task<Booking> GetBookingByIdAsync(Guid id)
        {
            const string sql = "SELECT * FROM Bookings WHERE Id = @Id";
            return _dbConnection.QuerySingleOrDefaultAsync<Booking>(sql, new { Id = id });
        }
    }
}
