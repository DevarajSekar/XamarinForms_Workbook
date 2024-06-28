using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TicTacToe
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            SetTheme();
            Application.Current.RequestedThemeChanged += (s, a) =>
            {
                // Respond to the theme change
                SetTheme();
            };
        }

        public void SetTheme()
        {
            OSAppTheme currentTheme = Application.Current.RequestedTheme;
            if (currentTheme == OSAppTheme.Dark)
            {
                contentPage.BackgroundColor = Color.Black;
            }
            else
            {
                contentPage.BackgroundColor = Color.White;
            }
        }

        private void PlayWithPlayer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PlayWithPlayer());
        }
    }
}
