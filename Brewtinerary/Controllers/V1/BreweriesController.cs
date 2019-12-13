using Capstone.Data;
using Capstone.Models.Data;
using Capstone.Models.ViewModels;
using Capstone.Routes.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using static Capstone.Routes.V1.Api;

namespace Capstone.Controllers.V1
{
    [Authorize]
    [ApiController]
    public class BreweriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IHttpClientFactory _clientFactory;

        public BreweriesController(ApplicationDbContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }

        // GET: api/v1/Breweries
        [HttpGet(Api.Breweries.GetAll)]
        public async Task<string> GetAll(string filterText)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"search?query={filterText}");
            var client = _clientFactory.CreateClient("openBreweryDb");

            var response = await client.SendAsync(request);

            string breweriesAsJSON = await response.Content.ReadAsStringAsync();
            //var breweries = await JsonSerializer.DeserializeAsync
            //        <IEnumerable<Brewery>>(responseStream);
            return breweriesAsJSON;
        }

        // GET: api/v1/Breweries/5
        [HttpGet(Api.Breweries.Get)]
        public async Task<ActionResult<Brewery>> Get(int id)
        {
            var brewery = await _context.Breweries.FindAsync(id);

            if (brewery == null)
            {
                return NotFound();
            }

            return brewery;
        }

        [HttpPost(Api.Breweries.Post)]
        public async Task<IActionResult> AddBrewery([FromRoute]int itineraryId, [FromBody] BreweryCreateViewModel bcvm)
        {
            var brewery = new Brewery()
            {
                Name = bcvm.Name,
                Brewery_Type = bcvm.Brewery_Type,
                Street = bcvm.Street,
                City = bcvm.City,
                State = bcvm.State,
                Postal_Code = bcvm.Postal_Code,
                Longitude = bcvm.Longitude,
                Latitude = bcvm.Latitude,
                Phone = bcvm.Phone,
                Website_URL =bcvm.Website_URL
            };

            _context.Breweries.Add(brewery);
            //Save the brewery to the database
            await _context.SaveChangesAsync();

            //Get the newly created brewery back from the DB
            var recentlyCreatedBrewery = _context.Breweries.FirstOrDefault(b => b.Name == brewery.Name);

            var itineraryBrewery = new ItineraryBrewery()
            {
                ItineraryId = itineraryId,
                BreweryId = recentlyCreatedBrewery.Id
            };

            _context.ItineraryBreweries.Add(itineraryBrewery);
            await _context.SaveChangesAsync();

            return Ok(recentlyCreatedBrewery);
        }
    }
}