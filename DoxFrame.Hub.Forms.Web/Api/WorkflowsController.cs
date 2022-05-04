using DoxFrame.Hub.Core.ProjectAggregate;
using DoxFrame.Hub.Core.ProjectAggregate.Specifications;
using DoxFrame.Hub.SharedKernel;
using DoxFrame.Hub.SharedKernel.Interfaces;
using DoxFrame.Hub.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoxFrame.Hub.Web.Api
{
    public class WorkflowsController : BaseApiController
    {
        private readonly IRepository<Project> _repository;

        public WorkflowsController(IRepository<Project> repository)
        {
            _repository = repository;
        }

        // GET: api/Workflow
        [HttpGet("{projectId:Guid}/{workflowId}")]
        public async Task<IActionResult> GetById(Guid projectId, Guid workflowId)
        {
            var projectSpec = new ProjectByIdWithItemsSpec(projectId);
            var project = await _repository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            var workflow = project.Workflows.FirstOrDefault(workflow => workflow.Id == projectId);
            if (workflow == null) return NotFound("No such workflow.");

            return Ok(workflow);
        }

        // POST: api/workflow
        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] WorkflowsDTO request)
        {
            var projectSpec = new ProjectByIdSpec(request.ProjectId);
            var project = await _repository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            project.AddWorkflow(new Component() { ComponentType = "form", Title = request.Title, Workflow = new Workflow() { ProjectId = request.ProjectId, Title = request.Title, Name = request.Name }});

            try { 
             await  _repository.UpdateAsync(project);
            }
            catch(Exception ex)
            {
                return Json(new { success = false, error= ex.Message });

            }

            //var result = new ProcessDTO
            //{
            //    Id = createdProcess.Id,
            //    Title = createdProcess.Title
            //    Name = createdProcess.Name
            //};
            //return Ok();
            return Json(new { success = true });
         }

        // PATCH: api/Projects/{projectId}/inactive/{workflowId}
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] WorkflowsDTO request)
        {
            var projectSpec = new ProjectByIdWithItemsSpec(request.ProjectId);
            var project = await _repository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            var workflow = project.Workflows.FirstOrDefault(workflow => workflow.Id == request.Id);
            if (workflow == null) return NotFound("No such workflow.");

            try
            {
                // Set Data
                workflow.Title = request.Title;
                workflow.Key = request.Key;
                workflow.Name = request.Name;
                workflow.Update(workflow);

                await _repository.UpdateAsync(project);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });

            }
 
        }

        [HttpPost("updateworkflowmodellayout")]
        public async Task<IActionResult> UpdateProceeLayout([FromBody] UpdateWorkflowModelLayoutDTO request)
        {
            var projectSpec = new ProjectByIdWithItemsSpec(request.ProjectId);
            var project = await _repository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            var workflow = project.Workflows.FirstOrDefault(workflow => workflow.Id == request.WorkflowId);
            if (workflow == null) return NotFound("No such Workflow.");

            try
            {
                // Set Data
                var workflowRepo = new DoxFrame.Hub.Core.Services.WorkflowsRepository(_repository);
                workflow.Layout = workflowRepo.WorkflowModelLayoutToByteArray(request.Layout);
                workflow.Update(workflow);

                await _repository.UpdateAsync(project);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });

            }

        }


        // POST: 
        [HttpPost("remove")]
        public async Task<IActionResult> Remove([FromBody] RemoveWorkflowDTO request)
        {
            var projectSpec = new ProjectByIdWithItemsSpec(request.ProjectId);
            var project = await _repository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            var rmWorkflow = project.Workflows.FirstOrDefault(workflow => workflow.Id == request.WorkflowId);
            if (rmWorkflow == null) return NotFound("No such Workflow.");

            project.RemoveWorkflow(rmWorkflow);

            try
            {
                await _repository.UpdateAsync(project);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });

            }

            
        }


    }
}
