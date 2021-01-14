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
    public class BugController : Controller
    {
       
        // GET all bugs
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var url = "http://acnhapi.com/v1/bugs/";
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

        // GET bug with id
        [HttpGet("{bugID}")]
        public async Task<IActionResult> Get(int bugID)
        {
            var url = "http://acnhapi.com/v1/bugs/" + bugID;
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
