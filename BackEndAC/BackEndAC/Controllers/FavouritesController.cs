using BackEndAC.Context;
using BackEndAC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEndAC.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FavouritesController : ControllerBase
    {
        

        // GET: /<FavouritesController>
        [HttpGet]
        public IEnumerable<FavouriteModel> Get()
        {
            var options = new DbContextOptionsBuilder<MyContext>().UseInMemoryDatabase(databaseName: "Test").Options;
            using(var context = new MyContext(options))
            {
                return context.favourites.ToArray();
            }
        }

        // POST /<FavouritesController>
        [HttpPost]
        public void Post([FromBody] FavouriteModel favourite)
        {
            var options = new DbContextOptionsBuilder<MyContext>().UseInMemoryDatabase(databaseName: "Test").Options;
            using (var context = new MyContext(options))
            {
                context.favourites.Add(favourite);
                context.SaveChanges();
            }
        }

        // DELETE /<FavouritesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
