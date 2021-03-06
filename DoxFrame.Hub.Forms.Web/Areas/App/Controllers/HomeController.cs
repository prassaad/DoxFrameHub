using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DoxFrame.Hub.Web.Areas.Forms.Controllers
{
    
    [Area("App")]
    public class HomeController : Controller
    {

        public HomeController()
        {
        }


        [Authorize]
        public IActionResult Index(Guid ProjectId, Guid FormId, string Apptitle, string FormTitle)
        {
            ViewBag.ProjectId = ProjectId;
            ViewBag.FormId = FormId;
            ViewBag.AppTitle = Apptitle;
            ViewBag.FormTitle = FormTitle;
            return View();
        }
       
       
        [Authorize]
        public IActionResult DesignForm()
        {

            // Logic by form state
            // open designer by state like New or Edit
            //if (formState == (int)FormState.New)
            //    return ViewComponent("FormDesigner");
            //else
            return View();
        }

        [Authorize]
        [HttpGet]
        public JsonResult GetFormLayout()
        {
            var accessToken = HttpContext.GetTokenAsync("access_token");

            //var client1 = new RestClient("https://localhost:44343/api/forms");
            //var request1 = new RestRequest(Method.GET);
            //request1.AddHeader("content-type", "application/json");
            //request1.AddHeader("authorization", "Bearer " + accessToken.Result);
            //IRestResponse response1 = client1.Execute(request1);

             return Json("{No Result}");

        }

        [Authorize]
        [HttpGet]
      
        public IActionResult GetForm(int id)
        {
            try
            {
                var user = "Success with Id " + id;
                return Ok(user);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
    }
}
