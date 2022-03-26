using DoxFrame.Hub.Core.AccountAggregate;
using DoxFrame.Hub.Core.AccountAggregate.Specifications;
using DoxFrame.Hub.SharedKernel.Interfaces;
using DoxFrame.Hub.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DoxFrame.Hub.Web.Api
{
    public class HubUsersController : BaseApiController
    {
        private readonly IRepository<HubUser> _repository;

        public HubUsersController(IRepository<HubUser> repository)
        {
            _repository = repository;
        }

        // GET: api/HubUsers
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var hubUserDTOs = (await _repository.ListAsync())
                .Select(user => new HubUserDTO
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                    Mobile = user.Mobile 
                    
                })
                .ToList();

            return Ok();
        }

        // GET: api/Users
        [HttpGet("{email}")]
        public async Task<IActionResult> GetById(string email)
        {
            var hubUserSpec = new HubUserByUserEmailSpec(email);
            var user = await _repository.GetBySpecAsync(hubUserSpec);

            if (user == null)
            {
                return Json(new { success = true, data = "" });
            }

            var result = new HubUserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Mobile = user.Mobile,
               
            };

            return Json(new { success = true, data = result });
        }

        // POST: api/HubUsers
        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] CreateHubUserDTO request)
        {
            try {

                if (request.Type == "false") { request.Type = "individual"; } else { request.Type = "firm"; }
                var newHubUser = new HubUser(request.Name, request.Email, request.Mobile, request.Type);
                newHubUser.IsAccountAdmin = true;
                var createdUser = await _repository.AddAsync(newHubUser);

                var result = new HubUserDTO
                {
                    Id = createdUser.Id 
                };
                return Json(new { success = true, result = result });

            }
            catch (Exception ex) { return Json(new { success = false, result=ex.Message }); }
          
            
        }



    }
}
