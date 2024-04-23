using System;
using System.Collections.Generic;

using Xamarin.Forms;
using XF_Demos.ViewModel;

namespace XF_Demos
{	
	public partial class BaseToPDF : ContentPage
	{
		Base64ToPDFViewModel base64ToPDFViewModel;
		public BaseToPDF (string pageTitle)
		{
			InitializeComponent ();
            base64ToPDFViewModel = new Base64ToPDFViewModel
            {
                SampleTitle = pageTitle
            };
            this.BindingContext = base64ToPDFViewModel;
		}
	}
}

