using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace XF_Demos
{
    [ContentProperty("Child")]
    public partial class ContentHeaderView : ContentView
    {
        public ContentHeaderView()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public static readonly BindableProperty TitleProperty = BindableProperty.Create(propertyName: nameof(Title),
            typeof(string),
            typeof(ContentHeaderView),
            defaultValue: string.Empty,
        propertyChanged: TitlePropertyChanged);

        private static void TitlePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (ContentHeaderView)bindable;
            control.Title = newValue?.ToString();
        }

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly BindableProperty CodeDescriptionProperty = BindableProperty.Create(
            propertyName: nameof(CodeDescription),
            typeof(string),
            typeof(ContentHeaderView),
            defaultValue: string.Empty);

        public string CodeDescription
        {
            get => (string)GetValue(CodeDescriptionProperty);
            set => SetValue(CodeDescriptionProperty, value);
        }

        public static readonly BindableProperty CodeSnippetsProperty = BindableProperty.Create(
            propertyName: nameof(CodeSnippets),
            typeof(string),
           typeof(ContentHeaderView),
           defaultValue: string.Empty);

        public string CodeSnippets
        {
            get => (string)GetValue(CodeSnippetsProperty);
            set => SetValue(CodeSnippetsProperty, value);
        }

        private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            Navigation.PushPopupAsync(new CodeviewPage(Title, CodeDescription, CodeSnippets));
        }
    }
}