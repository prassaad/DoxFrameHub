using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace DoxFrame.Hub.Web.Controllers
{
    public class TenantController : Controller
    {

        [Authorize]
        public IActionResult Welcome(Guid hubUserId)
        {
            ViewBag.HubUserId = hubUserId;
            return View();
        }



    }
}
