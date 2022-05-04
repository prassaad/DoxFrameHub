using DoxFrame.Hub.SharedKernel;
namespace DoxFrame.Hub.Core.ProjectAggregate.Events
{
    public class NewWorkflowAddedEvent : BaseDomainEvent
    {
        public Project Project { get; set; }
        public Component Component{ get; set; }
        public NewWorkflowAddedEvent(Project project,
            Component newComponent)
        {
            Project = project;
            Component = newComponent;
        }
    }
}