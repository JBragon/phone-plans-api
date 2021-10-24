using JBragon.Models.infrastructure;
using JBragon.Models.Mapper.Response;
using System.Collections.Generic;

namespace JBragon.Models
{
    public class TelephoneOperatorResponse : BaseEntity<int>
    {
        public string Name { get; set; }
    }
}
