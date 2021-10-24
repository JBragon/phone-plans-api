using JBragon.MicroserviceHelper.Models;
using JBragon.Models.infrastructure;
using LinqKit;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace JBragon.Models.Filters
{
    public class TelephoneOperatorFilter : Filter
    {
        public string Name { get; set; }

        private Expression<Func<TelephoneOperator, bool>> filter = PredicateBuilder.New<TelephoneOperator>(true);
        private Func<IQueryable<TelephoneOperator>, IOrderedQueryable<TelephoneOperator>> order;

        public Expression<Func<TelephoneOperator, bool>> GetFilter()
        {
            if (!string.IsNullOrEmpty(Name))
                filter = filter.And(x => x.Name == Name);

            return filter;
        }

        public Func<IQueryable<TelephoneOperator>, IOrderedQueryable<TelephoneOperator>> GetOrder()
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


