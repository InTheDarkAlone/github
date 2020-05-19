using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace firstApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllTexts : ContentPage
    {
        public AllTexts()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Dict());
        }
    }
}