using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplicationapii.DTO;
using WebApplicationapii.Models;

namespace WebApplicationapii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class accountController : ControllerBase
    {
        public readonly UserManager<applicationUser> userManager;
        public accountController(UserManager<applicationUser>userManager)
        {
            this.userManager = userManager;
        }

        // create new user
        [HttpPost("Register")]
        public async Task<IActionResult> Registration(RgisterUserDTO rgisterUserDTO)
        {
            if (ModelState.IsValid)
            {
               // save
               applicationUser user= new applicationUser();
                user.UserName=rgisterUserDTO.UserName;
                user.Email=rgisterUserDTO.Email;
            IdentityResult result= await  userManager.CreateAsync(user,rgisterUserDTO.Password);
                if (result.Succeeded)
                {
                    return Ok (result);
                }
                return BadRequest("userName or password is wrong");
            }
            return BadRequest();

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(loginUserDTO UserDTO)
        {
            if(ModelState.IsValid)
            {
                applicationUser user= await userManager.FindByNameAsync(UserDTO.UserName);
                if(user!=null)
                {
                   bool found = await userManager.CheckPasswordAsync (user, UserDTO.Password);
                    if (found)
                    {
                        // claims 
                        var claims = new List<Claim>();
                        claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                        claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                        claims.Add(new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()));

                        // get roles
                        var roles = await userManager.GetRolesAsync (user);
                        foreach (var itemRoles in roles)
                        {
                            claims.Add(new Claim (ClaimTypes.Role,itemRoles));
                        }
                        // create token
                        JwtSecurityToken token = new JwtSecurityToken(

                            issuer:"http://localhost:16123/",
                            audience : "http://localhost:4200/",
                            claims:claims




                            );

                    }
                }
            }
            return Unauthorized();
        }

    }
}
