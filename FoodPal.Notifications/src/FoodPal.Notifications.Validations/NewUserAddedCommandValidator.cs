using FluentValidation;
using FoodPal.Notifications.Processor.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodPal.Notifications.Validations
{
    public class NewUserAddedCommandValidator : InternalValidator<NewUserAddedCommand>
    {
        public NewUserAddedCommandValidator()
        {
            this.RuleFor(x => x.Email).NotEmpty();
            this.RuleFor(x => x.FirstName).NotEmpty();
            this.RuleFor(x => x.LastName).NotEmpty();
            this.RuleFor(x => x.PhoneNo).NotEmpty();
        }
    }
}