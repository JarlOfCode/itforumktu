using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ITForumV3.Models;

namespace ITForumV3.Controllers
{
    //[Route("api/Games/{GameId}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class ThreadsController : ControllerBase
    {
        private readonly ThreadContext _context;

        public ThreadsController(ThreadContext context)
        {
            _context = context;
        }

        // GET: api/Threads
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Thread>>> GetThreadItems()
        {
            return await _context.thread.ToListAsync();
        }

        // GET: api/Threads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Thread>> GetThread(long id)
        {
            var thread = await _context.thread.FindAsync(id);

            if (thread == null)
            {
                return NotFound();
            }

            return thread;
        }

        // GET: api/Threads/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Thread>> GetThreadPosts(long id)
        {
            var thread = await _context.thread.FindAsync(id);

            if (thread == null)
            {
                return NotFound();
            }

            return thread;
        }

        // PUT: api/Threads/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThread(long id, Thread thread)
        {
            if (id != thread.Id)
            {
                return BadRequest();
            }

            _context.Entry(thread).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThreadExists(id))
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

        // POST: api/Threads
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Thread>> PostThread(Thread thread)
        {
            _context.thread.Add(thread);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThread", new { id = thread.Id }, thread);
        }

        // DELETE: api/Threads/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Thread>> DeleteThread(long id)
        {
            var thread = await _context.thread.FindAsync(id);
            if (thread == null)
            {
                return NotFound();
            }

            _context.thread.Remove(thread);
            await _context.SaveChangesAsync();

            return thread;
        }

        private bool ThreadExists(long id)
        {
            return _context.thread.Any(e => e.Id == id);
        }
    }
}
