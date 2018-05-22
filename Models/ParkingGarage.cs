using System;
using Microsoft.AspNetCore.Identity;

namespace Garage.Api.Models
{
    public class ParkingGarage {

        public int ID { get; set; }
        public Manager Manager { get; set; }
        public int Floors { get; set; }

        public string Address { get; set; }


    }
}