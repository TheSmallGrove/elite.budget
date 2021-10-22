using Elite.Budget.Mobile.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elite.Budget.Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            var migrator = new Migrator();
            migrator.Upgrade();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
