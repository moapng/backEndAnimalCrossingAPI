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
    public class SeaController : ControllerBase
    {
        private readonly IMemoryCache _memoryCache;
        public SeaController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        // GET all sea creatures
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var url = "http://acnhapi.com/v1/sea/";
            var cacheKey = "Get_All_Sea";
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

        // GET sea creature with id
        [HttpGet("{seaID}")]
        public async Task<IActionResult> Get(int seaID)
        {
            var url = "http://acnhapi.com/v1/sea/" + seaID;
            var cacheKey = $"Get_Sea{seaID}";
            if (_memoryCache.TryGetValue(cacheKey, out string cachedValue))
                return Ok(cachedValue);

            string StringResponse;

            using (var client = new HttpClient())
            using (var response = await client.GetAsync(url))
            {
                var responseContent = response.Content;
                StringResponse = await responseContent.ReadAsStringAsync();
            }

            return Ok(StringResponse);
        }
    }
}
