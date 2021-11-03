using System.Threading.Tasks;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Interfaces
{
    public interface IUserRepository : IRepository<PersonEntity>
    {
        Task<PersonEntity> GetAsync(string login, string password);
        Task<PersonEntity> GetAsync(string token);
    }
}
