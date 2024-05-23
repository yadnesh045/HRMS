using HRMS.Models.ViewModels;
using HRMS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using HRMS.Models;
using System.Diagnostics;

namespace HRMS.Controllers
{
    public class LinkedInController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly LinkedInService _linkedInService;
        private readonly ILogger<LinkedInController> _logger;

        public LinkedInController(IConfiguration configuration, LinkedInService linkedInService, ILogger<LinkedInController> logger)
        {
            _configuration = configuration;
            _linkedInService = linkedInService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult LinkedInLogin()
        {
            var authorizationEndpoint = _configuration["LinkedIn:AuthorizationEndpoint"];
            var clientId = _configuration["LinkedIn:ClientId"];
            var redirectUri = Uri.EscapeDataString(_configuration["LinkedIn:RedirectUri"]);
            var state = Guid.NewGuid().ToString();

            var url = $"{authorizationEndpoint}?response_type=code&client_id={clientId}&redirect_uri={redirectUri}&state={state}&scope=w_member_social";
            return Redirect(url);
        }

        [HttpGet]
        public async Task<IActionResult> LinkedInCallback(string code, string state)
        {
            if (string.IsNullOrEmpty(code))
            {
                return BadRequest("Authorization code not found.");
            }

            try
            {
                var accessToken = await _linkedInService.GetAccessTokenAsync(code);
                TempData["AccessToken"] = accessToken;
                return RedirectToAction("PostJob");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting LinkedIn access token.");
                return View("Error", new ErrorViewModel { Message = "Error retrieving access token from LinkedIn." });
            }
        }

        [HttpGet]
        public IActionResult PostJob()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> PostJob(JobViewModel model)
        {
            var accessToken = "AQUFIWryW1trhZjLdxqUlb-gU9pCAnMsWpCdsNOMzhOeh3-XD4SY9P5pzOrBcIH8RuZmfqCcGiUFYUKp1L0IpSfyealgy8Reh4vseI9MNFiiLo1yc3TxxkhmwczAkqManVVodLSGyl-yEyBx1T9yN68YlEp0JSRIQmiQ67vZD-7uofpF1Q_3NVsf7FQw07NXCL2n5gk8eIJZ2h9y3W9gz18VCiyUrm2vpcTQb1KP8IquFdNqotKlD4GaoLZRAQnbSwGcscFMUBsw9GShUjvGx0eYzbD5e7rNzyu1zhlfRwyc60J3GwokPjmGbW9al4hjRFv69lA0R0gin9nvoepB44cYY7O4Rg";
            if (accessToken == null)
            {
                return RedirectToAction("LinkedInLogin");
            }

            try
            {
                var jobDetailsJson = Newtonsoft.Json.JsonConvert.SerializeObject(model);
                await _linkedInService.PostJobAsync(accessToken, jobDetailsJson);
                return RedirectToAction("JobPosted");
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "Error posting job to LinkedIn.");
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier, Message = ex.Message });

            }
        }

        [HttpGet]
        public IActionResult JobPosted()
        {
            return View();
        }
    }
}
