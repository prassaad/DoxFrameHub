using DoxFrame.Hub.Core.ProjectAggregate;
using DoxFrame.Hub.Core.ProjectAggregate.Specifications;
using DoxFrame.Hub.SharedKernel.Interfaces;
using DoxFrame.Hub.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DoxFrameHub.Web.Controllers
{
    [Route("[controller]")]
    public class ProjectController : Controller
    {
        private readonly IRepository<Project> _projectRepository;

        public ProjectController(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        // GET project}
        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            var projectDTOs = (await _projectRepository.ListAsync())
              .Select(project => new ProjectListViewModel
              {
                  Id = project.Id,
                  Title = project.Title,
                  Summary = project.Summary
              })
              .ToList();

            return View(projectDTOs);
        }

        // GET project/{projectId?}
        [HttpGet("{projectId:Guid}/processes")]
        public async Task<IActionResult> ProcessIndex(Guid projectId)
        {
            var spec = new ProjectByIdWithItemsSpec(projectId);
            var project = await _projectRepository.GetBySpecAsync(spec);

            var dto = new ProjectViewModel
            {
                Id = project.Id,
                Title = project.Title,
                Processes = project.Processes
                            .Select(process => ProcessViewModel.FromToProcess(process))
                            .ToList()
            };
            return View(dto);
        }

        // GET project/{projectId?}
        [HttpGet("{projectId:Guid}/forms")]
        public async Task<IActionResult> FormIndex(Guid projectId)
        {
            var spec = new ProjectByIdWithItemsSpec(projectId);
            var project = await _projectRepository.GetBySpecAsync(spec);

            var dto = new ProjectViewModel
            {
                Id = project.Id,
                Title = project.Title,
                Forms = project.Forms
                            .Select(form => FormViewModel.FromToForm(form))
                            .ToList()
            };
            return View(dto);
        }
        [Authorize]
        [HttpGet("{ProjectId:Guid}/{FormId:Guid}/{ProjectTitle}/FormBuilder")]
        public async Task<IActionResult> FormBuilderAsync(Guid ProjectId, Guid FormId, string ProjectTitle, string FormTitle)
        {
            // Get Form by ProjetcId and Form Id
            var projectSpec = new ProjectByIdWithItemsSpec(ProjectId);
            var project = await _projectRepository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            var form = project.Forms.FirstOrDefault(x => x.Id == FormId);
            if (form == null) return NotFound("No such form.");

            // In case No Form Key means needs to set more form data before Design Form
            if (form.Key == null)
                return RedirectToAction("FormSettings", new { ProjectId = ProjectId, FormId = FormId } );

            ViewBag.FormKey = form.Key;
            // Check Layout data exist
            if (form.Layout != null) {
                // get encode fromLayout design to Json
                var formsRepo = new DoxFrame.Hub.Core.Services.FormsRepository(_projectRepository);
                ViewBag.Layout = (string)formsRepo.FormLayoutToJson(form.Layout);

            }
            else {
                // if not exits
                ViewBag.Layout = "New";
            }
           
            //for Evnet and Notification test
            //form.SubmittedToProcess();
            //await _projectRepository.UpdateAsync(project);


            // This needs to optimize to a Single Object

            ViewBag.ProjectId = ProjectId;
            ViewBag.FormId = FormId;
            ViewBag.ProjectTitle = ProjectTitle;
            ViewBag.FormTitle = FormTitle;
 

            return View();
        }
        [Authorize]
        [HttpGet("formsettings")]
        public async Task<IActionResult> FormSettings(Guid ProjectId, Guid FormId)
        {
             
            // Get Form by ProjetcId and Form Id
            var projectSpec = new ProjectByIdWithItemsSpec(ProjectId);
            var project = await _projectRepository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            var formEtity = project.Forms.FirstOrDefault(x => x.Id == FormId);
            if (formEtity == null) return NotFound("No such form.");

            var dto = new FormViewModel
            {
                Id = formEtity.Id,
                Title = formEtity.Title,
                Description = formEtity.Description,
                OperationType = formEtity.OperationType,
                ProjectId = formEtity.ProjectId,
                Key = formEtity.Key,
                RequestMethod = formEtity.RequestMethod,
                RequestUri = formEtity.RequestUri
                 
            };

            return View(dto);
        }


        [Authorize]
        [HttpGet("{ProjectId:Guid}/{ProcessId:Guid}/{ProjectTitle}/BPMModeler")]
        public async Task<IActionResult> BPMModelerAsync(Guid ProjectId, Guid ProcessId, string ProjectTitle, string ProcessTitle)
        {

            // Get Form by ProjetcId and Process Id
            var projectSpec = new ProjectByIdWithItemsSpec(ProjectId);
            var project = await _projectRepository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            var process = project.Processes.FirstOrDefault(x => x.Id == ProcessId);
            if (process == null) return NotFound("No such process.");

            // In case No Process Key means needs to set more form data before BPM
            //if (process.Key == null)
            //     return RedirectToAction("FormSettings", new { ProjectId = ProjectId, ProcessId = ProcessId });


            // This needs to optimize to a Single Object
 
            // Check Layout data exist
            if (process.Layout != null && process.Layout.Length >0)
            {
                // get encode process model Layout design to Xml
                var processesRepo = new DoxFrame.Hub.Core.Services.ProcessesRepository(_projectRepository);
                ViewBag.Layout = (string)processesRepo.ProcessModelLayoutToXml(process.Layout);

            }
            else
            {
                // if not exits
                ViewBag.Layout = "New";
            }

           
            // This needs to optimize to a Single Object

            ViewBag.ProjectId = ProjectId;
            ViewBag.ProcessId = ProcessId;
            ViewBag.ProjectTitle = ProjectTitle;
            ViewBag.ProcessTitle = ProcessTitle;


            return View();
        }


    }
}
