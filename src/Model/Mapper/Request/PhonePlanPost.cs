using FluentValidation;

namespace JBragon.Models.Mapper.Request
{
    public class PhonePlanPost
    {
    }

    public class PhonePlanPostValidation : AbstractValidator<PhonePlanPost>
    {
        public PhonePlanPostValidation()
        {
            //RuleFor(v => v.NumeroPlacaVeiculo)
            //  .NotEmpty()
            //  .WithMessage(RuleMessage.Informed("{PropertyName}"));


            //RuleFor(v => v.NumeroPlacaVeiculo)
            //   .MaximumLength(7)
            //   .WithMessage(RuleMessage.MaxLength("{PropertyName}",7));
        }
    }
}
