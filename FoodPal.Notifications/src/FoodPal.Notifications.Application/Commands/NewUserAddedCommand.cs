using MediatR;

namespace FoodPal.Notifications.Processor.Commands
{
    public class NewUserAddedCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
    }
}