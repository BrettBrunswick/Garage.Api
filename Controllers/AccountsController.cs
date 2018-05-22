using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Garage.Api.Data;
using Garage.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Garage.Api.Models.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;


namespace Accounts.Api.Controllers
{
    public class AccountsController : Controller
    {
        private readonly GarageContext db;
        private readonly ILogger<AccountsController> _logger;

        private readonly UserManager<Manager> _userManager;

        private readonly SignInManager<Manager> _signInManager;

        private readonly IConfiguration _config;

        public AccountsController(GarageContext db, ILogger<AccountsController> logger,
        UserManager<Manager> userManager, SignInManager<Manager> signInManager, IConfiguration config)

        {
            
            this.db = db;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _config = config;

        }

        [Route("api/Accounts/Login")]
        [HttpPost]
        public async Task<IActionResult> Login ([FromBody] LoginViewModel model) 
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                    if (result.Succeeded)
                    {
                        //Create token for the user
                        var claims = new []
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, new Guid().ToString())
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
                        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                        var token = new JwtSecurityToken(
                            _config["Tokens:Issuer"],
                            _config["Tokens:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddMinutes(30),
                            signingCredentials: creds
                        );

                        var results = new 
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo,
                            name = user.Name
                            
                        };

                        return Created("", results);
                    }
                }
            }

            return BadRequest();
        }

    }
}