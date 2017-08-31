using SQLite;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makapointment.Models
{
    public class Stylist
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        [ManyToMany(typeof(Shop_Stylist), "ShopId", "Stylists")]
       
        public List<Shop> Shops { get; set; }

        public Stylist()
        {
            Image = "http://lorempixel.com/600/400/people";
           
        }
    }
}
