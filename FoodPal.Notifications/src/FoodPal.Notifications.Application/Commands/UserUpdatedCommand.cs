using MediatR;

namespace FoodPal.Notifications.Application.Commands
{
    public class UserUpdatedCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
    }
}
