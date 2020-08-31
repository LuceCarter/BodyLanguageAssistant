using System;
using System.Collections.Generic;
using BodyLangaugeAssistant.ViewModels;
using Xamarin.Forms;

namespace BodyLangaugeAssistant.Views
{
    public partial class AnalyseTextPage : ContentPage
    {
        public AnalyseTextPage()
        {
            InitializeComponent();
            BindingContext = new AnalyseTextPageViewModel();
        }
    }
}
