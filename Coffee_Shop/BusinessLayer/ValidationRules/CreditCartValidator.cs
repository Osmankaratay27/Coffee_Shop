using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CreditCartValidator:AbstractValidator<CreditCart>
    {
        public CreditCartValidator()
        {
            RuleFor(x => x.CartName).NotEmpty().WithMessage("Cart Name field cannot be left empty");
            RuleFor(x => x.CartName).MinimumLength(2).WithMessage("Please enter at least 2 characters");
            RuleFor(x => x.CartName).MaximumLength(50).WithMessage("Please enter no more than 50 characters");
            RuleFor(x => x.CartNumber).MinimumLength(16).WithMessage("Please enter 16 characters");
            RuleFor(x => x.CartNumber).MaximumLength(16).WithMessage("Please enter 16 characters");
            RuleFor(x => x.CVV).InclusiveBetween(100, 999).WithMessage("CVV must be a 3-digit number");
            RuleFor(p => p.Month).NotEmpty().WithMessage("Month field cannot be left empty");
            RuleFor(p => p.Year).NotEmpty().WithMessage("Year field cannot be left empty");
          
        }
    }
}
