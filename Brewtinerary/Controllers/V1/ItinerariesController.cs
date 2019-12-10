﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Capstone.Data;
using Capstone.Models.Data;
using Microsoft.AspNetCore.Authorization;
using Capstone.Routes.V1;
using Capstone.Helpers;

namespace Capstone.Controllers.V1
{
    [Authorize]
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
            return await _context.Itineraries.Where(i => i.UserId == userId).ToListAsync();
        }

        // GET: api/v1/Itineraries/5
        [HttpGet(Api.Itineraries.Get)]
        public async Task<ActionResult<Itinerary>> Get(int id)
        {
            var itinerary = await _context.Itineraries.FindAsync(id);

            if (itinerary == null)
            {
                return NotFound();
            }

            return itinerary;
        }

        //// PUT: api/Itineraries/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        //// more details see https://aka.ms/RazorPagesCRUD.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutItinerary(int id, Itinerary itinerary)
        //{
        //    if (id != itinerary.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(itinerary).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ItineraryExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

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

        //// DELETE: api/Itineraries/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Itinerary>> DeleteItinerary(int id)
        //{
        //    var itinerary = await _context.Itineraries.FindAsync(id);
        //    if (itinerary == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Itineraries.Remove(itinerary);
        //    await _context.SaveChangesAsync();

        //    return itinerary;
        //}

        //private bool ItineraryExists(int id)
        //{
        //    return _context.Itineraries.Any(e => e.Id == id);
        //}
    }
}
