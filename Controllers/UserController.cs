using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task1.Models;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LoginSystemContext _context;

        public UserController(LoginSystemContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetParties()
        {
            var partyData = await _context.Users.ToListAsync();
            
            return partyData;
        }

        // GET: api/Parties/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetParties(int id)
        {
            var parties = await _context.Users.FindAsync(id);

            if (parties == null)
            {
                return NotFound();
            }

            return parties;
        }

        // PUT: api/Parties/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutParties(int id, User users)
        {
            if (id != users.UserId)
            {
                return BadRequest();
            }
           
            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartiesExists(id))
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

        // POST: api/Parties  
        [HttpPost]
        public async Task<ActionResult<User>> PostParties(User user)
        {
           
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetParties", new { id = user.UserId }, user);
        }

        // DELETE: api/Parties/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteParties(int id)
        {
            var parties = await _context.Users.FindAsync(id);
            if (parties == null)
            {
                return NotFound();
            }

            _context.Users.Remove(parties);
            await _context.SaveChangesAsync();

            return parties;
        }

        private bool PartiesExists(int id)
        {
            return _context.Users.Any(e => e.UserId == id);
        }
       
    }
}

