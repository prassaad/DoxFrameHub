using DoxFrame.Hub.Core.ProjectAggregate;
using DoxFrame.Hub.SharedKernel;

namespace DoxFrame.Hub.Core.ProjectAggregate.Events
{
    public class WorkflowFormSubmittedEvent : BaseDomainEvent
    {
        public Form SubmittedForm { get; set; }

        public WorkflowFormSubmittedEvent(Form submittedForm)
        {
            SubmittedForm = submittedForm;
        }
    }
}