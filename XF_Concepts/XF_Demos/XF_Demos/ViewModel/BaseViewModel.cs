﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace XF_Demos.ViewModel
{
    //Base view model Class
    public class BaseViewModel : INotifyPropertyChanged
    {
        string title;
        string codeDesciption;
        string codeSnippet;
        string dlls;

        public string SampleTitle
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
                OnPropertyChanged(SampleTitle);
            }
        }

        public string CodeDescription
        {
            get
            {
                return codeDesciption;
            }
            set
            {
                codeDesciption = value;
                OnPropertyChanged(CodeDescription);
            }
        }

        public string DLLUsed
        {
            get
            {
                return dlls;
            }
            set
            {
                dlls = value;
                OnPropertyChanged(DLLUsed);
            }
        }

        public string CodeSnippet
        {
            get
            {
                return codeSnippet;
            }
            set
            {
                codeSnippet = value;
                OnPropertyChanged(CodeSnippet);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
