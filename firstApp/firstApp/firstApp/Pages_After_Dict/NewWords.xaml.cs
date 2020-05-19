using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace firstApp.Pages_After_Dict
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewWords : ContentPage
    {
        private List<string[]> _newWords = new List<string[]>();
        private int _current;

        public NewWords()
        {
            fillDict();
            InitializeComponent();
            GenerateRandomWord();
        }

        private void fillDict()
        {
            var sr1 = firstApp.Properties.Resources.NewWords; 
            var line = sr1.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var e in line)
            {
                if (e == null || e == "")
                    break;
                _newWords.Add(e.Split(' '));
            }
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

        private void ButtonRemember_Click(object sender, EventArgs e)
        {
            if (_current != -1)
            {
                var answer = Answer(_newWords[_current]); ;
                Label1.Text = answer;
                _newWords.RemoveAt(_current);
                _current = -1;
            }
        }

        private void ButtonRepeat_Click(object sender, EventArgs e)
        {
            if (_current != -1)
            {
                var answer = Answer(_newWords[_current]);
                Label1.Text = answer;
                _current = -1;
            }
        }

        private void ButtonNext_Click(object sender, EventArgs e)
        {
            GenerateRandomWord();
        }

        private void GenerateRandomWord()
        {
            Random r = new Random();
            _current = r.Next(0, _newWords.Count); 
            var word = _newWords[_current];
            Label1.Text = word[0];
        }
    }
}