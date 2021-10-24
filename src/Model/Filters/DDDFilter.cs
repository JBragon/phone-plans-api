using JBragon.MicroserviceHelper.Models;
using JBragon.Models.infrastructure;
using LinqKit;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace JBragon.Models.Filters
{
    public class DDDFilter : Filter
    {
        public int? DDDCode { get; set; }

        private Expression<Func<DDD, bool>> filter = PredicateBuilder.New<DDD>(true);
        private Func<IQueryable<DDD>, IOrderedQueryable<DDD>> order;

        public Expression<Func<DDD, bool>> GetFilter()
        {
            if (DDDCode.HasValue)
                filter = filter.And(x => x.DDDCode == DDDCode);

            return filter;
        }

        public Func<IQueryable<DDD>, IOrderedQueryable<DDD>> GetOrder()
        {
            if (!string.IsNullOrEmpty(Sort))
            {
                var sort = string.Concat(Sort, ":", SortDir).Split(',');

                foreach (var property in sort)
                {
                    //Verificar se existe o separador ':'
                    var field = property.Split(':');

                    //Verificar se o atributo existe  
                    order = source => source.OrderByProperty(field[0], field[1].ToUpper() == "ASC");
                }
            }
            return order;
        }
    }
}


