using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Makapointment.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Makapointment
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShopDetailPage : ContentPage
    {
        public ShopDetailPage(Shop shop)
        {
            if (shop == null)
                throw new ArgumentNullException();
            
            BindingContext = shop;
            InitializeComponent();
            
        }
    }
}