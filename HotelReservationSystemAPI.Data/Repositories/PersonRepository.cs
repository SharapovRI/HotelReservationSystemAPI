using HotelReservationSystemAPI.Data.IRepositories;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class PersonRepository: Repository<PersonEntity>, IPersonRepository
    {
        public PersonRepository(NpgsqlContext npgsqlContext)
            : base(npgsqlContext)
        {

        }
    }
}
