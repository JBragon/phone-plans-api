using JBragon.Models.infrastructure;

namespace JBragon.Models.Mapper.Response
{
    public class PhonePlanResponse : BaseEntity<int>
    {
        public int DDDId { get; set; }
        public int TelephoneOperatorId { get; set; }
        public int PhonePlanTypeId { get; set; }
        public decimal Minutes { get; set; }
        public decimal InternetFranchise { get; set; }
        public decimal PlanPrice { get; set; }
        public string Name { get; set; }

        public virtual DDDResponse DDD { get; set; }
        public virtual TelephoneOperatorResponse TelephoneOperator { get; set; }
        public virtual PhonePlanTypeResponse PhonePlanType { get; set; }
    }
}
