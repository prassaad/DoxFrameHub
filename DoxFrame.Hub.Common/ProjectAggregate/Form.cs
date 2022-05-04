using DoxFrame.Hub.Core.ProjectAggregate.Events;
using DoxFrame.Hub.SharedKernel;
using DoxFrame.Hub.SharedKernel.Interfaces;
using System;

namespace DoxFrame.Hub.Core.ProjectAggregate
{
    public class Form : BaseEntity, IAggregateRoot
    {
        public Guid ProjectId { get; set; }
        public Guid ComponentId { get; set; }
        public string Title { get;  set; }
        public string Description { get;  set; }
        public byte[] Layout { get; set; }
        public string OperationType { get; set; }
        public string Key { get; set; }
        public string Area { get; set; }
        public string WorkflowName { get; set; }
        public string Trigger { get; set; }
        public string RequestMethod { get; set; }
        public string RequestUri { get; set; }
        public bool isPublished { get; set; }
        public FormState WorkFlowStatus { get; set; }
        public bool isActive { get; set; }
        public void Update(Form form)
        {
            Title = form.Title;
            Key = form.Key;
            OperationType = form.OperationType;
            Description = form.Description;
            RequestMethod = form.RequestMethod;
            RequestUri = form.RequestUri;
            isPublished = form.isPublished;
            isActive = form.isActive;

            Events.Add(new FormUpdatedEvent(this));
        }
        public void MarkInactive()
        {
            isActive = false;
            Events.Add(new FormUpdatedEvent(this));
        }

        public void SubmittedToWorkflow()
        {
            isActive = false;
            Events.Add(new WorkflowFormSubmittedEvent(this));
        }


    }
}
