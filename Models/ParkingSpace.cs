using System;
using Microsoft.AspNetCore.Identity;

namespace Garage.Api.Models
{
    public class ParkingSpace {

        public ParkingGarage Garage { get; set; }
        public int ID { get; set; }
        public int Floor { get; set; }
        public string Status { get; set; }

        public Manager Manager { get; set; }

    }
}