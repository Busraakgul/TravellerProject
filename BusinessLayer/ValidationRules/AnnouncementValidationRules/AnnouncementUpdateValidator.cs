using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.AnnouncementValidationRules
{
    public class AnnouncementUpdateValidator : AbstractValidator<AnnouncementUpdateDTO>
    {
        public AnnouncementUpdateValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Please fill the title");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Please fill the content");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Please use at least 5 characters");
            RuleFor(x => x.Title).MaximumLength(50).WithMessage("Please use at maximum 300 characters");
            RuleFor(x => x.Content).MinimumLength(5).WithMessage("Please use at least 5 characters");
            RuleFor(x => x.Content).MaximumLength(300).WithMessage("Please use at maximum 300 characters");
        }
    }
}
