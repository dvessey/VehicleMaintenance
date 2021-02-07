using System;
using VehicleMaintanence.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VehicleMaintanence
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new VehiclesPage());
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
