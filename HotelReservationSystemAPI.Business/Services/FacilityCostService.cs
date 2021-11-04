using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HotelReservationSystemAPI.Business.Exceptions;
using HotelReservationSystemAPI.Business.Interfaces;
using HotelReservationSystemAPI.Business.Models;
using HotelReservationSystemAPI.Business.QueryModels;
using HotelReservationSystemAPI.Data.Interfaces;
using HotelReservationSystemAPI.Data.Models;
using HotelReservationSystemAPI.Data.Query;

namespace HotelReservationSystemAPI.Business.Services
{
    public class FacilityCostService : IFacilityCostService
    {
        public FacilityCostService(IMapper mapper, IFacilityCostRepository facilityCostRepository, IRoomRepository roomRepository)
        {
            _mapper = mapper;
            _facilityCostRepository = facilityCostRepository;
            _roomRepository = roomRepository;
        }

        private readonly IMapper _mapper;
        private readonly IFacilityCostRepository _facilityCostRepository;
        private readonly IRoomRepository _roomRepository;

        public async Task<AdditionalFacilityModel> CreateAsync(FacilityRequestCostModel facilityRequestModel)
        {
            var facilityCost = _mapper.Map<FacilityRequestCostModel, FacilityCostEntity>(facilityRequestModel);

            var entity = await _facilityCostRepository.CreateAsync(facilityCost);

            if (entity == null)
                throw new SomethingWrong("Something went wrong!\nAdditional facility is not created.");

            return _mapper.Map<FacilityCostEntity, AdditionalFacilityModel>(entity);
        }

        public async Task UpdateAsync(FacilityPatchRequestCostModel facilityPatchRequestCostModel)
        {
            var facilityCost = _mapper.Map<FacilityPatchRequestCostModel, FacilityCostEntity>(facilityPatchRequestCostModel);

            var entity = await _facilityCostRepository.UpdateAsync(facilityCost);

            if (entity == null)
                throw new BadRequest("Additional facility with this id doesn't exists.");
        }

        public async Task<IList<AdditionalFacilityModel>> GetListAsync(AdditionalFacilityQueryModel queryModel)
        {
            var queryParameters = GetQueryParameters(queryModel);

            var entities = await _facilityCostRepository.GetListAsync(queryParameters);

            return _mapper.Map<IList<FacilityCostEntity>, IList<AdditionalFacilityModel>>(entities);
        }

        private QueryParameters<FacilityCostEntity> GetQueryParameters(AdditionalFacilityQueryModel model)
        {
            if (model == null)
                throw new ArgumentNullException($"{nameof(model)}");

            var queryParameters = new QueryParameters<FacilityCostEntity>
            {
                FilterRule = GetFilterRule(model),
                PaginationRule = GetPageRule(model)
            };

            return queryParameters;
        }

        private FilterRule<FacilityCostEntity> GetFilterRule(AdditionalFacilityQueryModel model)
        {
            var filterRule = new FilterRule<FacilityCostEntity>
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
            if (orderModel.AdditionalFacilities == null) return true;

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
            var type = room.RoomType.RoomsCosts.FirstOrDefault(type => type.HotelId == room.HotelId);

            if (type == null)
                throw new SomethingWrong("This room doesn't exists.");

            cost += type.Cost;

            if (orderModel.AdditionalFacilities == null)
                return orderModel.Cost == cost;

            var facilitiesCosts = await GetListAsync(new AdditionalFacilityQueryModel()
            {
                HotelId = room.HotelId
            });

            cost += facilitiesCosts.Where(facil => orderModel.AdditionalFacilities.Contains(facil.Id)).Sum(facil => facil.Cost);

            return orderModel.Cost == cost;
        }
    }
}