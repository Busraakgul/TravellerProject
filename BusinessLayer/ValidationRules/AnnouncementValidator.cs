using DTOLayer.DTOs.AnnouncementDTOs;
using FluentValidation;


namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementAddDTO>
    {
        public AnnouncementValidator()
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
