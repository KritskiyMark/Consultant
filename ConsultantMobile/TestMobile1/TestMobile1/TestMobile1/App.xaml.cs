using System;
using TestMobile1.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestMobile1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new StartPage());
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
