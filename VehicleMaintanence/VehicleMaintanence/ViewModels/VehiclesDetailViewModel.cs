using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using VehicleMaintanence.Models;
using Xamarin.Forms;

namespace VehicleMaintanence.ViewModels
{
    public class VehiclesDetailViewModel
    {
        private readonly IVehicleStore _vehicleStore;
        private readonly IPageService _pageService;

        public Vehicle Vehicle { get; private set; }

        public ICommand SaveCommand { get; private set; }

        public VehiclesDetailViewModel(VehicleViewModel viewModel, IVehicleStore vehicleStore, IPageService pageService)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            _pageService = pageService;
            _vehicleStore = vehicleStore;

            SaveCommand = new Command(async () => await Save());

            Vehicle = new Vehicle
            {
                Id = viewModel.Id,
                Year = viewModel.Year,
                Make = viewModel.Make,
                Model = viewModel.Model,
                Trim = viewModel.Trim,
                Engine = viewModel.Engine
            };
        }

        async Task Save()
        {
            if (String.IsNullOrWhiteSpace(Vehicle.Year)
                && String.IsNullOrWhiteSpace(Vehicle.Make)
                && String.IsNullOrWhiteSpace(Vehicle.Model)
                && String.IsNullOrWhiteSpace(Vehicle.Trim)
                && String.IsNullOrWhiteSpace(Vehicle.Engine))
            {
                await _pageService.DisplayAlert("Error", "Please enter all fields.", "OK");
                return;
            }

            if (Vehicle.Id == 0)
            {
                await _vehicleStore.AddVehicle(Vehicle);
                MessagingCenter.Send(this, Events.VehicleAdded, Vehicle);
            }
            else
            {
                await _vehicleStore.UpdateVehicle(Vehicle);
                MessagingCenter.Send(this, Events.VehicleUpdated, Vehicle);
            }
            await _pageService.PopAsync();
        }
    }
}
