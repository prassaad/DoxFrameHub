using DoxFrame.Hub.SharedKernel;
namespace DoxFrame.Hub.Core.ProjectAggregate.Events
{
    public class ReportRemovedEvent : BaseDomainEvent
    {
        public Project Project { get; set; }
        public Report Report{ get; set; }
        public ReportRemovedEvent(Project project,
            Report rmreport)
        {
            Project = project;
            Report = rmreport;
        }
    }
}