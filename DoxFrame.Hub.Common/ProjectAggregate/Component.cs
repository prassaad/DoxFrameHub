using DoxFrame.Hub.Core.ProjectAggregate;
using DoxFrame.Hub.SharedKernel.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DoxFrame.Hub.SharedKernel
{
    public class Component : BaseEntity, IAggregateRoot
    {
        public Guid ProjectId { get; set; }
        public Guid ParetnId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ComponentType { get; set; } // Report or Form etc.
        public string SubCategory { get; set; }
        public string Icon { get; set; }
        public string Path { get; set; }
        [StringLength(200)]
        public bool IsGroup { get; set; }
        public string GroupName { get; set; }
        public bool? EndUserEdit { get; set; }
        public bool IsPreDefined { get; set; }

        public Form Form { get; set; }
        public Workflow Workflow { get; set; }
    }
}
