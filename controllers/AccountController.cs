
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using api.Modules;
using api.Dto.Account;
using api.interfaces;

namespace api.controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Appuser> _userManager;
        private readonly ITokenService _tokenService;
        public AccountController(UserManager<Appuser> userManager,ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;

        }

        
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto register)
        { try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var appUser = new Appuser
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
                        return Ok(
                            new NewUserDto
                            {
                                UserName = appUser.UserName,
                                Email = appUser.Email,
                              Token = _tokenService.CreateToken(appUser)
                            }
                        );
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
}