using DoxFrame.Hub.SharedKernel;
namespace DoxFrame.Hub.Core.ProjectAggregate.Events
{
    public class NewProcessAddedEvent : BaseDomainEvent
    {
        public Project Project { get; set; }
        public Process Process { get; set; }
        public NewProcessAddedEvent(Project project,
            Process newProcess)
        {
            Project = project;
            Process = newProcess;
        }
    }
}