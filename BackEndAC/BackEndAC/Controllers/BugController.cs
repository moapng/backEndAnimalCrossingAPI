using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _memoryCache;
        public BugController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        // GET all bugs
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var url = "http://acnhapi.com/v1/bugs/";
            var cacheKey = "Get_All_Bugs";

            if (_memoryCache.TryGetValue(cacheKey, out string cachedValue))
                return Ok(cachedValue);

            string StringResponse;

            using (var client = new HttpClient())
            using (var response = await client.GetAsync(url))
            {
                var responseContent = response.Content;
                StringResponse = await responseContent.ReadAsStringAsync();
            }

            _memoryCache.Set(cacheKey, StringResponse);
            return Ok(StringResponse);
        }

        // GET bug with id
        [HttpGet("{bugID}")]
        public async Task<IActionResult> Get(int bugID)
        {
            var url = "http://acnhapi.com/v1/bugs/" + bugID;
            var cacheKey = $"Get_Bug-{bugID}";

            if (_memoryCache.TryGetValue(cacheKey, out string cachedValue))
                return Ok(cachedValue);

            string StringResponse;

            using (var client = new HttpClient())
            using (var response = await client.GetAsync(url))
            {
                var responseContent = response.Content;
                StringResponse = await responseContent.ReadAsStringAsync();
            }

            _memoryCache.Set(cacheKey, StringResponse);
            return Ok(StringResponse);
        }

    }
}
