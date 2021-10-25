﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        public FacilityCostService(IMapper mapper, IFacilityCostRepository facilityCostRepository)
        {
            _mapper = mapper;
            _facilityCostRepository = facilityCostRepository;
        }

        private readonly IMapper _mapper;
        private readonly IFacilityCostRepository _facilityCostRepository;

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
    }
}