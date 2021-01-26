using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BackEndAC.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SeaController : ControllerBase
    {
        
        // GET all sea creatures
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var url = "http://acnhapi.com/v1/sea/";
            string StringResponse;
            using (var client = new HttpClient())
            using (var response = await client.GetAsync(url))
            {
                var responseContent = response.Content;
                StringResponse = await responseContent.ReadAsStringAsync();
                var serializerResponse = JsonConvert.DeserializeObject(StringResponse);
            }
            return Ok(StringResponse);
        }

        // GET sea creature with id
        [HttpGet("{seaID}")]
        public async Task<IActionResult> Get(int seaID)
        {
            var url = "http://acnhapi.com/v1/sea/" + seaID;
            string StringResponse;
            using (var client = new HttpClient())
            using (var response = await client.GetAsync(url))
            {
                var responseContent = response.Content;
                StringResponse = await responseContent.ReadAsStringAsync();
                var serializerResponse = JsonConvert.DeserializeObject(StringResponse);
            }
            return Ok(StringResponse);
        }
    }
}
