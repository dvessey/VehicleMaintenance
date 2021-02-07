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
    public partial class VehiclesDetailPage : ContentPage
    {
        public VehiclesDetailPage(VehicleViewModel viewModel)
        {
            InitializeComponent();

            var vehicleStore = new SQLiteVehicleStore(DependencyService.Get<ISQLiteDb>());
            var pageService = new PageService();
            Title = (viewModel.MyVehicle == null) ? "New Vehicle" : "Edit Vehicle";
            BindingContext = new VehiclesDetailViewModel(viewModel ?? new VehicleViewModel(), vehicleStore, pageService);
        }
    }
}