using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTOs>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be null!");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Surname cannot be null!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail cannot be null!");
            RuleFor(x => x.Username).NotEmpty().WithMessage("Usrrname cannot be null!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password cannot be null!");
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("ConfirmPassword cannot be null!");

            RuleFor(x => x.Username).MaximumLength(20).WithMessage("Please write a username less than 20 characters");
            RuleFor(x => x.Username).MinimumLength(5).WithMessage("Please write a username more than 5 characters");

            RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Passwords are not compatible with each other");

        }
    }
}
