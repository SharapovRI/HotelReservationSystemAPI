using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
using HotelReservationSystemAPI.Business.Exceptions;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.Models.Request;
using HotelReservationSystemAPI.Business.QueryModels;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using HotelReservationSystemAPI.Data.Query;

namespace HotelReservationSystemAPI.Business.Services
{
    public class AdditionalFacilityService : IAdditionalFacilityService
    {
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;
        private readonly IAdditionalFacilityRepository _additionalFacilityRepository;
        private readonly IAdditionalFacilityOrderRepository _additionalFacilityOrderRepository;
        public AdditionalFacilityService(IMapper mapper, IAdditionalFacilityRepository additionalFacilityRepository, IRoomRepository roomRepository, IAdditionalFacilityOrderRepository additionalFacilityOrderRepository)
        {
            _mapper = mapper;
            _additionalFacilityRepository = additionalFacilityRepository;
            _roomRepository = roomRepository;
            _additionalFacilityOrderRepository = additionalFacilityOrderRepository;
        }

        public async Task<AdditionalFacilityModel> CreateAsync(FacilityRequestModel additionalFacilityModel)
        {

            var additionalFacility = _mapper.Map<FacilityRequestModel, AdditionalFacilityEntity>(additionalFacilityModel);

            var entity = await _additionalFacilityRepository.CreateAsync(additionalFacility);

            if (entity == null)
                throw new SomethingWrong("Something went wrong!\nAdditional facility is not created.");

            return _mapper.Map<AdditionalFacilityEntity, AdditionalFacilityModel>(entity);
        }

        public async Task<AdditionalFacilityModel> DeleteAsync(int id)
        {
            var additionalFacility = await _additionalFacilityRepository.DeleteAsync(id);

            if (additionalFacility == null)
                throw new BadRequest("Additional facility with this id doesn't exists.");

            return _mapper.Map<AdditionalFacilityEntity, AdditionalFacilityModel>(additionalFacility);
        }

        public async Task<AdditionalFacilityModel> GetAsync(int id)
        {
            var additionalFacility = await _additionalFacilityRepository.GetAsync(id);

            if (additionalFacility == null)
                throw new BadRequest("Additional facility with this id doesn't exists.");

            return _mapper.Map<AdditionalFacilityEntity, AdditionalFacilityModel>(additionalFacility);
        }

        public async Task<AdditionalFacilityOrderModel> GetOrderFacilityAsync(int id)
        {
            var additionalOrderFacility = await _additionalFacilityOrderRepository.GetAsync(id);

            if (additionalOrderFacility == null)
                throw new BadRequest("Additional facility with this id doesn't exists.");

            return _mapper.Map<AdditionalFacilityOrderEntity, AdditionalFacilityOrderModel>(additionalOrderFacility);
        }

        public async Task<List<AdditionalFacilityOrderModel>> GetFacilitiesOrdersRange(int[] ids)
        {
            List<AdditionalFacilityOrderModel> facilitiesList = new List<AdditionalFacilityOrderModel>();
            foreach (var id in ids)
            {
                var facility = await GetOrderFacilityAsync(id);
                facilitiesList.Add(facility);
            }

            return facilitiesList;
        }

        public async Task<IList<AdditionalFacilityModel>> GetListAsync(AdditionalFacilityQueryModel queryModel)
        {
            var queryParameters = GetQueryParameters(queryModel);

            var (entities, pageCount) = await _additionalFacilityRepository.GetListAsync(queryParameters);

            return _mapper.Map<IList<AdditionalFacilityEntity>, IList<AdditionalFacilityModel>>(entities);
        }

        private QueryParameters<AdditionalFacilityEntity> GetQueryParameters(AdditionalFacilityQueryModel model)
        {
            if (model == null)
                throw new ArgumentNullException($"{nameof(model)}");

            var queryParameters = new QueryParameters<AdditionalFacilityEntity>
            {
                FilterRule = GetFilterRule(model),
                PaginationRule = GetPageRule(model)
            };

            return queryParameters;
        }

        private FilterRule<AdditionalFacilityEntity> GetFilterRule(AdditionalFacilityQueryModel model)
        {
            var filterRule = new FilterRule<AdditionalFacilityEntity>
            {
                FilterExpression = facility =>
                    (model.HotelId == facility.HotelId) &&
                    (!model.IsCostValid() || model.IsCostValid() && facility.Cost >= model.MinCost && facility.Cost <= model.MaxCost)
            };

            return filterRule;
        }

        private PaginationRule GetPageRule(AdditionalFacilityQueryModel model)
        {
            var pageRule = new PaginationRule();

            if (!model.IsValidPageModel)
                return pageRule;

            pageRule.Index = model.Index;
            pageRule.Size = model.Size;

            return pageRule;
        }

        public async Task<bool> IsFacilitiesValid(OrderModel orderModel)
        {
            if (orderModel.AdditionalFacilities == null || orderModel.AdditionalFacilities.Length < 1) return true;

            var room = await _roomRepository.GetAsync(orderModel.RoomId);
            if (room == null) return false;

            var facilitiesCosts = await GetListAsync(new AdditionalFacilityQueryModel()
            {
                HotelId = room.HotelId
            });

            var difference = orderModel.AdditionalFacilities.Except(facilitiesCosts.Select(facil => facil.Id).ToArray())
                .Any();

            return !difference;
        }

        public async Task<bool> IsCostValid(OrderModel orderModel)
        {
            var room = await _roomRepository.GetAsync(orderModel.RoomId);
            if (room == null) return false;

            decimal cost = 0;
            var type = room.RoomType;

            if (type == null)
                throw new SomethingWrong("This room doesn't exists.");

            cost += type.Cost;

            if (orderModel.AdditionalFacilities == null)
                return orderModel.Cost == cost;

            var facilitiesCosts = await GetListAsync(new AdditionalFacilityQueryModel()
            {
                HotelId = room.HotelId
            });

            foreach (var item in orderModel.AdditionalFacilities)
            {
                cost += facilitiesCosts.FirstOrDefault(p => p.Id == item).Cost;
            }

            return orderModel.Cost == cost;
        }

    }
}
