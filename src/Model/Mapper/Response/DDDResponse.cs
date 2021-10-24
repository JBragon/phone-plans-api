using JBragon.Models.infrastructure;
using JBragon.Models.Mapper.Response;
using System.Collections.Generic;

namespace JBragon.Models
{
    public class DDDResponse : BaseEntity<int>
    {
        public string Region { get; set; }
        public string State { get; set; }
        public int DDDCode { get; set; }
    }
}
