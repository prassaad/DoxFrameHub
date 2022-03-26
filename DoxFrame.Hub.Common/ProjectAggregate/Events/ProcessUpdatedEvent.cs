using DoxFrame.Hub.Core.ProjectAggregate;
using DoxFrame.Hub.SharedKernel;

namespace DoxFrame.Hub.Core.ProjectAggregate.Events
{
    public class ProcessUpdatedEvent : BaseDomainEvent
    {
        public Process UpdatedProcess { get; set; }

        public ProcessUpdatedEvent(Process updatedProcess)
        {
            UpdatedProcess = updatedProcess;
        }
    }
}