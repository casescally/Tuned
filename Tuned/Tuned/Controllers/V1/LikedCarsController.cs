using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tuned.Data;
using Tuned.Models.Data;

namespace Tuned.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class LikedCarsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LikedCarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/LikedCars
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LikedCar>>> GetLikedCars()
        {
            return await _context.LikedCars.ToListAsync();
        }

        // GET: api/LikedCars/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LikedCar>> GetLikedCar(int id)
        {
            var likedCar = await _context.LikedCars.FindAsync(id);

            if (likedCar == null)
            {
                return NotFound();
            }

            return likedCar;
        }

        // PUT: api/LikedCars/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLikedCar(int id, LikedCar likedCar)
        {
            if (id != likedCar.Id)
            {
                return BadRequest();
            }

            _context.Entry(likedCar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LikedCarExists(id))
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

        // POST: api/LikedCars
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LikedCar>> PostLikedCar(LikedCar likedCar)
        {
            _context.LikedCars.Add(likedCar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLikedCar", new { id = likedCar.Id }, likedCar);
        }

        // DELETE: api/LikedCars/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LikedCar>> DeleteLikedCar(int id)
        {
            var likedCar = await _context.LikedCars.FindAsync(id);
            if (likedCar == null)
            {
                return NotFound();
            }

            _context.LikedCars.Remove(likedCar);
            await _context.SaveChangesAsync();

            return likedCar;
        }

        private bool LikedCarExists(int id)
        {
            return _context.LikedCars.Any(e => e.Id == id);
        }
    }
}
