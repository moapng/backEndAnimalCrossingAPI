using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BackEndAC.Models
{
    public class FavouriteModel
    {
        public int id { get; set; }
        //[Key]
        public string name { get; set; }
    }
}
