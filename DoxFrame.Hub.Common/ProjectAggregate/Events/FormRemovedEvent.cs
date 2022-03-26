using DoxFrame.Hub.SharedKernel;
namespace DoxFrame.Hub.Core.ProjectAggregate.Events
{
    public class FormRemovedEvent : BaseDomainEvent
    {
        public Project Project { get; set; }
        public Form Form { get; set; }
        public FormRemovedEvent(Project project,
            Form rmform)
        {
            Project = project;
            Form = rmform;
        }
    }
}