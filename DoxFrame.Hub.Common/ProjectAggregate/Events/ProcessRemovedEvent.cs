using DoxFrame.Hub.SharedKernel;
namespace DoxFrame.Hub.Core.ProjectAggregate.Events
{
    public class ProcessRemovedEvent : BaseDomainEvent
    {
        public Project Project { get; set; }
        public Process Process { get; set; }
        public ProcessRemovedEvent(Project project,
            Process rmProcess)
        {
            Project = project;
            Process = rmProcess;
        }
    }
}