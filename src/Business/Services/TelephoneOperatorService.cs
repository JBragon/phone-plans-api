using Arch.EntityFrameworkCore.UnitOfWork;
using AutoMapper;
using JBragon.Business.Interfaces;
using JBragon.Models;
using JBragon.DataAccess.Context;
using JBragon.Models.Filters;
using JBragon.Models.Infrastructure;

namespace JBragon.Business.Services
{
    public class TelephoneOperatorService : BaseService<TelephoneOperator, int>, ITelephoneOperatorService
    {
        public TelephoneOperatorService(IUnitOfWork<MainContext> unitOfWork, IMapper mapper)
            : base(unitOfWork, mapper)
        {
        }

        public SearchResponse<TOutputModel> Search<TOutputModel>(TelephoneOperatorFilter filter)
        {
            var response = base.Search<TOutputModel>(
               filter.GetFilter(),
               include: null,
               orderBy: filter.GetOrder(),
               filter.Page,
               filter.RowsPerPage
            );

            return response;
        }
    }
}
