using FluentValidation;
using HMS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Validators
{
    public class AppointmentValidator : AbstractValidator<AppointmentsDTO>
    {
        public AppointmentValidator()
        {
            RuleFor(a => a.Number).NotEmpty().WithMessage("Please enter {PropertyName}! It can't be Empty or Null")
                .NotNull().WithMessage("Please enter {PropertyName}! It can't be Empty or Null");
            RuleFor(d => d.Type).NotNull().WithMessage("Please enter {PropertyName}! It can't be Null");
            RuleFor(d => d.Description).NotEmpty().WithMessage("Xahiş edirem  {PropertyName} alanı daxil ediniz");
        }
    }
}
