using System.Linq;
using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class UserRepository : Repository<PersonEntity>, IUserRepository
    {
        public UserRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }

        protected override IQueryable<PersonEntity> SetWithIncludes => _set
            .Include(p => p.Orders)
            .Include(p => p.Role);

        public async Task<PersonEntity> GetUserAsync(string login, string password)
        {
            var result = await SetWithIncludes.FirstOrDefaultAsync(user => user.Login == login && user.Password == password);
            return result;
        }
        public async Task<bool> GetUserAsync(string login)
        {
            var result = await _set.AnyAsync(user => user.Login == login);
            return result;
        }

        public async Task<PersonEntity> GetTokenAsync(string token)
        {
            var result = await SetWithIncludes.FirstOrDefaultAsync(user => user.RefreshToken.Token == token);
            return result;
        }
    }
}
