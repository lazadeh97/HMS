﻿using FluentValidation;
using HMS.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Application.Validators
{
    public class CreateAppointmentValidator : AbstractValidator<AppointmentsDTO>
    {
        public CreateAppointmentValidator()
        {
            RuleFor(a => a.Number).NotEmpty().NotNull().WithMessage("Please enter number! It can't be Empty or Null");
        }
    }
}
