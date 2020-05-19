using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace firstApp.Pages_After_Dict
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OldWords : ContentPage
    {
        private List<string[]> dictionaryOldWords = new List<string[]>();
        private int _current;

        public OldWords()
        {
            fillDict();
            InitializeComponent();
        }

        private void fillDict()
        {
            var sr1 = firstApp.Properties.Resources.OldWords;
            var line = sr1.Split('\n');
            foreach (var e in line)
                dictionaryOldWords.Add(e.Split(' '));
        }

        private void ButtonAnswer_Click(object sender, EventArgs e)
        {
            if (_current != -1)
            {
                var answer = Answer(dictionaryOldWords[_current]);
                Label1.Text = answer;
                _current = -1;
            }
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            _current = r.Next(0, dictionaryOldWords.Count);
            var words = dictionaryOldWords[_current];
            Label1.Text = words[0];
        }

        private string Answer(string[] words)
        {
            var result = new StringBuilder();
            foreach (var word in words)
            {
                result.Append(" " + word);
            }

            return result.ToString();
        }
    }
}