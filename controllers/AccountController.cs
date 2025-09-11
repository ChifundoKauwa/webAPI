
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using api.Modules;
using api.Dto.Account;

namespace api.controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Appuser> _userManager;
        public AccountController(UserManager<Appuser> userManager)
        {
            _userManager = userManager;

        }

        public Appuser AppUser { get; private set; }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto register)
        { try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var appUser = new AppUser
                {
                    UserName = register.Username,
                    Email = register.Email


                };
                var createdUser = await _userManager.CreateAsync(appUser, register.Password);
                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok("user created");
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, e);

            }
            
        }

    }

    internal class AppUser : Appuser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}