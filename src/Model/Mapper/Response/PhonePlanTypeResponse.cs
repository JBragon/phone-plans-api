using JBragon.Models.infrastructure;
using JBragon.Models.Mapper.Response;
using System.Collections.Generic;

namespace JBragon.Models
{
    public class PhonePlanTypeResponse : BaseEntity<int>
    {
        public string Description { get; set; }
    }
}
