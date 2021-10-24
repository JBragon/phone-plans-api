using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using JBragon.Business.Interfaces;
using System;
using JBragon.Models.Mapper.Request;
using JBragon.Models;
using JBragon.DataAccess.Context;
using JBragon.Models.Filters;
using JBragon.Models.Infrastructure;

namespace JBragon.Business.Services
{
    public class PhonePlanService : BaseService<PhonePlan, int>, IPhonePlanService
    {
        public PhonePlanService(IUnitOfWork<MainContext> unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }

        public PhonePlanPost Create(PhonePlanPost inputModel)
        {
            throw new NotImplementedException();
        }

        public void Update(PhonePlanPost vehicle)
        {
            throw new NotImplementedException();
        }

        public SearchResponse<TOutputModel> Search<TOutputModel>(PhonePlanFilter phonePlanFilter)
        {
            var response = base.Search<TOutputModel>(
                filter: phonePlanFilter.GetFilter(),
                orderBy: phonePlanFilter.GetOrder<PhonePlan>(),
                pageIndex: phonePlanFilter.Page,
                pageSize: phonePlanFilter.RowsPerPage                
                );

            return response;
        }
    }
}
