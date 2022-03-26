using DoxFrame.Hub.Core.ProjectAggregate;
using DoxFrame.Hub.SharedKernel;

namespace DoxFrame.Hub.Core.ProjectAggregate.Events
{
    public class ProcessFormSubmittedEvent : BaseDomainEvent
    {
        public Form SubmittedForm { get; set; }

        public ProcessFormSubmittedEvent(Form submittedForm)
        {
            SubmittedForm = submittedForm;
        }
    }
}