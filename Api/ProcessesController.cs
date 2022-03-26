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
    public class ProcessesController : BaseApiController
    {
        private readonly IRepository<Project> _repository;

        public ProcessesController(IRepository<Project> repository)
        {
            _repository = repository;
        }

        // GET: api/Process
        [HttpGet("{projectId:Guid}/{processId}")]
        public async Task<IActionResult> GetById(Guid projectId, Guid processId)
        {
            var projectSpec = new ProjectByIdWithItemsSpec(projectId);
            var project = await _repository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            var process = project.Processes.FirstOrDefault(process => process.Id == projectId);
            if (process == null) return NotFound("No such process.");

            return Ok(process);
        }

        // POST: api/Processes
        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] ProcessDTO request)
        {
            var projectSpec = new ProjectByIdSpec(request.ProjectId);
            var project = await _repository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            project.AddProcess(new Process() { ProjectId=request.ProjectId,  Title = request.Title, Name = request.Name});

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

        // PATCH: api/Projects/{projectId}/inactive/{processId}
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] ProcessDTO request)
        {
            var projectSpec = new ProjectByIdWithItemsSpec(request.ProjectId);
            var project = await _repository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            var process = project.Processes.FirstOrDefault(process => process.Id == request.Id);
            if (process == null) return NotFound("No such process.");

            try
            {
                // Set Data
                process.Title = request.Title;
                process.Key = request.Key;
                process.Name = request.Name;
                process.Update(process);

                await _repository.UpdateAsync(project);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, error = ex.Message });

            }
 
        }

        [HttpPost("updateprocessmodellayout")]
        public async Task<IActionResult> UpdateProceeLayout([FromBody] UpdateProcessModelLayoutDTO request)
        {
            var projectSpec = new ProjectByIdWithItemsSpec(request.ProjectId);
            var project = await _repository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            var process = project.Processes.FirstOrDefault(process => process.Id == request.ProcessId);
            if (process == null) return NotFound("No such process.");

            try
            {
                // Set Data
                var processesRepo = new DoxFrame.Hub.Core.Services.ProcessesRepository(_repository);
                process.Layout = processesRepo.ProcessModelLayoutToByteArray(request.Layout);
                process.Update(process);

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
        public async Task<IActionResult> Remove([FromBody] RemoveProcessDTO request)
        {
            var projectSpec = new ProjectByIdWithItemsSpec(request.ProjectId);
            var project = await _repository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            var rmProcess = project.Processes.FirstOrDefault(process => process.Id == request.ProcessId);
            if (rmProcess == null) return NotFound("No such process.");

            project.RemoveProcess(rmProcess);

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
