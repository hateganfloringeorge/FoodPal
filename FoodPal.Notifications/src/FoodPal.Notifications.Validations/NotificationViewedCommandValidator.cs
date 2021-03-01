using FluentValidation;
using FoodPal.Notifications.Application.Commands;

namespace FoodPal.Notifications.Validations
{
    public class NotificationViewedCommandValidator : InternalValidator<NotificationViewedCommand>
    {
        public NotificationViewedCommandValidator()
        {
            this.RuleFor(x => x.Id).NotEmpty();
            this.RuleFor(x => x.Status).NotEqual(Common.Enums.NotificationStatusEnum.Error);
        }
        
    }
}
