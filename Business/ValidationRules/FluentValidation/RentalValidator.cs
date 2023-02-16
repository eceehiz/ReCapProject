using Business.Constans;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(re => re.ReturnDate).NotEmpty().WithMessage(Messages.RentalError);
        }
    }
}
