using FluentValidation;
using FoodPal.Notifications.Application.Commands;

namespace FoodPal.Notifications.Validations
{
    public class UserUpdatedCommandValidator : InternalValidator<UserUpdatedCommand>
    {
        public UserUpdatedCommandValidator()
        {
            this.RuleFor(x => x.Email).NotEmpty();
            this.RuleFor(x => x.FirstName).NotEmpty();
            this.RuleFor(x => x.LastName).NotEmpty();
            this.RuleFor(x => x.PhoneNo).NotEmpty();
        }
    }
}
