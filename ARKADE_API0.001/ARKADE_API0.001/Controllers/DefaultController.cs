using ARKADE_API0._001.Authenticator;
using ARKADE_API0._001.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ARKADE_API0._001.Controllers
{

    [Authorize]
    [Route("api")]
    [ApiController]
    public class DefaultController : Controller
    {

        private readonly ILogger<DefaultController> _logger;
        private readonly IJwtAuthenticationService _authService;


        public DefaultController(ILogger<DefaultController> logger, IJwtAuthenticationService authService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authService = authService;
        }


        //api/
        [AllowAnonymous]
        [HttpGet]
        public object Get()
        {
            var responseObject = new { Status = "Running" };
            _logger.LogInformation($"Status: {responseObject.Status}");

            return responseObject;
        }


        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Authenticate([FromBody] UserLogin user)
        {
            var token = _authService.Authenticate(user.NickName, user.Password);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
      
    }
}
