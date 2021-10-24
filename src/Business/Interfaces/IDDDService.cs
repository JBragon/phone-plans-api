using JBragon.Models.Filters;
using JBragon.Models.Infrastructure;

namespace JBragon.Business.Interfaces
{
    public interface IDDDService : IBaseService<int>
    {
        SearchResponse<TOutputModel> Search<TOutputModel>(DDDFilter filter);
    }
}
