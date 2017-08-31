using SQLite;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Makapointment.Models
{
    [Table("Shops")]
    public class Shop
    {   
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string Image { get; set; }

        [ManyToMany(typeof(Shop_Stylist), "StylistId", "Shops")]
        public List<Stylist> Stylists { get; set; }

        public Shop()
        {
            Image = "http://lorempixel.com/600/400";
           
        }
        
    }
}
