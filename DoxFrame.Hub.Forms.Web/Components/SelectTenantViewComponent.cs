using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DoxFrame.Hub.Web.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace DoxFrame.Hub.Web.Components
{
    public class SelectTenantViewComponent : ViewComponent
    {
        private readonly IWebHostEnvironment _environment;
        public SelectTenantViewComponent(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        [Authorize]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                // parsing tenants from claims using context user.
                //ViewBag.UserTenantIds = HttpClientExtensions.GetUserTenantsByUser(HttpContext.User, HttpContext);
                return View("_SelectTenant");
            }
            catch (Exception ex) {
                ExceptionLogger.LogException(ex, _environment);
                return View("_Error.cshtml", ViewBag.Message = "No Data for page");
            }
           
        }
    }
}
