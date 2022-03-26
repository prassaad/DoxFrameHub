using DoxFrame.Hub.Core.ProjectAggregate;
using DoxFrame.Hub.SharedKernel;
namespace DoxFrame.Hub.Core.AccountAggregate.Events
{
    public class ProjectRemovedEvent : BaseDomainEvent
    {
        public Tenant Tenant{ get; set; }
        public Project Project { get; set; }
        public ProjectRemovedEvent(Tenant tenant,
            Project rmProject)
        {
            Tenant = tenant;
            Project = rmProject;
        }
    }
}