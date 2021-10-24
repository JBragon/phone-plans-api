using JBragon.Models.infrastructure;
using System;
using System.Linq.Expressions;


namespace JBragon.Models.Filters
{
    public class PhonePlanFilter : Filter
    {
        public Expression<Func<PhonePlan, bool>> GetFilter()
        {
            throw new NotImplementedException();
        }
    }
}


