using DoxFrame.Hub.Core.AccountAggregate;
using DoxFrame.Hub.Core.AccountAggregate.Specifications;
using DoxFrame.Hub.Core.ProjectAggregate;
using DoxFrame.Hub.SharedKernel.Interfaces;
using DoxFrame.Hub.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DoxFrame.Hub.Web.Api
{
    public class TenantsController : BaseApiController
    {
        private readonly IRepository<Tenant> _repository;

        public TenantsController(IRepository<Tenant> repository)
        {
            _repository = repository;
        }

        // GET: api/Tenants
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var tenantDTOs = (await _repository.ListAsync())
                .Select(tenant => new TenantDTO
                {
                    Id = tenant.Id,
                    DomainName = tenant.DomainName,
                    Region = tenant.Region,
                    EnvironmentTag = tenant.EnvironmentTag 
                    
                })
                .ToList();

            return Ok();
        }

        // GET: api/Tenants
        [HttpGet("{HubUserId}")]
        public async Task<IActionResult> GetById(Guid hubUserId)
        {
            var tenantSpec = new TenantByHubUserIdSpec(hubUserId);
            var tenant = await _repository.GetBySpecAsync(tenantSpec);

            if (tenant == null)
            {
                return Json(new { success = true, data = "" });
            }

            var result = new TenantDTO
            {
                Id = tenant.Id,
                DomainName = tenant.DomainName,
                Region = tenant.Region,
                EnvironmentTag = tenant.EnvironmentTag

            };

            return Json(new { success = true, data = result });
        }

        // POST: api/Tenants
        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] CreateTenantDTO request)
        {
            try {
                
                var newTenant = new Tenant(request.DomainName, request.Region);
                newTenant.HubUserId = request.HubUserId;
                newTenant.EnvironmentTag = "Development";
                var createdTenant = await _repository.AddAsync(newTenant);

                var result = new TenantDTO
                {
                    Id = createdTenant.Id 
                };
                return Json(new { success = true, result = result });

            }
            catch (Exception ex) { return Json(new { success = false, result=ex.Message }); }
          
            
        }


        // Projects under Tenant code

        // POST: api/project/create
        [HttpPost("project/create")]
        public async Task<IActionResult> Post([FromBody] CreateProjectDTO request)
        {
            var tenantSpec = new TenantByIdWithHubUserSpec(request.HubUserId);
            var tenant = await _repository.GetBySpecAsync(tenantSpec);
            if (tenant == null) return NotFound("No such tenant");

            tenant.AddProject(new Project(request.ProjectName,request.Summary));

            try
            {
                await _repository.UpdateAsync(tenant);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });

            }
            return Json(new { success = true });
        }

        // POST: 
        [HttpPost("project/remove")]
        public async Task<IActionResult> Remove([FromBody] RemoveProjectDTO request)
        {
            var tenantSpec = new TenantByIdSpec(request.TenantId);
            var tenant = await _repository.GetBySpecAsync(tenantSpec);
            if (tenant == null) return NotFound("No such tenant");

            var rmProject = tenant.projects.FirstOrDefault(project => project.Id == request.ProjectId);
            if (rmProject == null) return NotFound("No such project.");

            tenant.RemoveProject(rmProject);

            try
            {
                await _repository.UpdateAsync(tenant);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });

            }


        }

    }
}
