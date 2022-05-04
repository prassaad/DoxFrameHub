using DoxFrame.Hub.SharedKernel;
namespace DoxFrame.Hub.Core.ProjectAggregate.Events
{
    public class PageRemovedEvent : BaseDomainEvent
    {
        public Project Project { get; set; }
        public Page Page { get; set; }
        public PageRemovedEvent(Project project,
            Page rmpage)
        {
            Project = project;
            Page = rmpage;
        }
    }
}