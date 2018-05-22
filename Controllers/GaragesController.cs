using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Api.Data;
using Garage.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Garage.Api.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;

namespace Garage.Api.Controllers
{
    [Route("api/[Controller]")]
    public class GaragesController : Controller
    {
        private readonly GarageRepository _repository;
        private readonly GarageContext _db;

        private readonly UserManager<Manager> _userManager;

        public GaragesController(GarageContext db, GarageRepository repository, 
        UserManager<Manager> userManager)
        {
            
            _db = db;
            _repository = repository;
            _userManager = userManager;

        }

        [HttpGet]
        [Route("InUse/{username}/{id:int}")]
        public IActionResult GetInUse(int id)
        {
            return Ok(_repository.GetInUseSpaces(id));
        }

        [HttpGet]
        [Route("open/{username}/{id:int}")]
        public IActionResult GetOpen(int id)
        {
            return Ok(_repository.GetOpenSpaces(id));
        }

        [HttpGet]
        [Route("out/{username}/{id:int}")]
        public IActionResult GetOut(int id)
        {
            return Ok(_repository.GetOutSpaces(id));
        }

       
       [HttpGet("{username}")]
        public IActionResult Get(string username)
        {

            return Ok(_repository.GetGarages(username));
        }

        [HttpGet]
        [Route("spaces/{username}")]
        public IActionResult GetAllSpaces(string username)
        {
            return Ok(_repository.GetAllSpaces(username));
        }
        
        [HttpGet]
        [Route("spaces/{username}/{id:int}")]
        public IActionResult GetAllSpacesByGaragw(string username, int id)
        {
            return Ok(_repository.GetAllSpacesByGarage(username, id));
        }

        [HttpGet]
        [Route("spaces/{username}/{id:int}/{floor:int}")]
        public IActionResult GetAllSpacesByGarageAndFloor(string username, int id, int floor)
        {
            return Ok(_repository.GetAllSpacesByGarageAndFloor(username, id, floor));
        }

        [HttpPut]
        [Route("spaces/{id:int}")]
        public IActionResult ChangeState(int id)
        {
            return Ok(_repository.ChangeSpace(id));
        }

        
    }
}