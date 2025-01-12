using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Description cannot be null!");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Please choose a picture");
            RuleFor(x => x.Description).MinimumLength(50).WithMessage("Please write name more than 50 characters");
            RuleFor(x => x.Description).MaximumLength(1000).WithMessage("Please write name less than 1000 characters");
        }
    }
}
