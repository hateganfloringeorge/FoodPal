using FoodPal.Contracts;
using FoodPal.Notifications.Dto;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace FoodPal.Notifications.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public UserController(ILogger<UserController> logger, IPublishEndpoint publishEndpoint)
        {
            this._logger = logger;
            this._publishEndpoint = publishEndpoint;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserDto userDto)
        {
            await this._publishEndpoint.Publish<INewUserAdded>(userDto);

            return Accepted();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UserDto userDto)
        {
            await this._publishEndpoint.Publish<IUserUpdated>(userDto);

            return Accepted();
        }
    }
}