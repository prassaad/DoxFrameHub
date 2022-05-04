using Ardalis.GuardClauses;
using DoxFrame.Hub.Core.ProjectAggregate.Events;
using DoxFrame.Hub.SharedKernel;
using DoxFrame.Hub.SharedKernel.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DoxFrame.Hub.Core.ProjectAggregate
{
    public class Project : BaseEntity, IAggregateRoot
    {
        public string Title { get; private set; }
        public string AppTitle { get; private set; } // App title 
        public string Summary  { get; private set; } // Project Summary
        public string StartDate { get; private set; } //Start Date
        public string EndDate { get; private set; } //Start Date
 
        private List<Component> _components = new List<Component>();
        private List<Form> _forms = new List<Form>();
        private List<Report> _reports = new List<Report>();
        private List<Page> _pages = new List<Page>();
        private List<Workflow> _workflows = new List<Workflow>();

        public IEnumerable<Component> Components => _components.AsReadOnly();
        public IEnumerable<Form> Forms => _forms.AsReadOnly();
        public IEnumerable<Report> Reports => _reports.AsReadOnly();
        public IEnumerable<Page> Pages => _pages.AsReadOnly();
        public IEnumerable<Workflow> Workflows => _workflows.AsReadOnly();

        public ProjectStatus Status => _forms.All(i => i.isPublished) ? ProjectStatus.Complete : ProjectStatus.InProgress;

        public Project(string title, string summary)
        {
            Title = Guard.Against.NullOrEmpty(title, nameof(title));
            Summary = Guard.Against.NullOrEmpty(summary, nameof(summary));

        }
 

        // Form definitions
        public void AddForm(Component newComponent)
        {
            Guard.Against.Null(newComponent, nameof(newComponent));
             _components.Add(newComponent);
            var newFormAddedEvent = new NewFormAddedEvent(this, newComponent);
            Events.Add(newFormAddedEvent);
        }
        public void RemoveForm(Form rmForm)
        {
            _forms.Remove(rmForm);

            var formRemovedEvent = new FormRemovedEvent(this, rmForm);
            Events.Add(formRemovedEvent);
        }
       


        // Report definitions
        public void AddReport(Component newComponent)
        {
            Guard.Against.Null(newComponent, nameof(newComponent));
            _components.Add(newComponent);
            var newReportAddedEvent = new NewReportAddedEvent(this, newComponent);
            Events.Add(newReportAddedEvent);
        }
        public void RemoveReport(Report rmReport)
        {
            _reports.Remove(rmReport);
            var  reportRemovedEvent = new ReportRemovedEvent(this, rmReport);
            Events.Add(reportRemovedEvent);
        }

        // Page definitions
        public void AddPage(Component newComponent)
        {
            Guard.Against.Null(newComponent, nameof(newComponent));
            _components.Add(newComponent);
            var newReportAddedEvent = new NewReportAddedEvent(this, newComponent);
            Events.Add(newReportAddedEvent);
        }
        public void RemovePage(Page rmPage)
        {
            _pages.Remove(rmPage);
            var pageRemovedEvent = new PageRemovedEvent(this, rmPage);
            Events.Add(pageRemovedEvent);
        }

 
        // Workflow Definitions
        public void AddWorkflow(Component newComponent)
        {
            Guard.Against.Null(newComponent, nameof(newComponent));
            _components.Add(newComponent);
            var newWorkflowAddedEvent = new NewWorkflowAddedEvent(this, newComponent);
            Events.Add(newWorkflowAddedEvent);
        }
        public void RemoveWorkflow(Workflow rmWorkflow)
        {
            _workflows.Remove(rmWorkflow);
            var workflowRemovedEvent = new WorkflowRemovedEvent(this, rmWorkflow);
            Events.Add(workflowRemovedEvent);
        }

    }
}
