using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makapointment.Models
{
    public class Shop_Stylist
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ForeignKey(typeof(Shop))]
        public int ShopId { get; set; }

        [ForeignKey(typeof(Stylist))]
        public int StylistId { get; set; }
    }
}
