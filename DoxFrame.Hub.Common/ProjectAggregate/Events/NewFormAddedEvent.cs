using DoxFrame.Hub.SharedKernel;
namespace DoxFrame.Hub.Core.ProjectAggregate.Events
{
    public class NewFormAddedEvent : BaseDomainEvent
    {
        public Project Project { get; set; }
        public Form Form { get; set; }
        public Component Component { get; set; }
        public NewFormAddedEvent(Project project,
             Component newComponent)
        {
            Project = project;
            Component = newComponent;
        }
    }
}