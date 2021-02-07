using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace VehicleMaintanence.Models
{
    public class Vehicle
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Year { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string Trim { get; set; }

        public string Engine { get; set; }
    }
}
