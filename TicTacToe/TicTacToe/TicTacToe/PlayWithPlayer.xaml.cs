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
        private string boxNumber1;
        private string boxNumber2;
        private string boxNumber3;
        private string boxNumber4;
        private string boxNumber5;
        private string boxNumber6;
        private string boxNumber7;
        private string boxNumber8;
        private string boxNumber9;

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

        public string BoxNumber1
        {
            get
            {
                return boxNumber1;
            }
            set
            {
                boxNumber1 = value;
                OnPropertyChanged(nameof(BoxNumber1));
            }
        }

        public string BoxNumber2
        {
            get
            {
                return boxNumber2;
            }
            set
            {
                boxNumber2 = value;
                OnPropertyChanged(nameof(BoxNumber2));
            }
        }

        public string BoxNumber3
        {
            get
            {
                return boxNumber3;
            }
            set
            {
                boxNumber3 = value;
                OnPropertyChanged(nameof(BoxNumber3));
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}