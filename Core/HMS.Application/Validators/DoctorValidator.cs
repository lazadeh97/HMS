using FluentValidation;
using HMS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Validators
{
    public class DoctorValidator:AbstractValidator<DoctorDTO>
    {
        public DoctorValidator()
        {
            RuleFor(d => d.Name).NotNull().WithMessage("Please enter {PropertyName}! It can't be Empty or Null")
              .NotEmpty().WithMessage("Please enter {PropertyName}! It can't be Empty or Null");
            RuleFor(d => d.Email).EmailAddress().WithMessage("Please enter a valid email!");
            RuleFor(d => d.Username).NotNull().WithMessage("Please enter {PropertyName}! It can't be Null");
        }
    }
}
