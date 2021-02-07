using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VehicleMaintanence.Models;
using VehicleMaintanence.Views;
using Xamarin.Forms;

namespace VehicleMaintanence.ViewModels
{
    public class VehiclesPageViewModel : BaseViewModel
    {
        private VehicleViewModel _selectedVehicle;
        private IVehicleStore _vehicleStore;
        private IPageService _pageService;

        private bool _isDataLoaded;

        public ObservableCollection<VehicleViewModel> Vehicles { get; private set; }
            = new ObservableCollection<VehicleViewModel>();

        public VehicleViewModel SelectedVehicle
        {
            get { return _selectedVehicle; }
            set { SetValue(ref _selectedVehicle, value); }
        }

        public ICommand LoadDataCommand { get; private set; }
        public ICommand AddVehicleCommand { get; private set; }
        public ICommand SelectVehicleCommand { get; private set; }
        public ICommand DeleteVehicleCommand { get; private set; }

        public VehiclesPageViewModel(IVehicleStore vehicleStore, IPageService pageService)
        {
            _vehicleStore = vehicleStore;
            _pageService = pageService;

            LoadDataCommand = new Command(async () => await LoadData());
            AddVehicleCommand = new Command(async () => await AddVehicle());
            SelectVehicleCommand = new Command<VehicleViewModel>(async v => await SelectVehicle(v));
            DeleteVehicleCommand = new Command<VehicleViewModel>(async v => await DeleteVehicle(v));

            MessagingCenter.Subscribe<VehiclesDetailViewModel, Vehicle>(this, Events.VehicleAdded, OnVehicleAdded);

            MessagingCenter.Subscribe<VehiclesDetailViewModel, Vehicle>(this, Events.VehicleUpdated, OnVehicleUpdated);
        }

        private void OnVehicleAdded(VehiclesDetailViewModel source, Vehicle vehicle)
        {
            Vehicles.Add(new VehicleViewModel(vehicle));
        }

        private void OnVehicleUpdated(VehiclesDetailViewModel source, Vehicle vehicle)
        {
            var vehicleInList = Vehicles.Single(v => v.Id == vehicle.Id);

            vehicleInList.Id = vehicle.Id;
            vehicleInList.Year = vehicle.Year;
            vehicleInList.Make = vehicle.Make;
            vehicleInList.Model = vehicle.Model;
            vehicleInList.Trim = vehicle.Trim;
            vehicleInList.Engine = vehicle.Engine;
        }

        private async Task LoadData()
        {
            if (_isDataLoaded)
                return;

            _isDataLoaded = true;
            var vehicles = await _vehicleStore.GetVehiclesAsync();
            foreach (var vehicle in vehicles)
                Vehicles.Add(new VehicleViewModel(vehicle));
        }

        private async Task AddVehicle()
        {
            await _pageService.PushAsync(new VehiclesDetailPage(new VehicleViewModel()));
        }

        private async Task SelectVehicle(VehicleViewModel vehicle)
        {
            if (vehicle == null)
                return;

            SelectedVehicle = null;
            await _pageService.PushAsync(new VehiclesDetailPage(vehicle));
        }

        private async Task DeleteVehicle(VehicleViewModel vehicleViewModel)
        {
            if(await _pageService.DisplayAlert("Warning", $"Are you sure you want to delete {vehicleViewModel.MyVehicle}?", "Yes", "No"))
            {
                Vehicles.Remove(vehicleViewModel);

                var vehicle = await _vehicleStore.GetVehicle(vehicleViewModel.Id);
                await _vehicleStore.DeleteVehicle(vehicle);
            }
        }
    }
}
