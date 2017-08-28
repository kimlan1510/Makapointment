using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Makapointment
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        private async void ToolbarItem_Activated(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CreateShopPage());
            
        }
    }
}
