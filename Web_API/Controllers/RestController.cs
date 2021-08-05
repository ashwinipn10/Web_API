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
    [Route("api/rest")]
    [ApiController]
    public class RestController : ControllerBase
    {
        private readonly UserContext _context;

        public RestController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Rest
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestDetails>>> Gettb_RestDetails()
        {
            return await _context.tb_RestDetails.ToListAsync();
        }

        // GET: api/Rest/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RestDetails>> GetRestDetails(int id)
        {
            var restDetails = await _context.tb_RestDetails.FindAsync(id);

            if (restDetails == null)
            {
                return NotFound();
            }

            return restDetails;
        }

        // PUT: api/Rest/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestDetails(int id, RestDetails restDetails)
        {
            if (id != restDetails.n_RestID)
            {
                return BadRequest();
            }

            _context.Entry(restDetails).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestDetailsExists(id))
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

        // POST: api/Rest
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RestDetails>> PostRestDetails(RestDetails restDetails)
        {
            _context.tb_RestDetails.Add(restDetails);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestDetails", new { id = restDetails.n_RestID }, restDetails);
        }

        // DELETE: api/Rest/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<RestDetails>> DeleteRestDetails(int id)
        {
            var restDetails = await _context.tb_RestDetails.FindAsync(id);
            if (restDetails == null)
            {
                return NotFound();
            }

            _context.tb_RestDetails.Remove(restDetails);
            await _context.SaveChangesAsync();

            return restDetails;
        }

        private bool RestDetailsExists(int id)
        {
            return _context.tb_RestDetails.Any(e => e.n_RestID == id);
        }
    }
}
