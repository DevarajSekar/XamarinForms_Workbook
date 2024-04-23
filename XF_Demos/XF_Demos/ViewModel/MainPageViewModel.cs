using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;
using XF_Demos.ViewModel;

namespace XF_Demos
{
    internal class MainPageViewModel : BaseViewModel
    {
        private ImageSource starListIcon;
        private List<ListItem> fullListItems;
        private List<ListItem> starListItems;
        private List<ListItem> mainListItems;

        public MainPageViewModel()
        {
            StarListIcon = ImageSource.FromFile("ribbon.png");
            isStarListDisplaying = false;
            StarListTapped = new Command(SwitchChildernList);
        }


        public ICommand StarListTapped { get; set; }
        public bool isStarListDisplaying { get; set; }

        public List<ListItem> ListItems
        {
            get
            {
                return mainListItems;
            }
            set
            {
                mainListItems = value;
                if (FullListItems is null)
                    FullListItems = value;
                OnPropertyChanged(nameof(ListItems));
            }
        }

        public List<ListItem> StarListItems
        {
            get
            {
                return starListItems;
            }
            set
            {
                starListItems = value;
                OnPropertyChanged(nameof(StarListItems));
            }
        }

        public List<ListItem> FullListItems
        {
            get
            {
                return fullListItems;
            }
            set
            {
                fullListItems = value;
                OnPropertyChanged(nameof(FullListItems));
            }
        }

        private void SwitchChildernList(object obj)
        {
            IsStarListDisplaying = !IsStarListDisplaying;
        }

        public ImageSource StarListIcon
        {
            get
            {
                return starListIcon;
            }
            set
            {
                starListIcon = value;
                OnPropertyChanged(nameof(StarListIcon));
            }
        }

        public bool IsStarListDisplaying
        {
            get
            {
                return isStarListDisplaying;
            }
            set
            {
                isStarListDisplaying = value;
                if (!value)
                {
                    StarListIcon = ImageSource.FromFile("ribbon.png");
                    ShowAllList();
                }
                else
                {
                    StarListIcon = ImageSource.FromFile("openbox.png");
                    ShowStarList();
                }
                OnPropertyChanged(nameof(IsStarListDisplaying));
            }
        }

        private void ShowStarList()
        {
            ListItems = StarListItems;
        }

        private void ShowAllList()
        {
            FullListItems = FullListItems.OrderBy(x => x.Name).ToList();
            ListItems = FullListItems;
        }
    }
}
