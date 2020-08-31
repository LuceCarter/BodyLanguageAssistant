using System;
using System.Windows.Input;
using BodyLangaugeAssistant.Views;
using MvvmHelpers;
using Xamarin.Forms;

namespace BodyLangaugeAssistant.ViewModels
{
    public class MenuPageViewModel: BaseViewModel
    {
        

        private readonly INavigation navigation;
        public MenuPageViewModel(INavigation navigation)
        {
            this.navigation = navigation;
        }

        public ICommand AnalyseTextCommand
        {
            get => new Command(() =>
            {
                navigation.PushAsync(new NavigationPage(new AnalyseTextPage()));
            });
        }

        public ICommand AnalyseBodyLanguageCommand
        {
            get => new Command(() =>
            {
                navigation.PushAsync(new NavigationPage(new AnalyseBodyLanguagePage()));
            });
        }
    }
}
