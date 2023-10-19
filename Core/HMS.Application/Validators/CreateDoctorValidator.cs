using FluentValidation;
using HMS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Validators
{
    public class CreateDoctorValidator:AbstractValidator<DoctorDTO>
    {
        public CreateDoctorValidator()
        {
            RuleFor(d => d.Email).EmailAddress().WithMessage("Please enter a valid email!");
        }
    }
}
