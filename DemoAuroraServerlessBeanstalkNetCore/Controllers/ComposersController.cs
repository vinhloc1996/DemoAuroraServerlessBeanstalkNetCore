using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DemoAuroraServerlessBeanstalkNetCore.DataModels;

namespace DemoAuroraServerlessBeanstalkNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComposersController : ControllerBase
    {
        private readonly AuroraContext _context;

        public ComposersController(AuroraContext context)
        {
            _context = context;
        }

        // GET: api/Composers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Composer>>> GetComposer()
        {
            return await _context.Composer.ToListAsync();
        }

        // GET: api/Composers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Composer>> GetComposer(int id)
        {
            var composer = await _context.Composer.FindAsync(id);

            if (composer == null)
            {
                return NotFound();
            }

            return composer;
        }

        // PUT: api/Composers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComposer(int id, Composer composer)
        {
            if (id != composer.Id)
            {
                return BadRequest();
            }

            _context.Entry(composer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComposerExists(id))
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

        // POST: api/Composers
        [HttpPost]
        public async Task<ActionResult<Composer>> PostComposer(Composer composer)
        {
            _context.Composer.Add(composer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComposer", new { id = composer.Id }, composer);
        }

        // DELETE: api/Composers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Composer>> DeleteComposer(int id)
        {
            var composer = await _context.Composer.FindAsync(id);
            if (composer == null)
            {
                return NotFound();
            }

            _context.Composer.Remove(composer);
            await _context.SaveChangesAsync();

            return composer;
        }

        private bool ComposerExists(int id)
        {
            return _context.Composer.Any(e => e.Id == id);
        }
    }
}
