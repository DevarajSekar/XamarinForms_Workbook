using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XF_Demos
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel mainPageViewModel;
        public MainPage()
        {
            InitializeComponent();
            mainPageViewModel = new MainPageViewModel()
            {
                ListItems =
             new List<ListItem>()
            {
                new ListItem(){ Name="ZXing Barcode Scanner", Description="This sample used to demo bar code scanner features in Xamarin forms", Icon="barcodescanner1.png"},
                new ListItem(){ Name="Camera View",Description="This demo shows Camera view works in Xamarin forms", Icon="photo.png" },
                new ListItem(){ Name="Base64 To Image",Description="This demo shows how to convert base 64 string to Image content", Icon= "convert.png"},
                new ListItem(){ Name="Drag and Drop",Description="This sample demos drag and drop feature in xamarin forms", Icon = "drag.png" },
                new ListItem(){ Name="Geofence",Description="This demo shows the feature of geo fencing and mapping concept", Icon= "googlemaps.png" },
                new ListItem(){ Name="Base64 To PDF",Description="This demo shows how to convert base 64 string to PDF content", Icon= "convert.png" },
                new ListItem(){ IsStarListItem=true,Name="Behaviors", Description="This demo shows behavior concepts in Xamarin forms", Icon= "decision.png" },
                new ListItem(){ Name="Buttons",Description="This demo shows how implement button customization in Xamarin forms", Icon= "play.png" },
                new ListItem(){ Name="Image To Bitmap",Description="This demo shows how to convert Xamarin  to Image content", Icon= "convert.png"},
             }
            };
            mainPageViewModel.ListItems=mainPageViewModel.ListItems.OrderBy(x => x.Name).ToList();
            mainPageViewModel.StarListItems = new List<ListItem>();
            foreach (var item in mainPageViewModel.ListItems)
            {
                if (item.IsStarListItem)
                {
                    mainPageViewModel.StarListItems.Add(item);
                }
            }

            BindingContext = mainPageViewModel;
            loginTime.Text = "Current Login: " + System.DateTime.Now.ToString();
        }
    }
}
