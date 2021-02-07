using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleMaintanence.Models;

namespace VehicleMaintanence.ViewModels
{
    public interface IVehicleStore
    {
        Task<IEnumerable<Vehicle>> GetVehiclesAsync();

        Task<Vehicle> GetVehicle(int id);
        Task AddVehicle(Vehicle vehicle);
        Task UpdateVehicle(Vehicle vehicle);
        Task DeleteVehicle(Vehicle vehicle);

    }
}
