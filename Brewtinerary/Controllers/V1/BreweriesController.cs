using Capstone.Data;
using Capstone.Models.Data;
using Capstone.Models.Data.GeoCoding;
using Capstone.Models.ViewModels;
using Capstone.Routes.V1;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Capstone.Controllers.V1
{
    [Authorize]
    [ApiController]
    public class BreweriesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private readonly IHttpClientFactory _clientFactory;
        public IConfiguration Configuration { get; }

        private string geocodeKey = null;

        public BreweriesController(ApplicationDbContext context, IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _context = context;
            _clientFactory = clientFactory;
            Configuration = configuration;
        }

        // GET: api/v1/Breweries
        [HttpGet(Api.Breweries.GetAll)]
        public async Task<ActionResult<List<Brewery>>> GetAll(string filterText)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"search?query={filterText}");
            var client = _clientFactory.CreateClient("openBreweryDb");
            var response = await client.SendAsync(request);

            string breweriesAsJSON = await response.Content.ReadAsStringAsync();

            var deserializedBreweries = JsonConvert.DeserializeObject<List<Brewery>>(breweriesAsJSON);


            return Ok(deserializedBreweries);
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
            geocodeKey = Configuration["Geocode:Key"];
            var brewery = new Brewery();
            if (bcvm.Latitude == null || bcvm.Longitude == null)
            {
                var geocodeRequest = new HttpRequestMessage(HttpMethod.Get, $"json?address={bcvm.Street.Replace(" ", "+")},{bcvm.City},{bcvm.State}&key={geocodeKey}");
                var geocodeClient = _clientFactory.CreateClient("Geocoding");

                var geocodeResponse = await geocodeClient.SendAsync(geocodeRequest);

                var geocodeAsString = await geocodeResponse.Content.ReadAsStringAsync();

                var deserializedGeoCoding = JsonConvert.DeserializeObject<GeocodeResult>(geocodeAsString);

                brewery.Name = bcvm.Name;
                brewery.Brewery_Type = bcvm.Brewery_Type;
                brewery.Street = bcvm.Street;
                brewery.City = bcvm.City;
                brewery.State = bcvm.State;
                brewery.Postal_Code = bcvm.Postal_Code;
                brewery.Longitude = deserializedGeoCoding.Results[0].Geometry.Location.Lng;
                brewery.Latitude = deserializedGeoCoding.Results[0].Geometry.Location.Lat;
                brewery.Phone = bcvm.Phone;
                brewery.Website_URL = bcvm.Website_URL;

                _context.Breweries.Add(brewery);
                //Save the brewery to the database
                await _context.SaveChangesAsync();

            }
            else
            {

                brewery.Name = bcvm.Name;
                brewery.Brewery_Type = bcvm.Brewery_Type;
                brewery.Street = bcvm.Street;
                brewery.City = bcvm.City;
                brewery.State = bcvm.State;
                brewery.Postal_Code = bcvm.Postal_Code;
                brewery.Longitude = bcvm.Longitude;
                brewery.Latitude = bcvm.Latitude;
                brewery.Phone = bcvm.Phone;
                brewery.Website_URL = bcvm.Website_URL;

                _context.Breweries.Add(brewery);
                //Save the brewery to the database
                await _context.SaveChangesAsync();
            }

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