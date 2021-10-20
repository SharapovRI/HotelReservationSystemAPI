using System;
using System.Collections.Generic;
using System.Text;
using HotelReservationSystemAPI.Data.IRepositories;
using HotelReservationSystemAPI.Data.Models;

namespace HotelReservationSystemAPI.Data.Repositories
{
    public class PersonRepository: Repository<PersonEntity>, IPersonRepository
    {
    }
}
