using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Garage.Api.Models;

namespace Garage.Api.Data
{
    public class GarageRepository
    {
        private readonly GarageContext _db;
        private readonly UserManager<Manager> _userManager;

        public GarageRepository(GarageContext db, UserManager<Manager> userManager) 
        {
            _db = db;
            _userManager = userManager;
        }

        public IEnumerable<ParkingSpace> GetInUseSpaces(int garageID) {
            
            return _db.ParkingSpaces
                    .Where(i => i.Garage.ID == garageID)
                    .Where(i => i.Status == "inuse")
                    .OrderBy(f => f.Floor)
                    .ToList();
        }

        public IEnumerable<ParkingSpace> GetOutSpaces(int garageID) {
            
            return _db.ParkingSpaces
                    .Where(i => i.Garage.ID == garageID)
                    .Where(i => i.Status == "out")
                    .OrderBy(f => f.Floor)
                    .ToList();
        }

        public IEnumerable<ParkingSpace> GetOpenSpaces(int garageID) {
            
            return _db.ParkingSpaces
                    .Where(i => i.Garage.ID == garageID)
                    .Where(i => i.Status == "open")
                    .OrderBy(f => f.Floor)
                    .ToList();
        }

        public IEnumerable<ParkingSpace> GetAllSpaces(string username) {

            
            
            return _db.ParkingSpaces
                    .Where(p => p.Manager.UserName == username)
                    .Include(e => e.Garage)
                    .OrderBy(f => f.Floor).OrderBy(f => f.Garage.ID)
                    .ToList();
        }

        public IEnumerable<ParkingSpace> GetAllSpacesByGarage(string username, int id) {

            
            
            return _db.ParkingSpaces
                    .Where(p => p.Manager.UserName == username)
                    .Where(i => i.Garage.ID == id)
                    .Include(e => e.Garage)
                    .OrderBy(f => f.Floor).OrderBy(f => f.Garage.ID)
                    .ToList();
        }

        public IEnumerable<ParkingSpace> GetAllSpacesByGarageAndFloor(string username, int id, int floor) {

            return _db.ParkingSpaces
                    .Where(p => p.Manager.UserName == username)
                    .Where(i => i.Garage.ID == id)
                    .Where(f => f.Floor == floor)
                    .Include(e => e.Garage)
                    .OrderBy(f => f.ID)
                    .ToList();
        }

        public ParkingSpace ChangeSpace(int id) {

            var parkingspace = _db.ParkingSpaces.FirstOrDefault(x => x.ID == id);
            var currentState = parkingspace.Status;

            if (currentState == "open") {
                parkingspace.Status = "out";
                _db.ParkingSpaces.Update(parkingspace);
                _db.SaveChanges();
            }

            if (currentState == "out") {
                parkingspace.Status = "open";
                _db.ParkingSpaces.Update(parkingspace);
                _db.SaveChanges();
            }
            
            return parkingspace;
        }


        public IEnumerable<ParkingGarage> GetGarages(string username) {
            
            
            return _db.Garages
                    .Where(p => p.Manager.UserName == username)
                    .ToList();
        }

        public void AddEntity (object model) {
            _db.Add(model);
        }

        public bool SaveAll(){
            return _db.SaveChanges() > 0;
        }
    }
}