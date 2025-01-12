using DTOLayer.DTOs.ContactDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules.ContactUs
{
    public class SendContactUsValidator : AbstractValidator<SendMessageDTO>
    {
        public SendContactUsValidator()
        {
            RuleFor(X => X.Mail).NotEmpty().WithMessage("Mail field cannot be empty!");
            RuleFor(X => X.Subject).NotEmpty().WithMessage("Subject field cannot be empty!");
            RuleFor(X => X.Name).NotEmpty().WithMessage("Name field cannot be empty!");
            RuleFor(X => X.MessageBody).NotEmpty().WithMessage("Message body field cannot be empty!");
            RuleFor(X => X.Subject).MinimumLength(5).WithMessage("Subject field should include at least 5 characters!");
            RuleFor(X => X.Subject).MaximumLength(100).WithMessage("Subject field should include maximum 100 characters!");

            RuleFor(X => X.Mail).MinimumLength(5).WithMessage("Mail field should include at least 5 characters!");
            RuleFor(X => X.Mail).MaximumLength(100).WithMessage("Mail field should include maximum 100 characters!");
        }
    }
}
