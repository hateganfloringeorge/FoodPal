using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPal.Deliveries.Messages
{
    public class UserUpdatedConsumer : IConsumer<UserUpdatedConsumer>
    {
        public async Task Consume(ConsumeContext<UserUpdatedConsumer> context)
        {
            var message = context.Message;
        }
    }
}
