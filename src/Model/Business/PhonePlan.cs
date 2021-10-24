using JBragon.Models.infrastructure;

namespace JBragon.Models
{
    public class PhonePlan : BaseEntity<int>
    {
	    public int DDDId { get; set; }
        public int TelephoneOperatorId { get; set; }
        public int PhonePlanTypeId { get; set; }
        public decimal Minutes { get; set; }
        public decimal InternetFranchise { get; set; }
        public decimal PlanPrice { get; set; }
        public string Name { get; set; }

        public virtual DDD DDD { get; set; }
        public virtual TelephoneOperator TelephoneOperator { get; set; }
        public virtual PhonePlanType PhonePlanType { get; set; }
    }
}
