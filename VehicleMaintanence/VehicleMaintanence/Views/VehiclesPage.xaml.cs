using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleMaintanence.Persistence;
using VehicleMaintanence.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VehicleMaintanence.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VehiclesPage : ContentPage
    {
        public VehiclesPage()
        {
            var vehicleStore = new SQLiteVehicleStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();

            ViewModel = new VehiclesPageViewModel(vehicleStore, pageService);

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            ViewModel.LoadDataCommand.Execute(null);
            base.OnAppearing();
        }

        void OnVehicleSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectVehicleCommand.Execute(e.SelectedItem);
        }

        public VehiclesPageViewModel ViewModel
        {
            get { return BindingContext as VehiclesPageViewModel; }
            set { BindingContext = value; }
        }
    }
}