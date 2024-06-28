using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public event PropertyChangedEventHandler PropertyChanged;

        public PlayWithFirentViewModel()
        {
            SetTheme();
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