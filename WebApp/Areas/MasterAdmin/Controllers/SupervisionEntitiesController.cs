using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data;
using Entities.SupervisionEntities;

namespace WebApp.Areas.MasterAdmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Area("MasterAdmin")]
    public class SupervisionEntitiesController : ControllerBase
    {
        private readonly PortalDbContext _context;

        public SupervisionEntitiesController(PortalDbContext context)
        {
            _context = context;
        }

        // GET: api/SupervisionEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupervisionEntity>>> GetSupervisions()
        {
            return await _context.Supervisions.ToListAsync();
        }

        // GET: api/SupervisionEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SupervisionEntity>> GetSupervisionEntity(int id)
        {
            var supervisionEntity = await _context.Supervisions.FindAsync(id);

            if (supervisionEntity == null)
            {
                return NotFound();
            }

            return supervisionEntity;
        }

        // PUT: api/SupervisionEntities/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupervisionEntity(int id, SupervisionEntity supervisionEntity)
        {
            if (id != supervisionEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(supervisionEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupervisionEntityExists(id))
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

        // POST: api/SupervisionEntities
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SupervisionEntity>> PostSupervisionEntity(SupervisionEntity supervisionEntity)
        {
            _context.Supervisions.Add(supervisionEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupervisionEntity", new { id = supervisionEntity.Id }, supervisionEntity);
        }

        // DELETE: api/SupervisionEntities/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SupervisionEntity>> DeleteSupervisionEntity(int id)
        {
            var supervisionEntity = await _context.Supervisions.FindAsync(id);
            if (supervisionEntity == null)
            {
                return NotFound();
            }

            _context.Supervisions.Remove(supervisionEntity);
            await _context.SaveChangesAsync();

            return supervisionEntity;
        }

        private bool SupervisionEntityExists(int id)
        {
            return _context.Supervisions.Any(e => e.Id == id);
        }
    }
}
