using DoxFrame.Client.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DoxFrame.Client.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> IndexAsync()
        {
            //var client = new RestClient("https://doxframe.us.auth0.com/oauth/token");
            //var request = new RestRequest(Method.POST);
            //request.AddHeader("content-type", "application/json");
            //request.AddParameter("application/json", "{\"client_id\":\"rx0RTRrS2ubyCkF1vJ9Ot3Cj4sVdSUNf\",\"client_secret\":\"7FVLzPDJbyXpLkgz00Kvd-OBKB_slT85Dvj3idlNRlnn0TKcJ1wY4LM4eOC_lJ-o\",\"audience\":\"https://doxframe.us.auth0.com/api/v2/\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);

            //dynamic data = JObject.Parse(response.Content);
            //ViewBag.access_token = data.access_token;


            //var client1 = new RestClient("https://localhost:44302/api/forms/");
            //var request1 = new RestRequest(Method.GET);
            //request.AddHeader("authorization", "Bearer "+ data.access_token);
            //IRestResponse response1 = client1.Execute(request1);
            //ViewBag.api_data = response1.Content;
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            ViewBag.access_token = accessToken;

            return View();
        }

        public IActionResult PrivacyAsync()
        {

            var client = new RestClient("https://doxframe.us.auth0.com/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\"client_id\":\"MsVrAEf7zGjaY9BaUdhxOYwKKNolw9VV\",\"client_secret\":\"KCiuyASyXVo4kJ_ysYfxMQXjHzmoUi_dRtEY7CoKWsYoTO7c7I19Vz79_2LCCqdE\",\"audience\":\"https://doxframe.us.auth0.com/api/v2/\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            dynamic data = JObject.Parse(response.Content);
            ViewBag.access_token = data.access_token;



            var client1 = new RestClient("https://localhost:44302/api/forms/");
            var request1 = new RestRequest(Method.GET);
            request1.AddHeader("content-type", "application/json");
            request1.AddHeader("authorization", "Bearer "+ data.access_token);
            IRestResponse response1 = client1.Execute(request1);

          
            ViewBag.api_data = response1.Content;
            
             
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
