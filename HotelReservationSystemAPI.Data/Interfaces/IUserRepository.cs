using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Interfaces
{
    public interface IUserRepository : IRepository<PersonEntity>
    {
        Task<PersonEntity> GetUserAsync(string login, string password);
        Task<bool> GetUserAsync(string login);
        Task<PersonEntity> GetTokenAsync(string token);
    }
}
