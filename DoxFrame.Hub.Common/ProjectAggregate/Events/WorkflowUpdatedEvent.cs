using DoxFrame.Hub.Core.ProjectAggregate;
using DoxFrame.Hub.SharedKernel;

namespace DoxFrame.Hub.Core.ProjectAggregate.Events
{
    public class WorkflowUpdatedEvent : BaseDomainEvent
    {
        public Workflow UpdatedProcess { get; set; }

        public WorkflowUpdatedEvent(Workflow updatedProcess)
        {
            UpdatedProcess = updatedProcess;
        }
    }
}