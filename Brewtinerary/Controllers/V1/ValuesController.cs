using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Capstone.Routes.V1;
using System.Linq;

namespace Capstone.Controllers.V1
{
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        public ValuesController()
        {
        }

        [HttpGet(Api.Values.GetAll)]
        public IActionResult GetAll(string _filter)
        {
            var values = new[] { "value 1", "value 2", "value 3" };
            if(_filter != null){
                values = values.Where(v => v.Contains(_filter)).ToArray();
            }
            return Ok(values);
        }

        [HttpGet(Api.Values.Get)]
        public IActionResult Get(int id)
        {
            var value = $"value {id}";
            return Ok(value);
        }
    }
}