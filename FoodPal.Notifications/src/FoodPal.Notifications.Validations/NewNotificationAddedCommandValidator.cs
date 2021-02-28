using FluentValidation;
using FoodPal.Notifications.Processor.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodPal.Notifications.Validations
{
    public class NewNotificationAddedCommandValidator : InternalValidator<NewNotificationAddedCommand>
    {
        public NewNotificationAddedCommandValidator()
        {
            this.RuleFor(x => x.Message).NotEmpty();
            this.RuleFor(x => x.Title).NotEmpty();
        }
    }
}