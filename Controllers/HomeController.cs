using DoxFrame.Hub.Core.AccountAggregate;
using DoxFrame.Hub.Core.AccountAggregate.Specifications;
using DoxFrame.Hub.SharedKernel.Interfaces;
using DoxFrame.Hub.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DoxFrame.Hub.Web.Extensions;

namespace DoxFrame.Hub.Web.Controllers
{
    public class HomeController : Controller
    {
        const string TenantUserProfileSessionKey = "_TenantUserProfile";
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository<HubUser> _userRepository;
        private readonly IRepository<Tenant> _tenantRepository;

        public HomeController(ILogger<HomeController> logger, IRepository<HubUser> userRepository, IRepository<Tenant> tenantRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
            _tenantRepository = tenantRepository;
        }

        [Authorize]
        public async Task<IActionResult> IndexAsync()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");

            //Check for Hub User Account

            //In Projects List View, An invited User cant do a remove project(An invited member can be restricted by Access Rights
            // Very Hub User Account Profile exist with email address, When redirect on No Profile with email

            var hubUserSpec = new HubUserByUserEmailSpec(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value);
            var user = await _userRepository.GetBySpecAsync(hubUserSpec);

            var authUser = new UserProfileViewModel()
            {
                Name = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value,
                EmailAddress = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
                ProfileImage = User.Claims.FirstOrDefault(c => c.Type == "picture")?.Value
            };

            // Redirect when no Hub User Record (First login step)
            if (user == null)
            {
                return RedirectToAction("Profile", "Account");
            }

            // Redirect when no Teant Record (After Profile step)
            //Check for first Teant to start development simlar way as Account process
            var tenantSpec = new TenantByIdWithProjectsSpec(user.Id);
            var tenant = await _tenantRepository.GetBySpecAsync(tenantSpec);
            if (tenant == null) {
                 
                return RedirectToAction("Welcome", "Tenant", new TenantViewModel() { HubUserId=user.Id });
            }

            //Finally the Profile and Tenat setup done
          
            // State Management Tenant and Hub User Profile
            if (tenant != null)
            {
                // When Teant(s) availabe get one to set in session for that tenat development
                var currTenantVwModel = new TenantUserProfileViewModel()
                {
                    HubUserId = user.Id,
                    TenantId = tenant.Id,
                    EmailAddress = user.Email,
                    Name = user.Name,
                    ProfileImage = user.ProfileImage,
                    DomainName = tenant.DomainName,
                    EnvironmentTag = tenant.EnvironmentTag,
                    TotalProjects = tenant.projects.Count()
                };

                ViewBag.TotalProjects = tenant.projects.Count();
                
                // Requires SessionExtensions .
                if (HttpContext.Session.Get<TenantUserProfileViewModel>(TenantUserProfileSessionKey) == default)
                {
                    HttpContext.Session.Set<TenantUserProfileViewModel>(TenantUserProfileSessionKey, currTenantVwModel);
                }
                return View(currTenantVwModel);
            }
            // In case reached here, there is some thing flaw to be analyzed
            return RedirectToAction("Error");

        }

     
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
