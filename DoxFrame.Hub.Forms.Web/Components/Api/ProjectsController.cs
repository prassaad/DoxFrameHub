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
    public class ProjectsController : BaseApiController
    {
        private readonly IRepository<Project> _repository;

        public ProjectsController(IRepository<Project> repository)
        {
            _repository = repository;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var projectDTOs = (await _repository.ListAsync())
                .Select(project => new ProjectDTO
                {
                    Id = project.Id,
                    ProjectName = project.Title
                })
                .ToList();

            return Ok(projectDTOs);
        }

        // GET: api/Projects
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var projectSpec = new ProjectByIdWithItemsSpec(id);
            var project = await _repository.GetBySpecAsync(projectSpec);

            var result = new ProjectDTO
            {
                Id = project.Id,
                ProjectName = project.Title,
                Forms = new List<FormDTO>
                (
                    project.Forms.Select(i => FormDTO.FromToForm(i)).ToList()
                )
            };

            return Ok(result);
        }

        // POST: api/Projects
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectDTO request)
        {
            var newProject = new Project(request.ProjectName,request.Summary);

            var createdProject = await _repository.AddAsync(newProject);

            var result = new ProjectDTO
            {
                Id = createdProject.Id,
                ProjectName = createdProject.Title
            };
            return Ok(result);
        }

 
       
    }
}
