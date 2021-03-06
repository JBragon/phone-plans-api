using JBragon.MicroserviceHelper.Models;
using JBragon.Models.infrastructure;
using LinqKit;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace JBragon.Models.Filters
{
    public class PhonePlanFilter : Filter
    {
        public string PhonePlanType { get; set; }
        public string TelephoneOperator { get; set; }
        public string Name { get; set; }
        public int DDDCode { get; set; }

        private Expression<Func<PhonePlan, bool>> filter = PredicateBuilder.New<PhonePlan>(true);
        private Func<IQueryable<PhonePlan>, IOrderedQueryable<PhonePlan>> order;

        public Expression<Func<PhonePlan, bool>> GetFilter()
        {
            filter = filter.And(x => x.DDD.DDDCode == DDDCode);

            if (!string.IsNullOrEmpty(PhonePlanType))
                filter = filter.And(x => x.PhonePlanType.Description == PhonePlanType);

            if (!string.IsNullOrEmpty(TelephoneOperator))
                filter = filter.And(x => x.TelephoneOperator.Name == TelephoneOperator);

            if (!string.IsNullOrEmpty(Name))
                filter = filter.And(x => x.Name == Name);

            return filter;
        }

        public Func<IQueryable<PhonePlan>, IOrderedQueryable<PhonePlan>> GetOrder()
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


