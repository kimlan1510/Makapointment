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

        private void ToolbarItem_Activated(object sender, EventArgs e)
        {
            DisplayAlert("Action", "Clicked", "ok");
        }
    }
}
