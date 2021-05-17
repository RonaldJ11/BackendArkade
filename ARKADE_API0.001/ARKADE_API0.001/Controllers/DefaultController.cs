using ARKADE_API0._001.Authenticator;
using ARKADE_API0._001.Data;
using ARKADE_API0._001.Models;
using ArkadeBackendApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArkadeBackendApi.Controllers
{

    [Authorize]
    [Route("api")]
    [ApiController]
    public class DefaultController : Controller
    {

        private readonly AplicationDBContext _context;
        private readonly ILogger<DefaultController> _logger;
        private readonly IJwtAuthenticationService _authService;


        public DefaultController(ILogger<DefaultController> logger, IJwtAuthenticationService authService, AplicationDBContext context)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authService = authService;
            _context = context;
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

            var userDB = Autenticate(user.NickName, user.Password).Result;
            if (userDB == null)
            {
                return Unauthorized();
            }
            var token = _authService.Authenticate(user.NickName, user.Password);

            return Ok(new { Token= token});
        }

        public async Task<UserLogin> Autenticate(string nickName, string password)
        {
            var users = await _context.USERSLOGIN.FindAsync(nickName);

            if (users == null || users.Password != password)
            {
                return null;
            }
            return users;
        }
    }   
}
