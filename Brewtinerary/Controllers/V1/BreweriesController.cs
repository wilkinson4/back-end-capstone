﻿using Capstone.Data;
using Capstone.Models.Data;
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
using static Capstone.Routes.V1.Api;

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
            if (bcvm.Latitude == null || bcvm.Longitude == null)
            {
                var geocodeRequest = new HttpRequestMessage(HttpMethod.Get, $"json?address=500+Interstate+Blvd+S,{bcvm.City},{bcvm.State}&key={geocodeKey}");
                var geocodeClient = _clientFactory.CreateClient("Geocoding");

                var geocodeResponse = await geocodeClient.SendAsync(geocodeRequest);

                var geocodeAsString = await geocodeResponse.Content.ReadAsStringAsync();

            }
            else
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
                    Website_URL = bcvm.Website_URL
                };
            }

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