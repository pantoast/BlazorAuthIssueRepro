using BlazorAuthIssueRepro.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using BlazorAuthIssueRepro.Server.Models;

namespace BlazorAuthIssueRepro.Server.Controllers
{
    [Authorize(Roles = UserRoles.Role2)]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,
            UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get()
        {
            if (User == null)
            {
                _logger.LogInformation($"User is null");
            }
            else
            {
                string logMsg = $"User Data: Primary Identity: {User.Identity?.Name}; Claims:";
                foreach (var claim in User.Claims)
                {
                    if (claim != null)
                        logMsg += $"\n\tType: {claim.Type}; Value: {claim.Value}";
                }

                logMsg += "\tIdentities:";
                foreach (var identity in User.Identities)
                {
                    if (identity != null)
                        logMsg += $"\n\tName: {identity.Name}; IsAuthenticated: {identity.IsAuthenticated}; RoleClaimType: {identity.RoleClaimType}; NameClaimType: {identity.NameClaimType}; Label: {identity.Label}; AuthenticationType: {identity.AuthenticationType}";
                }

                _logger.LogInformation(logMsg);
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                var rng = new Random();
                return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
            }
            else
            {
                _logger.LogInformation($"User not found.");
                return NotFound();
            }
        }
    }
}
