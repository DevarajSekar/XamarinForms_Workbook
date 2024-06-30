using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
        PlayWithFirentViewModel viewModel;
        public PlayWithPlayer()
        {
            InitializeComponent();
            viewModel = new PlayWithFirentViewModel();
            this.BindingContext = viewModel;
            Application.Current.RequestedThemeChanged += (s, a) =>
            {
                // Respond to the theme change
                viewModel.SetTheme();
            };
        }
    }

    public class PlayWithFirentViewModel : INotifyPropertyChanged
    {
        private Color individualBoxColor;
        private Color contentPageColor;
        private Color separatorLinesColor;
        private string[] arrays = new string[9];
        public ICommand TapCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public PlayWithFirentViewModel()
        {
            TapCommand = new Command(AddValue);
            SetTheme();
        }

        private void AddValue(object obj)
        {
            Button sender = (obj as Button);
            arrays[Convert.ToInt32(sender.Text)] = "X";
            sender.TextColor = Color.Black;
            sender.Text = "X";
            sender.IsEnabled = false;
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