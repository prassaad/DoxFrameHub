using DoxFrame.Hub.Core.ProjectAggregate;
using DoxFrame.Hub.SharedKernel;

namespace DoxFrame.Hub.Core.ProjectAggregate.Events
{
    public class FormUpdatedEvent : BaseDomainEvent
    {
        public Form UpdatedForm { get; set; }

        public FormUpdatedEvent(Form updatedForm)
        {
            UpdatedForm = updatedForm;
        }
    }
}