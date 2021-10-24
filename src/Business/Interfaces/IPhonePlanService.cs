using JBragon.Models.Filters;
using JBragon.Models.Infrastructure;

namespace JBragon.Business.Interfaces
{
    public interface IPhonePlanService : IBaseService<int>
    {
        SearchResponse<TOutputModel> Search<TOutputModel>(PhonePlanFilter filter);
    }
}
