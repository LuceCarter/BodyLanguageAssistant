using System;
using System.Collections.Generic;
using BodyLangaugeAssistant.ViewModels;
using Xamarin.Forms;

namespace BodyLangaugeAssistant.Views
{
    public partial class AnalyseBodyLanguagePage : ContentPage
    {
        public AnalyseBodyLanguagePage()
        {
            InitializeComponent();
            BindingContext = new AnalyseBodyLanguagePageViewModel();
        }
    }
}
