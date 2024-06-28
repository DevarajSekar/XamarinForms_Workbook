using Xamarin.Forms;

namespace XF_Demos
{
    [ContentProperty("Child")]
    public partial class ContentFooterView : ContentView
    {
        public ContentFooterView()
        {
            InitializeComponent();
        }

        private void backIcon_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}