using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace DoxFrame.Hub.SharedKernel
{
    public class Document : BaseEntity
    {
        public string Category { get; set; } // Report or Form etc.
        public string SubCategory { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        [StringLength(200)]
        public string Group { get; set; }
        public byte[] Layout { get; set; }
        public bool? EndUserEdit { get; set; }
        public bool IsPreDefined { get; set; }
        public string UserId { get; set; }
        public Guid TenantId { get; set; }
        public Guid ProjectId { get; set; }
    }
}
