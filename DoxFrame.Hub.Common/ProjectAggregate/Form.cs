using DoxFrame.Hub.Core.ProjectAggregate.Events;
using DoxFrame.Hub.SharedKernel;
using DoxFrame.Hub.SharedKernel.Interfaces;

namespace DoxFrame.Hub.Core.ProjectAggregate
{
    public class Form : Document, IAggregateRoot
    {
        public string OperationType { get; set; }
        public string Key { get; set; }
        public string ProcessArea { get; set; }
        public string ProcessName { get; set; }
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

        public void SubmittedToProcess()
        {
            isActive = false;
            Events.Add(new ProcessFormSubmittedEvent(this));
        }


    }
}
