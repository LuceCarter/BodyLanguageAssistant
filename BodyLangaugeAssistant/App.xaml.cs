using System;
using Xamarin.Forms;
using BodyLangaugeAssistant.Views;


[assembly: ExportFont("WorkSans.ttf", Alias ="WorkSans")]
namespace BodyLangaugeAssistant
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MenuPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
