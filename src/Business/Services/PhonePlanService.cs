using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using JBragon.Business.Interfaces;
using JBragon.Models;
using JBragon.DataAccess.Context;
using JBragon.Models.Filters;
using JBragon.Models.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace JBragon.Business.Services
{
    public class PhonePlanService : BaseService<PhonePlan, int>, IPhonePlanService
    {
        public PhonePlanService(IUnitOfWork<MainContext> unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }

        public SearchResponse<TOutputModel> Search<TOutputModel>(PhonePlanFilter filter)
        {
            var response = base.Search<TOutputModel>(
               filter.GetFilter(),
               include: source => source.Include(i => i.DDD)
                                        .Include(i => i.PhonePlanType)
                                        .Include(i => i.TelephoneOperator),
               orderBy: filter.GetOrder(),
               filter.Page,
               filter.RowsPerPage
            );

            return response;
        }

        public override TOutputModel GetById<TOutputModel>(int Id)
        {
            return base.GetById<TOutputModel>(Id,
                include: source => source.Include(i => i.DDD)
                                        .Include(i => i.PhonePlanType)
                                        .Include(i => i.TelephoneOperator));
        }
    }
}
