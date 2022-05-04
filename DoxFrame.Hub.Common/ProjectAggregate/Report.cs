using DoxFrame.Hub.Core.ProjectAggregate.Events;
using DoxFrame.Hub.SharedKernel;
using DoxFrame.Hub.SharedKernel.Interfaces;
using System;

namespace DoxFrame.Hub.Core.ProjectAggregate
{
    public class Report : BaseEntity, IAggregateRoot
    {
        public Guid ProjectId { get; set; }
        public Guid ComponentId { get; set; }
        public string Title { get;  set; }
        public string Description { get;  set; }
        public byte[] Layout { get; set; }
        public string ReportGroupName { get; set; }
        public string ReportType { get; set; }
        public string Key { get; set; }
        public string RequestUri { get; set; }
        public bool isPublished { get; set; }
        public bool isActive { get; set; }
        public void Update(Report report)
        {
            Title = report.Title;
            Key = report.Key;
            ReportType = report.ReportType;
            ReportGroupName = report.ReportGroupName;
            Description = report.Description;
            isPublished = report.isPublished;
            isActive = report.isActive;
        }
        public void MarkInactive()
        {
            isActive = false;
        }

    }
}
