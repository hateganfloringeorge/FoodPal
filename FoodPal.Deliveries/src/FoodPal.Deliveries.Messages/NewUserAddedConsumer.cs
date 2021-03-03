using FoodPal.Contracts;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPal.Deliveries.Messages
{
    public class NewUserAddedConsumer : IConsumer<INewUserAdded>
    {
        public async Task Consume(ConsumeContext<INewUserAdded> context)
        {
            var message = context.Message;
        }
    }
}
