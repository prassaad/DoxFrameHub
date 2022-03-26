using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoxFrame.Hub.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("/api/forms/")]
        [Authorize]
        public IEnumerable<WeatherForecast> Get()
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

        [HttpGet]
        [Route("/api/token/")]
        public string Token()
        {
            var client = new RestClient("https://doxframe.us.auth0.com/oauth/token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", "{\"client_id\":\"Ytyv64csvDQjaarUCTTdSCQUNpS9ma0H\",\"client_secret\":\"jeaCD9YdNxfmZy9gD6DvxRJ6lz-pLkaVYBv-bECdUD6WbHJ8HR-W_eq3R2qyWgsz\",\"audience\":\"https://localhost:44343/api/forms\",\"grant_type\":\"client_credentials\"}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            dynamic data = JObject.Parse(response.Content);
            //ViewBag.access_token = data.access_token;



            var client1 = new RestClient("https://localhost:44346/Projects");
            var request1 = new RestRequest(Method.GET);
            request1.AddHeader("content-type", "application/json");
            request1.AddHeader("authorization", "Bearer " + data.access_token);
            IRestResponse response1 = client1.Execute(request1);

            return response1.Content;
        }

    }
}
