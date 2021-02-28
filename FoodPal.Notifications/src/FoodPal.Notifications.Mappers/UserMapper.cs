using FoodPal.Contracts;
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
        }
    }
}