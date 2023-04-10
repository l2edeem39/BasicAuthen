using APIAuthen.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIAuthen.Controllers
{
    [Route("GetAuthen")]
    [ApiController]
    public class UserAuthenController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserAuthenController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [Route("api/1.0/GetAuthen")]
        [HttpGet]
        public IActionResult Get()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Unauthorized();
            }

            string authHeader = Request.Headers["Authorization"];
            byte[] authBytes = Convert.FromBase64String(authHeader.Substring("Basic ".Length));
            string authString = Encoding.UTF8.GetString(authBytes);
            string[] authArray = authString.Split(':');
            string username = authArray[0];
            string password = authArray[1];

            if (_userRepository.ValidateCredentials(username, password))
            {
                return Ok("Authentication successful");
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
