using JBragon.Models.Filters;
using JBragon.Models.Infrastructure;

namespace JBragon.Business.Interfaces
{
    public interface IPhonePlanTypeService : IBaseService<int>
    {
        SearchResponse<TOutputModel> Search<TOutputModel>(PhonePlanTypeFilter filter);
    }
}
