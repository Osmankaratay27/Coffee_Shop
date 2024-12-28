using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class CoffeeMenuValidator:AbstractValidator<CoffeeMenu>
	{
        public CoffeeMenuValidator()
        {
			RuleFor(x => x.CoffeeMenuName).NotEmpty().WithMessage("Coffee Name field cannot be left empty");
			RuleFor(x => x.CoffeeMenuName).MinimumLength(2).WithMessage("Please enter at least 2 characters");
			RuleFor(x => x.CoffeeMenuName).MaximumLength(50).WithMessage("Please enter no more than 50 characters");	
			RuleFor(x => x.CoffeeMenuDescription).NotEmpty().WithMessage("Coffee Description field cannot be left empty");
			RuleFor(x => x.CoffeeMenuDescription).MinimumLength(2).WithMessage("Please enter at least 2 characters");
			RuleFor(x => x.CoffeeMenuDescription).MaximumLength(50).WithMessage("Please enter no more than 50 characters");
			RuleFor(x => x.CoffeeMenuPrice).NotEmpty().WithMessage("Coffee Price field cannot be left empty");
	
		
		}
    }
}
