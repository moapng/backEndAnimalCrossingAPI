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
        public string name { get; set; }
        public int price { get; set; }
    }
}
