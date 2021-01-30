using BackEndAC.Context;
using BackEndAC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



// NOT WORKING AS INTENDED

//namespace BackEndAC.Controllers
//{
//    [Route("[controller]")]
//    [ApiController]
//    public class FavouritesController : ControllerBase
//    {

//        // GET: /<FavouritesController>
//        [HttpGet]
//        public IEnumerable<FavouriteModel> Get()
//        {
//            var options = new DbContextOptionsBuilder<MyContext>().UseInMemoryDatabase(databaseName: "Test").Options;
//            using (var context = new MyContext(options))
//            {
//                return context.favourites.ToArray();
//            }
//        }

//        // POST /<FavouritesController>
//        [HttpPost]
//        public void Post([FromBody] FavouriteModel favourite)
//        {
//            var options = new DbContextOptionsBuilder<MyContext>().UseInMemoryDatabase(databaseName: "Test").Options;

//            using (var context = new MyContext(options))
//            {

//                if (favourite.name != null && !context.favourites.Contains(favourite) )
//                {
//                    context.favourites.Add(favourite);
//                    context.SaveChanges();
//                }
//            }
//        }

//        // DELETE /<FavouritesController>/5
//        [HttpDelete("{id}")]
//        public void Delete(int id)
//        {
//        }
//    }
//}
