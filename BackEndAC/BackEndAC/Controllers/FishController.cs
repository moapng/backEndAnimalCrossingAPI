using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
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

        private readonly IMemoryCache _memoryCache;
        public FishController(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        // GET all fishes
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var url = "http://acnhapi.com/v1/fish/";
            var cacheKey = "Get_All_Fish";

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

        // GET fish with id
        [HttpGet("{fishID}")]
        public async Task<IActionResult> Get(int fishID)
        {
            var url = "http://acnhapi.com/v1/fish/" + fishID;
            var cacheKey = $"Get_Fish-{fishID}";
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
