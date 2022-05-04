using DoxFrame.Hub.SharedKernel;
namespace DoxFrame.Hub.Core.ProjectAggregate.Events
{
    public class NewPageAddedEvent : BaseDomainEvent
    {
        public Project Project { get; set; }
        public Page Page { get; set; }
        public Component Component { get; set; }
        public NewPageAddedEvent(Project project,
             Component newComponent)
        {
            Project = project;
            Component = newComponent;
        }
    }
}