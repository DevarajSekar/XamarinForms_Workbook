using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF_Demos.ViewModel;

namespace XF_Demos
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseToImage : ContentPage
    {
        Base64ToImageViewModel viewModel;
        //string Base64String = "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";
        public BaseToImage(string pageTitle)
        {
            InitializeComponent();
            SetViewModel(pageTitle);
        }

        private void SetViewModel(string pageTitle)
        {
            viewModel = new Base64ToImageViewModel
            {
                Base64String = "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",
                PlaceHolderString = "enter base 64 string data",
                SampleTitle = pageTitle,

                CodeDescription = "This sample contain 3 main classes - \n B64TImg view.cs " +
                "\n B64TImg xaml.cs and " +
                "\n B64TImgViewModel class " +
                "\n\nIn the xaml.cs the header/title part is a XF content view, which acts as a custom control, it has custom bindable property called TitleProperty. " +
                "\n\nThe connection will be B64Timg VM class property -> custom control title property - bit tricky binding." +
                "\nOther bindings follows basic XF binding procedure" +
                "Code snippets mentioned below ",

                CodeSnippet = "//IMP Code snippet  <!--Title bar-->\r\n            <XF_Demos:ContentHeaderView \r\n                Title=\"{Binding \r\n                Source={RelativeSource \r\n                AncestorType={x:Type viewModel:Base64ToImageViewModel}}, \r\n                Path=SampleTitle}\" \n\n//Method to load directly from stream\r\n        private void LoadfromStreamMethod()\r\n        {\r\n            //Loading from stream method without saving and loading\r\n            byte[] imageBytes = Convert.FromBase64String(viewModel.Base64String);\r\n            using (MemoryStream ms = new MemoryStream(imageBytes))\r\n            {\r\n                imageView.Source = ImageSource.FromStream(() => ms);\r\n            }\r\n        }\r\n\r\n\r\n        //Method to save the stream locally and load into image obj\r\n        private void SaveAndLoadMethod()\r\n        {\r\n            ////Saving locally and retrieving method\r\n            byte[] imageBytes = Convert.FromBase64String(viewModel.Base64String);\r\n            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);\r\n            ////Image Format\r\n            var filePath = System.IO.Path.Combine(documentsPath, string.Format(\"photo_{0}.jpg\", Guid.NewGuid()));\r\n            File.WriteAllBytes(filePath, imageBytes);\r\n            imageView.Source = ImageSource.FromFile(filePath);\r\n        }"
            };
            BindingContext = viewModel;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            SaveAndLoadMethod();
            //LoadfromStreamMethod();
        }

        //Method to load directly from stream
        private void LoadfromStreamMethod()
        {
            //Loading from stream method without saving and loading
            byte[] imageBytes = Convert.FromBase64String(viewModel.Base64String);
            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                imageView.Source = ImageSource.FromStream(() => ms);
            }
        }


        //Method to save the stream locally and load into image obj
        private void SaveAndLoadMethod()
        {
            ////Saving locally and retrieving method
            byte[] imageBytes = Convert.FromBase64String(viewModel.Base64String);
            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            ////Image Format
            var filePath = System.IO.Path.Combine(documentsPath, string.Format("photo_{0}.jpg", Guid.NewGuid()));
            File.WriteAllBytes(filePath, imageBytes);
            imageView.Source = ImageSource.FromFile(filePath);
        }
    }
}