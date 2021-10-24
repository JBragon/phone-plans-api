using JBragon.Models.infrastructure;
using System.Collections.Generic;

namespace JBragon.Models
{
    public class PhonePlanType : BaseEntity<int>
    {
        public string Description { get; set; }

        public ICollection<PhonePlan> PhonePlans { get; set; }
    }
}
