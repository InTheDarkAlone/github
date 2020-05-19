using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace firstApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dict : ContentPage
    {
        private Dictionary<string,string> _dictionary= new Dictionary<string,string>();
        public Dict()
        { 
            FillDict();

            StackLayout stackLayout = new StackLayout();
            var button = new Button() { Text = "Перейдем к карточкам" };
            button.Clicked += (sender, e) => Button1_Click(sender,e);
            stackLayout.Children.Add(button);
            stackLayout.Children.Add(new Entry() { Placeholder = "Введите для поиска"});
            foreach(var word in _dictionary)
            {
                stackLayout.Children.Add(new Label() { Text = word.Key + word.Value, FontSize = 25, TextColor = Color.Black});
            }

            ScrollView scrollView = new ScrollView();
            scrollView.Content = stackLayout;
            Content = scrollView;
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AllCards());
        }

        private void FillDict()
        {
            var sr1 = firstApp.Properties.Resources.dictionary;
            var line = sr1.Split(new char[]{'\n','\r'}, StringSplitOptions.RemoveEmptyEntries);
            var result = new StringBuilder();
            foreach (var e in line)
            {
                if (e == null || e =="") 
                    break;
                var words = e.Split(' ');
                foreach (var word in words.Skip(1))
                {
                    result.Append(word + " ");
                }
                _dictionary[words[0]] = result.ToString();
                result.Clear();
            }
        }
    }
}