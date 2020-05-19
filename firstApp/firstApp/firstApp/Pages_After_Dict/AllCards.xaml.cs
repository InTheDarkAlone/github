using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using firstApp.Pages_After_Dict;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace firstApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllCards : ContentPage
    {
        public AllCards()
        {
            InitializeComponent();
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NewWords());
        }

        private async void Button2_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OldWords());
        }
    }
}