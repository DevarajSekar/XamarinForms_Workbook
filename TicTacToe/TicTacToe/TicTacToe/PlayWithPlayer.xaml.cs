using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace TicTacToe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayWithPlayer : ContentPage
    {
        PlayWithFrientViewModel viewModel;
        public PlayWithPlayer()
        {
            InitializeComponent();
            viewModel = new PlayWithFrientViewModel();
            this.BindingContext = viewModel;
            Application.Current.RequestedThemeChanged += (s, a) =>
            {
                // Respond to the theme change
                viewModel.SetTheme();
            };
        }
    }

    public class PlayWithFrientViewModel : INotifyPropertyChanged
    {
        private Color individualBoxColor;
        private Color contentPageColor;
        private Color separatorLinesColor;
        private Color textColor;
        private string[] arrays = new string[9];
        public ICommand TapCommand { get; set; }
        public ICommand RestartCommand { get; set; }
        string lasttext=string.Empty;

        public event PropertyChangedEventHandler PropertyChanged;

        public PlayWithFrientViewModel()
        {
            TapCommand = new Command(AddValue);
            RestartCommand = new Command(Restart);
            SetTheme();
        }

        private void Restart(object obj)
        {
            App.Current.MainPage.Navigation.PopAsync();
        }

        private void AddValue(object obj)
        {
            Button sender = (obj as Button);
            if (string.IsNullOrEmpty(lasttext))
            {
                lasttext = "X";
            }
            else if (lasttext == "X")
                lasttext = "O";
            else
                lasttext = "X";

            arrays[Convert.ToInt32(sender.Text)] = lasttext;
            sender.TextColor = SeparatorLinesColor;
            sender.Text = lasttext;
            sender.IsEnabled = false;

            CheckResult();
        }

        private async void CheckResult()
        {
            string winner = "Player 1 Winner";
            ////Row wise check
            if (CheckRowsColsResult(0, 1, 2))
            {
                if (arrays[0] == "O")
                    winner = "Player 2 Winner";
                await App.Current.MainPage.DisplayAlert("Winner!!", winner, "OK");

                await App.Current.MainPage.Navigation.PushAsync(new PlayWithPlayer());
            }

            ////Row wise check
            else if (CheckRowsColsResult(3, 4, 5))
            {
                if (arrays[3] == "O")
                    winner = "Player 2 Winner";
                await App.Current.MainPage.DisplayAlert("Winner!!", winner, "OK");
                await App.Current.MainPage.Navigation.PushAsync(new PlayWithPlayer());
            }

            ////Row wise check
            else if (CheckRowsColsResult(6, 7, 8))
            {
                if (arrays[6] == "O")
                    winner = "Player 2 Winner";
                await App.Current.MainPage.DisplayAlert("Winner!!", winner, "OK");
                await App.Current.MainPage.Navigation.PushAsync(new PlayWithPlayer());
            }

            ////Column wise check
            else if (CheckRowsColsResult(0, 3, 6))
            {
                if (arrays[0] == "O")
                    winner = "Player 2 Winner";
                await App.Current.MainPage.DisplayAlert("Winner!!", winner, "OK");
                await App.Current.MainPage.Navigation.PushAsync(new PlayWithPlayer());
            }

            ////Column wise check
            else if (CheckRowsColsResult(1, 4, 7))
            {
                if (arrays[1] == "O")
                    winner = "Player 2 Winner";
                await App.Current.MainPage.DisplayAlert("Winner!!", winner, "OK");
                await App.Current.MainPage.Navigation.PushAsync(new PlayWithPlayer());
            }

            ////Column wise check
            else if (CheckRowsColsResult(2, 5, 8))
            {
                if (arrays[2] == "O")
                    winner = "Player 2 Winner";
                await App.Current.MainPage.DisplayAlert("Winner!!", winner, "OK");
                await App.Current.MainPage.Navigation.PushAsync(new PlayWithPlayer());
            }

            ////Diagonal wise check
            else if (CheckRowsColsResult(0, 4, 8))
            {
                if (arrays[0] == "O")
                    winner = "Player 2 Winner";
                await App.Current.MainPage.DisplayAlert("Winner!!", winner, "OK");
                await App.Current.MainPage.Navigation.PushAsync(new PlayWithPlayer());
            }

            ////Diagonal wise check
            else if (CheckRowsColsResult(2, 4, 6))
            {
                if (arrays[2] == "O")
                    winner = "Player 2 Winner";
                await App.Current.MainPage.DisplayAlert("Winner!!", winner, "OK");
                await App.Current.MainPage.Navigation.PushAsync(new PlayWithPlayer());
            }

            ////Draw check
            else if (CheckDrawresult())
            {
                await App.Current.MainPage.DisplayAlert("Draw", "Match Draw", "OK");
                await App.Current.MainPage.Navigation.PushAsync(new PlayWithPlayer());
            }
        }

        bool CheckRowsColsResult(int i, int j, int k)
        {
            if (!string.IsNullOrEmpty(arrays[i]) &&
                !string.IsNullOrEmpty(arrays[j]) &&
                !string.IsNullOrEmpty(arrays[k]) &&
                arrays[i] == arrays[j] && arrays[j] == arrays[k])
            {

                return true;
            }
            return false;
        }

        bool CheckDrawresult()
        {
            foreach (string i in arrays)
            {
                if (string.IsNullOrEmpty(i))
                {
                    return false;
                }
            }
            return true;
        }

        public void SetTheme()
        {
            OSAppTheme currentTheme = Application.Current.RequestedTheme;
            if (currentTheme == OSAppTheme.Dark)
            {
                IndividualBoxColor = Color.FromHex("#363433");
                ContentPageColor = Color.Black;
                SeparatorLinesColor = Color.Black;
            }
            else
            {
                IndividualBoxColor = Color.White;
                ContentPageColor = Color.White;
                SeparatorLinesColor = Color.WhiteSmoke;
            }
        }

        public Color IndividualBoxColor
        {
            get
            {
                return individualBoxColor;
            }
            set
            {
                individualBoxColor = value;
                OnPropertyChanged(nameof(IndividualBoxColor));
            }
        }

        public Color TextColor
        {
            get
            {
                return textColor;
            }
            set
            {
                textColor = value;
                OnPropertyChanged(nameof(TextColor));
            }
        }

        public Color ContentPageColor
        {
            get
            {
                return contentPageColor;
            }
            set
            {
                contentPageColor = value;
                OnPropertyChanged(nameof(ContentPageColor));
            }
        }

        public Color SeparatorLinesColor
        {
            get
            {
                return separatorLinesColor;
            }
            set
            {
                separatorLinesColor = value;
                OnPropertyChanged(nameof(SeparatorLinesColor));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}