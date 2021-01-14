using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndPlantFriend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FishController : ControllerBase
    {
        // GET all fish
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var url = "http://acnhapi.com/v1/fish/";
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

        // GET fish with id
        [HttpGet("{fishID}")]
        public async Task<IActionResult> Get(int fishID)
        {
            var url = "http://acnhapi.com/v1/fish/" + fishID;
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

       
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

       
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
