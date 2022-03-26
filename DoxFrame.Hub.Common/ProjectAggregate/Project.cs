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

        private List<Form> _forms = new List<Form>();
        private List<Process> _processes = new List<Process>();

        public IEnumerable<Form> Forms => _forms.AsReadOnly();
        public IEnumerable<Process> Processes => _processes.AsReadOnly();

        public ProjectStatus Status => _forms.All(i => i.isPublished) ? ProjectStatus.Complete : ProjectStatus.InProgress;

        public Project(string title, string summary)
        {
            Title = Guard.Against.NullOrEmpty(title, nameof(title));
            Summary = Guard.Against.NullOrEmpty(summary, nameof(summary));

        }
        // Form definitions
        public void AddForm(Form newForm)
        {
            Guard.Against.Null(newForm, nameof(newForm));
            _forms.Add(newForm);

            var newFormAddedEvent = new NewFormAddedEvent(this, newForm);
            Events.Add(newFormAddedEvent);
        }
        public void RemoveForm(Form rmForm)
        {
            _forms.Remove(rmForm);

            var formRemovedEvent = new FormRemovedEvent(this, rmForm);
            Events.Add(formRemovedEvent);
        }
        public void UpdateName(string newName)
        {
            Title = Guard.Against.NullOrEmpty(newName, nameof(newName));
        }
        // Process Definitions

        public void AddProcess(Process newProcess)
        {
            Guard.Against.Null(newProcess, nameof(newProcess));
            _processes.Add(newProcess);
            var newProcessAddedEvent = new NewProcessAddedEvent(this, newProcess);
            Events.Add(newProcessAddedEvent);
        }
        public void RemoveProcess(Process rmProcess)
        {
            _processes.Remove(rmProcess);
            var processRemovedEvent = new ProcessRemovedEvent(this, rmProcess);
            Events.Add(processRemovedEvent);
        }

    }
}
