using DoxFrame.Hub.SharedKernel;
namespace DoxFrame.Hub.Core.ProjectAggregate.Events
{
    public class NewFormAddedEvent : BaseDomainEvent
    {
        public Project Project { get; set; }
        public Form Form { get; set; }
        public NewFormAddedEvent(Project project,
            Form newform)
        {
            Project = project;
            Form = newform;
        }
    }
}