using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationapii.Models;

namespace WebApplicationapii.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginController : ControllerBase
    {
        private IConfiguration _config;

        public loginController(IConfiguration configuration)
        {
            _config = configuration;
        }

      //  private users authenticate(users user)
       // {
          //  if (user == "admin")
       // }
    }
}
