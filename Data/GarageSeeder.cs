//This file seeds our database with simple data.
//Called at startup only when the app is in development mode.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Garage.Api.Data;
using Garage.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Garage.Api.Data
{
    public class GarageSeeder {
        private readonly GarageContext _db;
        private readonly UserManager<Manager> _userManager;

        public GarageSeeder (GarageContext db, UserManager<Manager> userManager) {
            _db = db;
            _userManager = userManager;
        }

        public async Task Seed() {
            
            _db.Database.EnsureCreated();

            var user = await _userManager.FindByEmailAsync("brett@brett.com");

            var user2 = await _userManager.FindByEmailAsync("sssss@brett.com");
            

            //if (user == null)
            //{
                //seeding simple user data into database
            /*        user = new Manager {
                    UserName = "brettbrunswick",
                    Email = "brett@brett.com",
                    Name = "Brett",
                    SSN = 123456789,
                    HireDate = DateTime.Now
                };


                user2 = new Manager {
                    UserName = "jake",
                    Email = "sssss@brett.com",
                    Name = "Jake",
                    SSN = 123456289,
                    HireDate = DateTime.Now
                };


                //var result = await _userManager.CreateAsync(user, "P@ssword1!");
                //var result2 = await _userManager.CreateAsync(user2, "P@ssword1!");
                //if(result != IdentityResult.Success) {
                  //  throw new InvalidOperationException("Failed to create default user");
                //}


                var garage = new ParkingGarage() {
                ID = 1,
                Manager = user,
                Floors = 5,
                Address = "123 Apple Street"
                };

               */ var garage3 = new ParkingGarage() {
                ID = 4,
                Manager = user2,
                Floors = 5,
                Address = "258 Buckeye Drive"
                };

                /*
            var space1 = new ParkingSpace() {
                Garage = garage,
                Manager = user,
                ID = 1,
                Floor = 1,
                Status = "open"
                };

                var garage2 = new ParkingGarage() {
                ID = 2,
                Manager = user,
                Floors = 3,
                Address = "321 Pear Street"
                };


            var space2 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 2,
                Floor = 3,
                Status = "open"
                };

                var space3 = new ParkingSpace() {
                Garage = garage,
                Manager = user,
                ID = 3,
                Floor = 1,
                Status = "out"
                };

                var space4 = new ParkingSpace() {
                Garage = garage,
                Manager = user,
                ID = 4,
                Floor = 1,
                Status = "out"
                };

                var space5 = new ParkingSpace() {
                Garage = garage,
                Manager = user,
                ID = 5,
                Floor = 3,
                Status = "out"
                };

                var space6 = new ParkingSpace() {
                Garage = garage,
                Manager = user,
                ID = 6,
                Floor = 3,
                Status = "inuse"
                };

                var space7 = new ParkingSpace() {
                Garage = garage,
                Manager = user,
                ID = 7,
                Floor = 3,
                Status = "open"
                };

                var space8 = new ParkingSpace() {
                Garage = garage,
                Manager = user,
                ID = 8,
                Floor = 1,
                Status = "out"
                };

                var space9 = new ParkingSpace() {
                Garage = garage,
                Manager = user,
                ID = 9,
                Floor = 1,
                Status = "out"
                };

                var space10 = new ParkingSpace() {
                Garage = garage,
                Manager = user,
                ID = 10,
                Floor = 1,
                Status = "out"
                };

                var space11 = new ParkingSpace() {
                Garage = garage,
                Manager = user,
                ID = 11,
                Floor = 1,
                Status = "open"
                };

                var space12 = new ParkingSpace() {
                Garage = garage,
                Manager = user,
                ID = 12,
                Floor = 1,
                Status = "open"
                };

                var space13 = new ParkingSpace() {
                Garage = garage,
                Manager = user,
                ID = 13,
                Floor = 4,
                Status = "open"
                };

                var space14 = new ParkingSpace() {
                Garage = garage,
                Manager = user,
                ID = 14,
                Floor = 3,
                Status = "inuse"
                };

                var space15 = new ParkingSpace() {
                Garage = garage,
                Manager = user,
                ID = 15,
                Floor = 5,
                Status = "open"
                };

                var space16 = new ParkingSpace() {
                Garage = garage,
                Manager = user,
                ID = 16,
                Floor = 4,
                Status = "inuse"
                };

                var space17 = new ParkingSpace() {
                Garage = garage,
                Manager = user,
                ID = 17,
                Floor = 1,
                Status = "open"
                };

                var space18 = new ParkingSpace() {
                Garage = garage,
                Manager = user,
                ID = 18,
                Floor = 1,
                Status = "open"
                };

                var space19 = new ParkingSpace() {
                Garage = garage,
                Manager = user,
                ID = 19,
                Floor = 4,
                Status = "inuse"
                };

                var space20 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 20,
                Floor = 1,
                Status = "open"
                };

                var space21 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 21,
                Floor = 3,
                Status = "open"
                };

                var space22 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 22,
                Floor = 1,
                Status = "open"
                };

                var space23 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 23,
                Floor = 1,
                Status = "open"
                };

                var space24 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 24,
                Floor = 1,
                Status = "open"
                };

                var space25 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 25,
                Floor = 1,
                Status = "open"
                };

                var space26 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 26,
                Floor = 1,
                Status = "open"
                };

                var space27 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 27,
                Floor = 1,
                Status = "inuse"
                };

                var space28 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 28,
                Floor = 2,
                Status = "open"
                };

                var space29 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 29,
                Floor = 2,
                Status = "out"
                };

                var space30 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 30,
                Floor = 2,
                Status = "open"
                };

                var space31 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 31,
                Floor = 2,
                Status = "out"
                };

                var space32 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 32,
                Floor = 2,
                Status = "open"
                };

                var space33 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 33,
                Floor = 3,
                Status = "inuse"
                };

                var space34 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 34,
                Floor = 3,
                Status = "open"
                };

                var space35 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 35,
                Floor = 1,
                Status = "open"
                };

                var space36 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 36,
                Floor = 1,
                Status = "open"
                };

                var space37 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 37,
                Floor = 1,
                Status = "inuse"
                };

                var space38 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 38,
                Floor = 2,
                Status = "inuse"
                };

                var space39 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 39,
                Floor = 3,
                Status = "inuse"
                };

                var space40 = new ParkingSpace() {
                Garage = garage2,
                Manager = user,
                ID = 40,
                Floor = 2,
                Status = "out"
                };

                var space41 = new ParkingSpace() {
                Garage = garage3,
                Manager = user2,
                ID = 41,
                Floor = 3,
                Status = "open"
                };

                var space42 = new ParkingSpace() {
                Garage = garage3,
                Manager = user2,
                ID = 42,
                Floor = 1,
                Status = "open"
                };

                var space43 = new ParkingSpace() {
                Garage = garage3,
                Manager = user2,
                ID = 43,
                Floor = 2,
                Status = "out"
                };

                var space44 = new ParkingSpace() {
                Garage = garage3,
                Manager = user2,
                ID = 44,
                Floor = 1,
                Status = "inuse"
                };

                var space45 = new ParkingSpace() {
                Garage = garage3,
                Manager = user2,
                ID = 45,
                Floor = 2,
                Status = "inuse"
                };

                var space46 = new ParkingSpace() {
                Garage = garage3,
                Manager = user2,
                ID = 46,
                Floor = 3,
                Status = "inuse"
                };

                var space47 = new ParkingSpace() {
                Garage = garage3,
                Manager = user2,
                ID = 47,
                Floor = 2,
                Status = "out"
                };
                */

                var space48 = new ParkingSpace() {
                Garage = garage3,
                Manager = user2,
                ID = 48,
                Floor = 3,
                Status = "inuse"
                };

                var space49 = new ParkingSpace() {
                Garage = garage3,
                Manager = user2,
                ID = 49,
                Floor = 1,
                Status = "open"
                };

                var space50 = new ParkingSpace() {
                Garage = garage3,
                Manager = user2,
                ID = 50,
                Floor = 2,
                Status = "inuse"
                };

                var space51 = new ParkingSpace() {
                Garage = garage3,
                Manager = user2,
                ID = 51,
                Floor = 3,
                Status = "out"
                };
                


               /* _db.Garages.Add(garage);
                _db.Garages.Add(garage2);
                _db.Garages.Add(garage3);

                _db.ParkingSpaces.Add(space1);
                _db.ParkingSpaces.Add(space2);
                _db.ParkingSpaces.Add(space3);
                _db.ParkingSpaces.Add(space4);
                _db.ParkingSpaces.Add(space5);
                _db.ParkingSpaces.Add(space6);
                _db.ParkingSpaces.Add(space7);
                _db.ParkingSpaces.Add(space8);
                _db.ParkingSpaces.Add(space9);
                _db.ParkingSpaces.Add(space10);
                _db.ParkingSpaces.Add(space11);
                _db.ParkingSpaces.Add(space12);
                _db.ParkingSpaces.Add(space13);
                _db.ParkingSpaces.Add(space14);
                _db.ParkingSpaces.Add(space15);
                _db.ParkingSpaces.Add(space16);
                _db.ParkingSpaces.Add(space17);
                _db.ParkingSpaces.Add(space18);
                _db.ParkingSpaces.Add(space19);
                _db.ParkingSpaces.Add(space20);
                _db.ParkingSpaces.Add(space21);
                _db.ParkingSpaces.Add(space22);
                _db.ParkingSpaces.Add(space23);
                _db.ParkingSpaces.Add(space24);
                _db.ParkingSpaces.Add(space25);
                _db.ParkingSpaces.Add(space26);
                _db.ParkingSpaces.Add(space27);
                _db.ParkingSpaces.Add(space28);
                _db.ParkingSpaces.Add(space29);
                _db.ParkingSpaces.Add(space30);
                _db.ParkingSpaces.Add(space31);
                _db.ParkingSpaces.Add(space32);
                _db.ParkingSpaces.Add(space33);
                _db.ParkingSpaces.Add(space34);
                _db.ParkingSpaces.Add(space35);
                _db.ParkingSpaces.Add(space36);
                _db.ParkingSpaces.Add(space37);
                _db.ParkingSpaces.Add(space38);
                _db.ParkingSpaces.Add(space39);
                _db.ParkingSpaces.Add(space40);
                _db.ParkingSpaces.Add(space41);
                _db.ParkingSpaces.Add(space42);
                 _db.ParkingSpaces.Add(space43);
                _db.ParkingSpaces.Add(space44);
                 _db.ParkingSpaces.Add(space45);
                _db.ParkingSpaces.Add(space46);
                _db.ParkingSpaces.Add(space47);
                */

                _db.ParkingSpaces.Add(space48);
                _db.ParkingSpaces.Add(space49);
                _db.ParkingSpaces.Add(space50);
                _db.ParkingSpaces.Add(space51);

                _db.SaveChanges();
            //}
            
        }
    }
}