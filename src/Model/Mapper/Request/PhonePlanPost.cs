﻿using FluentValidation;
using JBragon.Models.Infrastructure;

namespace JBragon.Models.Mapper.Request
{
    public class PhonePlanPost
    {
        public int DDDId { get; set; }
        public int TelephoneOperatorId { get; set; }
        public int PhonePlanTypeId { get; set; }
        public decimal Minutes { get; set; }
        public decimal InternetFranchise { get; set; }
        public decimal PlanPrice { get; set; }
        public string Name { get; set; }
    }

    public class PhonePlanPostValidation : AbstractValidator<PhonePlanPost>
    {
        public PhonePlanPostValidation()
        {
            RuleFor(v => v.DDDId)
              .NotEmpty()
              .WithMessage(RuleMessage.Informed("{PropertyName}"));

            RuleFor(v => v.TelephoneOperatorId)
             .NotEmpty()
             .WithMessage(RuleMessage.Informed("{PropertyName}"));

            RuleFor(v => v.PhonePlanTypeId)
             .NotEmpty()
             .WithMessage(RuleMessage.Informed("{PropertyName}"));

            RuleFor(v => v.Minutes)
             .NotEmpty()
             .WithMessage(RuleMessage.Informed("{PropertyName}"));
            
            RuleFor(v => v.InternetFranchise)
             .NotEmpty()
             .WithMessage(RuleMessage.Informed("{PropertyName}"));
            
            RuleFor(v => v.PlanPrice)
             .NotEmpty()
             .WithMessage(RuleMessage.Informed("{PropertyName}"));
            
            RuleFor(v => v.Name)
             .NotEmpty()
             .WithMessage(RuleMessage.Informed("{PropertyName}"));
        }
    }
}
