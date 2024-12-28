using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class RegisterValidator : AbstractValidator<Register>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Name-Surname field cannot be left empty");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Email field cannot be left empty");
            RuleFor(x => x.UserPassword).NotEmpty().WithMessage("Password field cannot be left empty");
            RuleFor(x => x.UserName).MinimumLength(2).WithMessage("Please enter at least 2 characters");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("Please enter no more than 50 characters");
            RuleFor(p => p.UserMail).Matches(@"[@]+").WithMessage("Email address must contain '@'");
            RuleFor(p => p.UserMail).Matches(@"[.com]+").WithMessage("Email address must contain '.com'");
            RuleFor(p => p.UserPassword).Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter");
            RuleFor(p => p.UserPassword).Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter");
            RuleFor(p => p.UserPassword).Matches(@"[0-9]+").WithMessage("Password must contain at least one number");
        }
    }
}
