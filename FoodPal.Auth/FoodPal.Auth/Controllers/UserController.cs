using FoodPal.Auth.Context;
using FoodPal.Auth.Dto;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FoodPal.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController: ControllerBase
    {
        private readonly UserManager<AppUser> userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserRequest request)
        {

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserRequest request)
        {
            var user = await userManager.FindByIdAsync(request.Username); 

            if(user != null && !await userManager.IsLockedOutAsync(user))
            {
                var isPasswordValid = await userManager.CheckPasswordAsync(user, request.Password);
                if(isPasswordValid)
                {
                    var userRoles = await userManager.GetRolesAsync(user);

                    var tokenHandler = new JwtSecurityTokenHandler();

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[]
                        {
                            new Claim(JwtClaimTypes.Id, user.Id),
                            new Claim(JwtClaimTypes.Email, user.Email),
                            new Claim(JwtClaimTypes.Role, string.Join(',', userRoles))
                        }),
                        Expires = DateTime.Now.AddDays(7),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("security_much_secure_very_wow_09")), SecurityAlgorithms.HmacSha256Signature)
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var jwt = tokenHandler.WriteToken(token);

                    return Ok(new { id_token = jwt });
                }
                else
                {
                    await userManager.AccessFailedAsync(user);
                    if(await userManager.GetLockoutEndDateAsync(user) != null)
                    {
                        await userManager.SetLockoutEnabledAsync(user, true);
                    }
                }
            }

            return Unauthorized();
        }
    }
}
