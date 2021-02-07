using System;
using System.Collections.Generic;
using System.Text;
using VehicleMaintanence.Models;
using Xamarin.Forms;

namespace VehicleMaintanence.ViewModels
{
    public class VehicleViewModel : BaseViewModel
    {
        public int Id { get; set; }

        public VehicleViewModel() { }

        public VehicleViewModel(Vehicle vehicle)
        {
            Id = vehicle.Id;
            _year = vehicle.Year;
            _make = vehicle.Make;
            _model = vehicle.Model;
            _trim = vehicle.Trim;
            _engine = vehicle.Engine;
        }

        private string _year;
        private string _make;
        private string _model;
        private string _trim;
        private string _engine;

        public string Year
        {
            get { return _year; }
            set
            {
                SetValue(ref _year, value);
                OnPropertyChanged(nameof(MyVehicle));
            }
        }

        public string Make
        {
            get { return _make; }
            set
            {
                SetValue(ref _make, value);
                OnPropertyChanged(nameof(MyVehicle));
            }
        }

        public string Model
        {
            get { return _model; }
            set
            {
                SetValue(ref _model, value);
                OnPropertyChanged(nameof(MyVehicle));
            }
        }

        public string Trim
        {
            get { return _trim; }
            set
            {
                SetValue(ref _trim, value);
                OnPropertyChanged(nameof(MyVehicle));
            }
        }

        public string Engine
        {
            get { return _engine; }
            set
            {
                SetValue(ref _engine, value);
                OnPropertyChanged(nameof(MyVehicle));
            }
        }

        public string MyVehicle
        {
            get { return $"{Year} {Make} {Model} {Trim} {Engine}"; }
        }

    }
}
