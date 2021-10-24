using JBragon.Models.Filters;
using JBragon.Models.Infrastructure;

namespace JBragon.Business.Interfaces
{
    public interface ITelephoneOperatorService : IBaseService<int>
    {
        SearchResponse<TOutputModel> Search<TOutputModel>(TelephoneOperatorFilter filter);
    }
}
