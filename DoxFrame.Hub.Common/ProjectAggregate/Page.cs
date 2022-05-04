using DoxFrame.Hub.Core.ProjectAggregate.Events;
using DoxFrame.Hub.SharedKernel;
using DoxFrame.Hub.SharedKernel.Interfaces;
using System;

namespace DoxFrame.Hub.Core.ProjectAggregate
{
    public class Page : BaseEntity, IAggregateRoot
    {
        public Guid ProjectId { get; set; }
        public Guid ComponentId { get; set; }
        public string Title { get;  set; }
        public string Description { get;  set; }
        public byte[] Layout { get; set; }
        public string PageGroupName { get; set; }
        public string Key { get; set; }
        public bool isPublished { get; set; }
        public bool isActive { get; set; }
        public void Update(Report page)
        {
            Title = page.Title;
            Key = page.Key;
            PageGroupName = page.ReportGroupName;
            Description = page.Description;
            isPublished = page.isPublished;
            isActive = page.isActive;
        }
        public void MarkInactive()
        {
            isActive = false;
        }

    }
}
