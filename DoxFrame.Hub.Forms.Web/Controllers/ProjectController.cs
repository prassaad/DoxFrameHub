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

        // Edit App Route
        // GET project/{projectId}
        [HttpGet("{projectId:Guid}/edit")]
        public async Task<IActionResult> Edit(Guid ProjectId, string Apptitle)
        {
            ViewBag.ProjectId = ProjectId;
            ViewBag.AppTitle = Apptitle;
            var components = GetComponents(ProjectId).Components;
            ViewData["menu"] = components;
            if (components.Count > 0)
            {
                return RedirectToAction("EditForm", new { projectId = ProjectId, componentId = components.FirstOrDefault().Id});
            }

            return View();
        }

        // Edit From in App Route
        [HttpGet("EditForm/{projectId:Guid}/{componentId:Guid}")]
        public async Task<IActionResult> EditForm(Guid ProjectId, Guid ComponentId)
        {
            var ProjectViewModel = GetComponents(ProjectId);
            ViewData["menu"] = ProjectViewModel.Components;
            ViewBag.ProjectId = ProjectId;
            ViewBag.AppTitle = ProjectViewModel.Title;
            ViewBag.ComponenId = ComponentId;
            ViewBag.ComponentTitle = ProjectViewModel.Components.Where(c => c.Id == ComponentId).FirstOrDefault().Title;
            ViewBag.ComponentType = ProjectViewModel.Components.Where(c => c.Id == ComponentId).FirstOrDefault().ComponentType;
            return View();
        }
        // Edit Report in App Route
        [HttpGet("{projectId:Guid}/edit/report/{componentId:Guid}")]
        public async Task<IActionResult> ReportEditView(Guid ProjectId, Guid ComponentId)
        {
            var ProjectViewModel = GetComponents(ProjectId);
            ViewData["menu"] = ProjectViewModel.Components;
            ViewBag.ProjectId = ProjectId;
            ViewBag.AppTitle = ProjectViewModel.Title;
            ViewBag.ComponenId = ComponentId;
            return View();
        }


        // GET project/{projectId?}
        [HttpGet("{projectId:Guid}/workflows")]
        public async Task<IActionResult> WorkflowIndex(Guid projectId)
        {
            var spec = new ProjectByIdWithItemsSpec(projectId);
            var project = await _projectRepository.GetBySpecAsync(spec);

            var dto = new ProjectViewModel
            {
                Id = project.Id,
                Title = project.Title,
                Workflows = project.Workflows
                            .Select(workflow => WorflowViewModel.FromToWorkflow(workflow))
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
        [HttpGet("{ProjectId:Guid}/{ComponentId:Guid}/FormBuilder")]
        public async Task<IActionResult> FormBuilderAsync(Guid ProjectId, Guid ComponentId)
        {
            // Get Form by ProjetcId and Component Id
            var projectSpec = new ProjectByIdWithItemsSpec(ProjectId);
            var project = await _projectRepository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            var form = project.Forms.FirstOrDefault(x => x.ComponentId == ComponentId);
            if (form == null) return NotFound("No such form.");

            // Check Layout data exist
            if (form.Layout != null)
            {
                // get encode fromLayout design to Json
                var formsRepo = new DoxFrame.Hub.Core.Services.FormsRepository(_projectRepository);
                ViewBag.Layout = (string)formsRepo.FormLayoutToJson(form.Layout);

            }
            else
            {
                // if not exits
                ViewBag.Layout = "New";
            }

            //for Evnet and Notification test
            //form.SubmittedToProcess();
            //await _projectRepository.UpdateAsync(project);


            // This needs to optimize to a Single Object

            ViewBag.ProjectId = ProjectId;
            ViewBag.FormId = form.Id;
            ViewBag.ProjectTitle = project.Title;
            ViewBag.FormTitle = form.Title;


            return View();
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
        [HttpGet("{ProjectId:Guid}/{WorkflowId:Guid}/{ProjectTitle}/BPMModeler")]
        public async Task<IActionResult> BPMModelerAsync(Guid ProjectId, Guid WorkflowId, string ProjectTitle, string WorkflowTitle)
        {

            // Get Form by ProjetcId and Process Id
            var projectSpec = new ProjectByIdWithItemsSpec(ProjectId);
            var project = await _projectRepository.GetBySpecAsync(projectSpec);
            if (project == null) return NotFound("No such project");

            var workflow = project.Workflows.FirstOrDefault(x => x.Id == WorkflowId);
            if (workflow == null) return NotFound("No such Workflow.");

            // In case No Process Key means needs to set more form data before BPM
            //if (process.Key == null)
            //     return RedirectToAction("FormSettings", new { ProjectId = ProjectId, ProcessId = ProcessId });


            // This needs to optimize to a Single Object
 
            // Check Layout data exist
            if (workflow.Layout != null && workflow.Layout.Length >0)
            {
                // get encode workflow model Layout design to Xml
                var workflowRepo = new DoxFrame.Hub.Core.Services.WorkflowsRepository(_projectRepository);
                ViewBag.Layout = (string)workflowRepo.WorkflowModelLayoutToXml(workflow.Layout);

            }
            else
            {
                // if not exits
                ViewBag.Layout = "New";
            }

           
            // This needs to optimize to a Single Object

            ViewBag.ProjectId = ProjectId;
            ViewBag.workflowId = WorkflowId;
            ViewBag.ProjectTitle = ProjectTitle;
            ViewBag.workflowTitle = WorkflowTitle;


            return View();
        }


        // Common Function for Menu
       private ProjectViewModel GetComponents(Guid ProjectId)
        {
            var spec = new ProjectByIdWithItemsSpec(ProjectId);
            var project =  _projectRepository.GetBySpecAsync(spec);

            var dto = new ProjectViewModel
            {
                Id = project.Result.Id,
                Title = project.Result.Title,
                Components = project.Result.Components
                            .Select(component => ComponentsViewModel.FromToComponent(component))
                            .ToList()
            };
            return dto;

        }
     
    }
}
