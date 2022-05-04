using DoxFrame.Hub.SharedKernel;
namespace DoxFrame.Hub.Core.ProjectAggregate.Events
{
    public class WorkflowRemovedEvent : BaseDomainEvent
    {
        public Project Project { get; set; }
        public Workflow Workflow { get; set; }
        public WorkflowRemovedEvent(Project project,
            Workflow rmWorkflow)
        {
            Project = project;
            Workflow = rmWorkflow;
        }
    }
}