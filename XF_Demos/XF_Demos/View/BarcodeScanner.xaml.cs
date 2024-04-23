using System;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF_Demos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class BarcodeScanner : ContentPage
	{
        public BarcodeScanner(string pageHeader)
        {
            InitializeComponent();
            Titlebar.Title = pageHeader;
        }

        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Thread thread = new Thread(() =>
            {
                resultLabel.Text = "Info : " + result.Text + "\nBarcode Type : " +
                    result.BarcodeFormat.ToString();
            });
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            scanner.IsScanning = true;
        }
    }
}
