using JBragon.Models.infrastructure;
using System.Collections.Generic;

namespace JBragon.Models
{
    public class TelephoneOperator : BaseEntity<int>
    {
        public string Name { get; set; }

        public ICollection<PhonePlan> PhonePlans { get; set; }
    }
}
