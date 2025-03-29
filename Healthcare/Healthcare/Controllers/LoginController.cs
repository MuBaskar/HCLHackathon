using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Healthcare.Models;
using System.Security.Claims;
using System.Text;
using Service;
using System.Net.WebSockets;

namespace Healthcare.Controllers
{
    public class LoginController : Controller
    {
        IConfiguration configuration;
        public  ILoginService _loginService;
        public LoginController(IConfiguration configuration, ILoginService loginService)
        {
         
            _loginService = loginService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await _loginService.LoginAsync(model.Username, model.Password);
                if (!String.IsNullOrEmpty(token))
                {
                    return Ok(token);
                  
                }
                else
                {
                    return Unauthorized();
                }

            }
            else
            {
                return BadRequest();
            }
        }

    }
}
