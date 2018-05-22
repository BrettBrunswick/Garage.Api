using System;
using Microsoft.AspNetCore.Identity;

namespace Garage.Api.Models
{
    public class Manager : IdentityUser{

        public string Name { get; set; }
        public int SSN { get; set; }
        public DateTime HireDate { get; set; }

    }
}