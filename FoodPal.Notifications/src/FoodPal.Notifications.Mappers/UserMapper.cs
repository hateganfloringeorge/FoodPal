using FoodPal.Contracts;
using FoodPal.Notifications.Application.Commands;
using FoodPal.Notifications.Domain;
using FoodPal.Notifications.Processor.Commands;

namespace FoodPal.Notifications.Mappers
{
    public class UserMapper : InternalProfile
    {
        public UserMapper()
        {
            this.CreateMap<INewUserAdded, NewUserAddedCommand>();
            this.CreateMap<NewUserAddedCommand, User>();

            this.CreateMap<IUserUpdated, UserUpdatedCommand>();
            this.CreateMap<UserUpdatedCommand, Notification>();
        }
    }
}