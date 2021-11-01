using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class RoomsCostRepository: Repository<RoomsCostEntity>, IRoomsCostRepository
    {
        public RoomsCostRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {
            _context = npgsqlContext;
        }

        private readonly NpgsqlContext _context;

        public async Task<IEnumerable<RoomsCostEntity>> GetListAsync(int hotelId)
        {
            return await _context.RoomsCosts.Where(roomCost => roomCost.HotelId == hotelId).ToListAsync();
        }
    }
}