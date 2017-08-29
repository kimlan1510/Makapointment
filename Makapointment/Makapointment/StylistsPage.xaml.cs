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
    public partial class StylistsPage : ContentPage
    {
        public StylistsPage(Shop shop)
        {
            InitializeComponent();
   
        }
    }
}