using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace firstApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Dict());
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllTexts());
        }

        private async void Button3_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllCards());
        }
    }
}
