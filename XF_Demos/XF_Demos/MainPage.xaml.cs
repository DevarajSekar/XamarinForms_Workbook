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
                new ListItem(){ Name="ZXing Barcode Scanner", Description="This sample used to demo bar code scanner features in Xamarin forms", Icon="barcodescanner.png"},
                new ListItem(){ Name="Camera View",Description="This demo shows Camera view works in Xamarin forms", Icon="photo.png" },
                new ListItem(){ Name="Base64 To Image",Description="This demo shows how to convert base 64 string to Image content", Icon= "convert.png"},
                new ListItem(){ Name="Drag and Drop",Description="This sample demos drag and drop feature in xamarin forms", Icon = "drag.png" },
                new ListItem(){ Name="Base64 To PDF",Description="This demo shows how to convert base 64 string to PDF content", Icon= "convert.png" },
                new ListItem(){ Name="Behaviors", Description="This demo shows behavior concepts in Xamarin forms", Icon= "behaviors.png", IsFrameworkListItem=true },
                new ListItem(){ Name="Buttons",Description="This demo shows how implement button customization in Xamarin forms", Icon= "play.png" },
                new ListItem(){ Name="Image To Bitmap",Description="This demo shows how to convert Xamarin  to Image content", Icon= "convert.png"},
                new ListItem(){ Name="Carousel",Description="", Icon= "carousel.png"},
                new ListItem(){ Name="Barcode Generator",Description="", Icon="barcodescanner.png"},
                new ListItem(){ Name="Geofence and Location",Description="", Icon= "googlemaps.png"},
                new ListItem(){ Name="Image Barcode",Description="", Icon= "barcodescanner.png"},
                new ListItem(){ Name="Multi Selection",Description="", Icon= "multiselect.png", IsXCTListItem = true},
                new ListItem(){ Name="Native Popup",Description="", Icon= "popup.png"},
                new ListItem(){ Name="Pancake View",Description="", Icon= "pancake.png"},
                new ListItem(){ Name="Preference",Description="", Icon= "programming.png"},
                new ListItem(){ Name="ScribblePad",Description="", Icon= "scribblepad.png", IsXCTListItem=true},
                new ListItem(){ Name="Text to Speech",Description="", Icon= "podcast.png", IsXCTListItem=true},
                new ListItem(){ Name="Unit Converter",Description="", Icon= "convert.png"},
                new ListItem(){ Name="Value Converter",Description="", Icon= "convert.png"},
                new ListItem(){ Name="Yum Yum",Description="", Icon= "yumyum.png"},
                new ListItem(){ Name="Triggers",Description="", Icon= "effects.png", IsFrameworkListItem=true},
                new ListItem(){ Name="Effects",Description="This demo shows effects concept in Xamarin forms", Icon= "effects.png", IsFrameworkListItem=true },
                new ListItem(){ Name="Wireless Connection",Description="This is not a demo. It is doc shows how to connect device to lap without wired connection", Icon= "programming.png"}
             }
            };
            mainPageViewModel.ListItems=mainPageViewModel.ListItems.OrderBy(x => x.Name).ToList();
            mainPageViewModel.StarListItems = new List<ListItem>();
            foreach (var item in mainPageViewModel.ListItems)
            {
                if (item.IsFrameworkListItem || item.IsXCTListItem)
                {
                    mainPageViewModel.StarListItems.Add(item);
                }
            }

            BindingContext = mainPageViewModel;
        }
    }
}

//Sample commit in iOS - using git in vs 2022 mac mini.

//Sample commit in iOS - using source tree in mac mini.