using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ARKADE_API0._001.Data;
using ARKADE_API0._001.Models;
using ArkadeBackendApi.Models;

namespace ARKADE_API0._001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AplicationDBContext _context;

        public UsersController(AplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfo>>> GetUSERSINFO()
        {
            return await _context.USERSINFO.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfo>> GetUserInfo(int id)
        {
            var userInfo = await _context.USERSINFO.FindAsync(id);

            if (userInfo == null)
            {
                return NotFound();
            }

            return userInfo;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInfo(int id, UserInfo userInfo)
        {
            if (id != userInfo.Id)
            {
                return BadRequest();
            }

            _context.Entry(userInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // PUT: api/Users/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("login/{nickName}")]
        public async Task<IActionResult> PutUserInfo(string nickName, UserLogin userLogin)
        {
            if (nickName != userLogin.NickName)
            {
                return BadRequest();
            }

            _context.Entry(userLogin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLoginExists(nickName))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // POST: api/Users
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserInfo>> PostUserInfo(UserInfo userInfo)
        {

            var login = new UserLogin
            {
                NickName = userInfo.NickName,
                Password = userInfo.NickName + "123"
            };
            _context.USERSINFO.Add(userInfo);
            _context.USERSLOGIN.Add(login);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInfo", new { id = userInfo.Id }, userInfo);
        }

     
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserInfo>> DeleteUserInfo(int id)
        {
            var userInfo = await _context.USERSINFO.FindAsync(id);
            var userLogin = await _context.USERSLOGIN.FindAsync(userInfo.NickName);
            if (userInfo == null)
            {
                return NotFound();
            }

            _context.USERSINFO.Remove(userInfo);
            _context.USERSLOGIN.Remove(userLogin);

            await _context.SaveChangesAsync();

            return userInfo;
        }

        private bool UserInfoExists(int id)
        {
            return _context.USERSINFO.Any(e => e.Id == id);
        }
        private bool UserLoginExists(string nickName)
        {
            return _context.USERSLOGIN.Any(e => e.NickName == nickName);
        }
    }
}
