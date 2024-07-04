using System;
using Xamarin.Forms;
using Xamarin.CommunityToolkit.Extensions;

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

        void PlayWithAI_Tapped(System.Object sender, System.EventArgs e)
        {
            DisplayAlert("OOP's we are under construction ", " Please play with friend ", " Close ");
        }
    }
}