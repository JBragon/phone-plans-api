using JBragon.Models.infrastructure;
using System.Collections.Generic;

namespace JBragon.Models
{
    public class DDD : BaseEntity<int>
    {
        public string Region { get; set; }
        public string State { get; set; }
        public int DDDCode { get; set; }

        public ICollection<PhonePlan> PhonePlans { get; set; }
    }
}
