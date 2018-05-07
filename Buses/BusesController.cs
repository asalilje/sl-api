using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SLApi.Buses;

namespace SLApi.Controllers
{
    [Route("buses")]
    public class BusesController : Controller
    {
        private readonly HttpClient _client;
        private readonly string _token;

        public BusesController(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _token = configuration.GetValue<string>("SL_TOKEN");
        }

        public async Task<IActionResult> Get()
        {
            try
            {
                var url = $"http://api.sl.se/api2/realtimedeparturesV4.json?key={_token}&siteid=1275&timewindow=30";
                using (var response = await _client.GetAsync(url))
                {
                    using (var content = response.Content)
                    {
                        var data = await content.ReadAsStringAsync();
                        var buses = JsonConvert.DeserializeObject<BusesModel>(data);
                        return Ok(buses.ResponseData);
                    }
                }
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }

}
