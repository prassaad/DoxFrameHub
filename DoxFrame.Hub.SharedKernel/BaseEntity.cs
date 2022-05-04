using System;
using System.Collections.Generic;

namespace DoxFrame.Hub.SharedKernel
{
    // This can be modified to BaseEntity<TId> to support multiple key types (e.g. Guid)
    public abstract class BaseEntity
    {
        public Guid  Id { get; set; }
        public Guid CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public string CreatedTime { get; set; }
        public string ModifiedTime { get; set; }
        public Guid ModifiedBy { get; set; }
        public Guid ModifiedByName { get; set; }

        // For Data Isolation
        public Guid HubUserId { get; set; } // Account linked with User Id
        public Guid TenantId { get; set; } // Tenant
   
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}