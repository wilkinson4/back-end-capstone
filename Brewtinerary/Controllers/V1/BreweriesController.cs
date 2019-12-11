using Capstone.Data;
using Capstone.Models.Data;
using Capstone.Routes.V1;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using static Capstone.Routes.V1.Api;

namespace Capstone.Controllers.V1
{
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
    }
}