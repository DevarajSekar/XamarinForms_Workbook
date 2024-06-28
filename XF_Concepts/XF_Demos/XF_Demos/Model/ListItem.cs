using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using XF_Demos.ViewModel;

namespace XF_Demos
{
    internal class ListItem : BaseViewModel
    {
        private bool isStarListItem = false;
        private bool isFrameworkListItem = false;
        private bool isXCTListItem = false;
        private Color listItemColor;

        public ListItem()
        {
            TapCommand = new Command(ItemTapped);
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        
        public ICommand TapCommand { get; set; }

        public ImageSource StarItemIcon
        {
            get
            {
                if (IsXCTListItem)
                   return ImageSource.FromFile("xctlisticon.png");
                else
                    return ImageSource.FromFile("bluetickicon.png");
            }
        }

        public bool IsStarListItem
        {
            get
            {
                return isStarListItem;
            }
            set
            {
                isStarListItem = value;
                OnPropertyChanged(nameof(IsStarListItem));
            }
        }

        public Color ListItemColor
        {
            get
            {
                return listItemColor;
            }
            set
            {
                listItemColor = value;
                OnPropertyChanged(nameof(ListItemColor));
            }
        }

        public bool IsFrameworkListItem
        {
            get
            {
                return isFrameworkListItem;
            }
            set
            {
                isFrameworkListItem = value;
                IsStarListItem = value;
                OnPropertyChanged(nameof(IsFrameworkListItem));
            }
        }

        public bool IsXCTListItem
        {
            get
            {
                return isXCTListItem;
            }
            set
            {
                isXCTListItem = value;
                IsStarListItem = true;
                OnPropertyChanged(nameof(IsXCTListItem));
            }
        }

        private async void ItemTapped(object obj)
        {
            switch (obj.ToString())
            {
                case "ZXing Barcode Scanner":
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await Application.Current.MainPage.Navigation.PushAsync(new BarcodeScanner(Name));
                    });
                    break;
                case "Base64 To Image":
                    await Application.Current.MainPage.Navigation.PushAsync(new BaseToImage(Name));
                    break;
                case "Base64 To PDF":
                    await Application.Current.MainPage.Navigation.PushAsync(new BaseToPDF(Name));
                    break;
                default:
                    break;
            }
        }
    }
}
