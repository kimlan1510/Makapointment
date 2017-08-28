using Makapointment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Makapointment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopsPage : ContentPage
    {
        public ShopsPage()
        {
            InitializeComponent();
            listView.ItemsSource = GetShops();

            
        }

        IEnumerable<Shop> GetShops(string searchText = null)
        {
            var shops = new List<Shop> {
                new Shop {Name = "John's haircut", Location="Portland", PhoneNumber="971 123 3213", Image="http://lorempixel.com/400/200/"},
                new Shop {Name = "David barber", Location="Beaverton", PhoneNumber="503 213 1234", Image="http://lorempixel.com/400/200"},
                new Shop {Name = "John's haircut", Location="Portland", PhoneNumber="971 123 3213", Image="http://lorempixel.com/400/200/"}
            };
            if (String.IsNullOrWhiteSpace(searchText))
                return shops;
            return shops.Where(s => s.Name.ToLower().Contains(searchText.ToLower()));

        }
        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            listView.ItemsSource = GetShops(e.NewTextValue);
        }




    }
}