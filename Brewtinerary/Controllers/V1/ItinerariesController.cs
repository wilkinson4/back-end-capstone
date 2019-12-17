using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capstone.Data;
using Capstone.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Capstone.Routes.V1;
using Capstone.Helpers;
using Capstone.Models.ViewModels;
using System;

namespace Capstone.Controllers.V1
{
    //[Authorize]
    [ApiController]
    public class ItinerariesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ItinerariesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/v1/Itineraries
        [HttpGet(Api.Itineraries.GetAll)]
        public async Task<ActionResult<IEnumerable<Itinerary>>> GetAll()
        {
            var userId = HttpContext.GetUserId();
            return await _context.Itineraries
                                 .OrderBy(i => i.DateOfEvent)
                                 .Where(i => i.UserId == userId)
                                 .ToListAsync();
        }

        // GET: api/v1/Itineraries/5
        [HttpGet(Api.Itineraries.Get)]
        public async Task<ActionResult<Itinerary>> Get(int id)
        {
            var itineraryFromDB = await _context.Itineraries
                                           .Include(i => i.ItineraryBreweries)
                                           .ThenInclude(ib => ib.Brewery)
                                           .FirstOrDefaultAsync(i => i.Id == id);

            if (itineraryFromDB == null)
            {
                return NotFound();
            }

            var itineraryWithoutCycleReference = new Itinerary()
            {
                Id = itineraryFromDB.Id,
                Name = itineraryFromDB.Name,
                DateOfEvent = itineraryFromDB.DateOfEvent,
                City = itineraryFromDB.City,
                State = itineraryFromDB.State,
                ItineraryBreweryViewModels = itineraryFromDB.ItineraryBreweries.Select(ib => new ItineraryBreweryViewModel()
                {
                    Id = ib.Id,
                    BreweryId = ib.BreweryId,
                    ItineraryId = ib.ItineraryId,
                    Brewery = ib.Brewery
                }).ToList()
            };



            return Ok(itineraryWithoutCycleReference);
        }

        // PUT: api/Itineraries/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut(Api.Itineraries.Edit)]
        public async Task<IActionResult> PutItinerary(int id, ItineraryEditViewModel ievm)
        {
            if (id != ievm.Id)
            {
                return BadRequest();
            }

            var userId = HttpContext.GetUserId();

            ievm.UserId = userId;

            _context.Entry(ievm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ItineraryExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw ex;
                }
            }

            return NoContent();
        }

        //// POST: api/Itineraries
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPost]
        //public async Task<ActionResult<Itinerary>> PostItinerary(Itinerary itinerary)
        //{
        //    _context.Itineraries.Add(itinerary);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetItinerary", new { id = itinerary.Id }, itinerary);
        //}

        // DELETE: api/Itineraries/5
        [HttpDelete(Api.Itineraries.Delete)]
        public async Task<ActionResult<Itinerary>> DeleteItinerary(int id)
        {
            var itinerary = await _context.Itineraries
                                           .Include(i => i.ItineraryBreweries)
                                           .ThenInclude(ib => ib.Brewery)
                                           .FirstOrDefaultAsync(i => i.Id == id);
            if (itinerary == null)
            {
                return NotFound();
            }

            foreach (ItineraryBrewery ib in itinerary.ItineraryBreweries)
            {
                _context.Remove(ib);
                _context.Remove(ib.Brewery);
            }
            await _context.SaveChangesAsync();

            _context.Itineraries.Remove(itinerary);
            await _context.SaveChangesAsync();

            return itinerary;
        }

        private bool ItineraryExists(int id)
        {
            return _context.Itineraries.Any(e => e.Id == id);
        }
    }
}
