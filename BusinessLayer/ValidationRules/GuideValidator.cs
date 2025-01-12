using EntityLayer.Concrete;
using FluentValidation;


namespace BusinessLayer.ValidationRules
{
    public class GuideValidator : AbstractValidator<Guide>
    {
        public GuideValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Please write guide name:");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Please write guide description:");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Please put guide image:");
            RuleFor(x => x.Name).MinimumLength(8).WithMessage("Please write name more than 8 characters");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Please write name less than 30 characters");

        }
    }
}
