using DoxFrame.Hub.Core.ProjectAggregate;
using DoxFrame.Hub.Core.ProjectAggregate.Specifications;
using DoxFrame.Hub.SharedKernel.Interfaces;
using DoxFrame.Hub.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoxFrame.Hub.Web.Api
{
    public class FormsController : BaseApiController
    {
        private readonly IRepository<Project> _repository;

        public FormsController(IRepository<Project> repository)
        {
            _repository = repository;
        }

        // GET: api/Forms
        [HttpGet("{projectId:Guid}/{formId}")]
        public async Task<IActionResult> GetById(Guid projectId, Guid formId)
        {
            var projectSpec = new ProjectByIdWithItemsSpec(projectId);
            var project = await _repository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            var form = project.Forms.FirstOrDefault(form => form.Id == formId);
            if (form == null) return NotFound("No such form.");

            return Ok(form);
        }
        // GET: api/Forms
        [HttpGet("{projectId:Guid}/{formId}/FormLayout")]
        public async Task<IActionResult> GetFormLayoutById(Guid projectId, Guid formId)
        {
            var projectSpec = new ProjectByIdWithItemsSpec(projectId);
            var project = await _repository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            var form = project.Forms.FirstOrDefault(form => form.Id == formId);
            if (form == null) return NotFound("No such form.");

           
              // get encode fromLayout design to Json
             var formsRepo = new DoxFrame.Hub.Core.Services.FormsRepository(_repository);
             var formLayout = (string)formsRepo.FormLayoutToJson(form.Layout);


            //return Json(new { layout = formLayout });
            return Ok(formLayout);
        }

        // POST: api/Forms
        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] FormDTO request)
        {
            var projectSpec = new ProjectByIdSpec(request.ProjectId);
            var project = await _repository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            project.AddForm(new Form() { ProjectId=request.ProjectId,  Title = request.Title, OperationType = request.OperationType });

            try { 
             await  _repository.UpdateAsync(project);
            }
            catch(Exception ex)
            {
                return Json(new { success = false, error= ex.Message });

            }

            //var result = new FormDTO
            //{
            //    Id = createdForm.Id,
            //    Title = createdForm.Title
            //};
            //return Ok();
            return Json(new { success = true });
         }

        // PATCH: api/Projects/{projectId}/inactive/{formId}
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] FormDTO request)
        {
            var projectSpec = new ProjectByIdWithItemsSpec(request.ProjectId);
            var project = await _repository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            var form = project.Forms.FirstOrDefault(form => form.Id == request.Id);
            if (form == null) return NotFound("No such form.");

            try
            {
                // Set Data
                form.Title = request.Title;
                form.Key = request.FormKey;
                form.Description = request.Description;
                form.OperationType = request.OperationType;
                form.RequestMethod = request.RequestMethod;
                form.RequestUri = request.RequestUri;
                form.isPublished = request.IsPublished;
                form.isActive = request.IsActive;

                form.Update(form);

                await _repository.UpdateAsync(project);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });

            }
 
        }

        [HttpPost("updateformlayout")]
        public async Task<IActionResult> UpdateFormLayout([FromBody] UpdateFormLayoutDTO request)
        {
            var projectSpec = new ProjectByIdWithItemsSpec(request.ProjectId);
            var project = await _repository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            var form = project.Forms.FirstOrDefault(form => form.Id == request.FormId);
            if (form == null) return NotFound("No such form.");

            try
            {
                // Set Data
                var formsRepo = new DoxFrame.Hub.Core.Services.FormsRepository(_repository);
                form.Layout = formsRepo.FormLayoutToByteArray(request.Layout);
                form.Update(form);

                await _repository.UpdateAsync(project);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });

            }

        }


        // PATCH: api/Projects/{projectId}/inactive/{formId}
        [HttpPatch("{projectId:Guid}/{formId}/inactive")]
        public async Task<IActionResult> Inactive(Guid projectId, Guid formId)
        {
            var projectSpec = new ProjectByIdWithItemsSpec(projectId);
            var project = await _repository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            var form = project.Forms.FirstOrDefault(form => form.Id == formId);
            if (form == null) return NotFound("No such form.");

            form.MarkInactive();
            await _repository.UpdateAsync(project);

            return Ok();
        }
        // POST: 
        [HttpPost("remove")]
        public async Task<IActionResult> Remove([FromBody] RemoveFormDTO request)
        {
            var projectSpec = new ProjectByIdWithItemsSpec(request.ProjectId);
            var project = await _repository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            var rmForm = project.Forms.FirstOrDefault(form => form.Id == request.FormId);
            if (rmForm == null) return NotFound("No such form.");

            project.RemoveForm(rmForm);

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
