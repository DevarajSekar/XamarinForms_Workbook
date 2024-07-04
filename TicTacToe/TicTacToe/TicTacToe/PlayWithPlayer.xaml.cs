using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
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
        private bool parentIsEnabled;
        private string[] arrays = new string[9];
        public ICommand TapCommand { get; set; }
        public ICommand RestartCommand { get; set; }
        string lasttext=string.Empty;
        private float cornerRadius = 50;

        public event PropertyChangedEventHandler PropertyChanged;

        public PlayWithFrientViewModel()
        {
            TapCommand = new Command(AddValue);
            RestartCommand = new Command(Restart);
            ParentIsEnabled = true;
            if (Device.iOS == "iOS")
                CornerRadius = 30;
            SetTheme();
        }

        private void Restart(object obj)
        {
            App.Current.MainPage.Navigation.PopToRootAsync();
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
            ////Row wise check
            if (CheckRowsColsResult(0, 1, 2) || CheckRowsColsResult(3, 4, 5) || CheckRowsColsResult(6, 7, 8))
            {
                await App.Current.MainPage.Navigation.PushAsync(new PlayWithPlayer());
            }

            ////Column wise check
            else if (CheckRowsColsResult(0, 3, 6) || CheckRowsColsResult(1, 4, 7) || CheckRowsColsResult(2, 5, 8))
            {
                await App.Current.MainPage.Navigation.PushAsync(new PlayWithPlayer());
            }

            ////Diagonal wise check
            else if (CheckRowsColsResult(0, 4, 8) || CheckRowsColsResult(2, 4, 6))
            {
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
            string winner = "1";
            if (!string.IsNullOrEmpty(arrays[i]) &&
                !string.IsNullOrEmpty(arrays[j]) &&
                !string.IsNullOrEmpty(arrays[k]) &&
                arrays[i] == arrays[j] && arrays[j] == arrays[k])
            {
                ParentIsEnabled = false;
                if (arrays[i] == "O")
                    winner = "2";
                App.Current.MainPage.DisplayAlert("Winner!!", "Player " + winner + " Wins", "OK");
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

        public bool ParentIsEnabled
        {
            get
            {
                return parentIsEnabled;
            }
            set
            {
                parentIsEnabled = value;
                OnPropertyChanged(nameof(ParentIsEnabled));
            }
        }

        public float CornerRadius
        {
            get
            {
                return cornerRadius;
            }
            set
            {
                cornerRadius = value;
                OnPropertyChanged(nameof(CornerRadius));
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