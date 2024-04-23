namespace XF_Demos.ViewModel
{
    public class Base64ToImageViewModel : BaseViewModel
    {
        string base64string;
        private string placeHolderString;

        public string Base64String
        {
            get
            {
                return base64string;
            }
            set
            {
                base64string = value;
                OnPropertyChanged(Base64String);
            }
        }
        
        public string PlaceHolderString
        {
            get
            {
                return placeHolderString;
            }
            set
            {
                placeHolderString = value;
                OnPropertyChanged(PlaceHolderString);
            }
        }
    }
}
