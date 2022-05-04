using DoxFrame.Hub.SharedKernel;
namespace DoxFrame.Hub.Core.ProjectAggregate.Events
{
    public class NewReportAddedEvent : BaseDomainEvent
    {
        public Project Project { get; set; }
        public Report Report { get; set; }
        public Component Component { get; set; }
        public NewReportAddedEvent(Project project,
             Component newComponent)
        {
            Project = project;
            Component = newComponent;
        }
    }
}