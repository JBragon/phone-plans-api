using JBragon.MicroserviceHelper.Models;
using JBragon.Models.infrastructure;
using LinqKit;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace JBragon.Models.Filters
{
    public class PhonePlanTypeFilter : Filter
    {
        public string Description { get; set; }

        private Expression<Func<PhonePlanType, bool>> filter = PredicateBuilder.New<PhonePlanType>(true);
        private Func<IQueryable<PhonePlanType>, IOrderedQueryable<PhonePlanType>> order;

        public Expression<Func<PhonePlanType, bool>> GetFilter()
        {
            if (!string.IsNullOrEmpty(Description))
                filter = filter.And(x => x.Description == Description);

            return filter;
        }

        public Func<IQueryable<PhonePlanType>, IOrderedQueryable<PhonePlanType>> GetOrder()
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


