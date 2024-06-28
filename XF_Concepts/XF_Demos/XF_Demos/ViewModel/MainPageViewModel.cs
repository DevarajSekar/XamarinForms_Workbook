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
        private ImageSource themeIcon;
        private List<ListItem> fullListItems;
        private List<ListItem> starListItems;
        private List<ListItem> mainListItems;
        private bool isDarkTheme;
        private CurrentTheme currentTheme;
        private Color currentMainPageBackgroundColor;
        private Color overallStackBackgroundColor;
        private Color listVIewBackground;
        private Color listItemColor;

        public MainPageViewModel()
        {
            StarListIcon = ImageSource.FromFile("application.png");
            SetTheme(CurrentTheme.Light);
            isStarListDisplaying = false;
            currentTheme = CurrentTheme.Light;
            StarListTapped = new Command(SwitchChildernList);
            ThemeOptionTapped = new Command(SwitchTheme);
        }

        private void SwitchTheme(object obj)
        {
            if (CurrentTheme is CurrentTheme.Light)
                CurrentTheme = CurrentTheme.Dark;
            else
                CurrentTheme = CurrentTheme.Light;
        }

        public ICommand StarListTapped { get; set; }
        public ICommand ThemeOptionTapped { get; set; }
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

        public CurrentTheme CurrentTheme
        {
            get
            {
                return currentTheme;
            }
            set
            {
                currentTheme = value;
                SetTheme(value);
                OnPropertyChanged(nameof(CurrentTheme));
            }
        }

        void SetTheme(CurrentTheme theme)
        {
            if (theme is CurrentTheme.Dark)
            {
                ThemeIcon = ImageSource.FromFile("lightthemeicon.png");
                CurrentMainPageBackgroundColor = Color.Black;
                OverallStackBackgroundColor = Color.Black;
                ListViewBackground = Color.DimGray;
                ListItemColor = Color.Black;
            }
            else if (theme is CurrentTheme.Light)
            {
                ThemeIcon = ImageSource.FromFile("darkthemeicon.png");
                CurrentMainPageBackgroundColor = Color.White;
                OverallStackBackgroundColor = Color.White;
                ListViewBackground = Color.FromHex("#eff1f3");
                ListItemColor = Color.White;
            }
            if (mainListItems != null)
            {
                foreach (var item in FullListItems)
                {
                    item.ListItemColor = ListItemColor;
                }
            }
        }

        public Color CurrentMainPageBackgroundColor
        {
            get
            {
                return currentMainPageBackgroundColor;
            }
            set
            {
                currentMainPageBackgroundColor = value;
                OnPropertyChanged(nameof(CurrentMainPageBackgroundColor));
            }
        }

        public Color OverallStackBackgroundColor
        {
            get
            {
                return overallStackBackgroundColor;
            }
            set
            {
                overallStackBackgroundColor = value;
                OnPropertyChanged(nameof(OverallStackBackgroundColor));
            }
        }

        public Color ListViewBackground
        {
            get
            {
                return listVIewBackground;
            }
            set
            {
                listVIewBackground = value;
                OnPropertyChanged(nameof(ListViewBackground));
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

        public ImageSource ThemeIcon
        {
            get
            {
                return themeIcon;
            }
            set
            {
                themeIcon = value;
                OnPropertyChanged(nameof(ThemeIcon));
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
                    ShowAllList();
                }
                else
                {
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

    public enum CurrentTheme
    {
        Light,
        Dark
    }
}
