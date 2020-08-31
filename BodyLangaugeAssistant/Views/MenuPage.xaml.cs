using System;
using System.Collections.Generic;
using BodyLangaugeAssistant.ViewModels;
using Xamarin.Forms;

namespace BodyLangaugeAssistant.Views
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();
            BindingContext = new MenuPageViewModel(Navigation);
        }
    }
}
