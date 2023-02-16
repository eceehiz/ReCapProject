using Business.Constans;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.FluentValidation
{
    public class CarValidator : AbstractValidator <Car>
    {
        public CarValidator()
        {
            RuleFor(ca=> ca.Description).NotEmpty();
            RuleFor(ca => ca.Description).MinimumLength(2).WithMessage(Messages.CarNotAdded);
            RuleFor(ca => ca.DailyPrice).NotEmpty();
            RuleFor(ca => ca.DailyPrice).GreaterThan(0).WithMessage(Messages.CarNotAdded);
            RuleFor(ca => ca.DailyPrice).GreaterThanOrEqualTo(500).When(ca => ca.BrandId == 1);

        }
    }
}
