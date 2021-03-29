using FoodPal.Auth.Context;
using FoodPal.Auth.Dto;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly UserManager<AppUser> _userManager;

        public UserController(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userManager.Users.ToListAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserRequest request)
        {
            var newUser = new AppUser()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.Username,
                PasswordHash = request.Password,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Address = request.Address,
            };

            var result = await _userManager.CreateAsync(newUser, request.Password);
            if (result.Errors.Count() != 0)
                return BadRequest(result.Errors.ToArray());
            return Ok();
        }

        [HttpOptions]
        public IActionResult OptionsSettings()
        {
            return Ok("Merge bine");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username); 

            if(user != null && !await _userManager.IsLockedOutAsync(user))
            {
                var isPasswordValid = await _userManager.CheckPasswordAsync(user, request.Password);
                if(isPasswordValid)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);

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
                    await _userManager.AccessFailedAsync(user);
                    if(await _userManager.GetLockoutEndDateAsync(user) != null)
                    {
                        await _userManager.SetLockoutEnabledAsync(user, true);
                    }
                }
            }

            return Unauthorized();
        }
    }
}
