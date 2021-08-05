using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API.Models;

namespace Web_API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserMasterController : ControllerBase
    {
        private readonly UserContext _context;

        public UserMasterController(UserContext context)
        {
            _context = context;
        }

        // GET: api/UserMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserMaster>>> Gettb_UserMaster()
        {
            return await _context.tb_UserMaster.ToListAsync();
        }

        // GET: api/UserMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserMaster>> GetUserMaster(int id)
        {
            var userMaster = await _context.tb_UserMaster.FindAsync(id);

            if (userMaster == null)
            {
                return NotFound();
            }

            return userMaster;
        }

        // PUT: api/UserMasters/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserMaster(int id, UserMaster userMaster)
        {
            if (id != userMaster.n_UserID)
            {
                return BadRequest();
            }

            _context.Entry(userMaster).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserMasterExists(id))
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

        // POST: api/UserMasters
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UserMaster>> PostUserMaster(UserMaster userMaster)
        {
            _context.tb_UserMaster.Add(userMaster);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserMaster", new { id = userMaster.n_UserID }, userMaster);
        }

        // DELETE: api/UserMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserMaster>> DeleteUserMaster(int id)
        {
            var userMaster = await _context.tb_UserMaster.FindAsync(id);
            if (userMaster == null)
            {
                return NotFound();
            }

            _context.tb_UserMaster.Remove(userMaster);
            await _context.SaveChangesAsync();

            return userMaster;
        }

        private bool UserMasterExists(int id)
        {
            return _context.tb_UserMaster.Any(e => e.n_UserID == id);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<UserMaster>> AuthenticateUser(UserMaster userLogin)
        {
            var user = await _context.tb_UserMaster.FirstOrDefaultAsync
                 (x => x.s_Email.ToUpper() == userLogin.s_Email.ToUpper()
                 && x.s_Password.ToUpper() == userLogin.s_Password.ToUpper()

                );
            return user;
        }

        //[HttpGet("{sEmail}/{sPass}")]
        //public async Task<ActionResult<UserMaster>> AuthenticateUser(string sEmail, string sPass)
        //{
        //    var user = await _context.tb_UserMaster.FirstOrDefaultAsync
        //         (x => x.s_Email.ToUpper() == sEmail.ToUpper()
        //         && x.s_Password.ToUpper() == sPass.ToUpper()

        //        );
        //    return user;
        //}
    }

}
