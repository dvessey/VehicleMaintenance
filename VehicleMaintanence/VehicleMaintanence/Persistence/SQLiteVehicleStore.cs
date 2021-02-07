using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VehicleMaintanence.Models;
using VehicleMaintanence.ViewModels;

namespace VehicleMaintanence.Persistence
{
    public class SQLiteVehicleStore : IVehicleStore
    {
        private SQLiteAsyncConnection _connection;

        public SQLiteVehicleStore(ISQLiteDb db)
        {
            _connection = db.GetConnection();
            _connection.CreateTableAsync<Vehicle>();
        }
        public async Task AddVehicle(Vehicle vehicle)
        {
            await _connection.InsertAsync(vehicle);
        }

        public async Task DeleteVehicle(Vehicle vehicle)
        {
            await _connection.DeleteAsync(vehicle);
        }

        public async Task<Vehicle> GetVehicle(int id)
        {
            return await _connection.FindAsync<Vehicle>(id);
        }

        public async Task<IEnumerable<Vehicle>> GetVehiclesAsync()
        {
            return await _connection.Table<Vehicle>().ToListAsync();
        }

        public async Task UpdateVehicle(Vehicle vehicle)
        {
            await _connection.UpdateAsync(vehicle);
        }
    }
}
