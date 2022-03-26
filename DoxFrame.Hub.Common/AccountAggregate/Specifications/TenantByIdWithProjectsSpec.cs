using Ardalis.Specification;
using System;

namespace DoxFrame.Hub.Core.AccountAggregate.Specifications
{
    public class TenantByIdWithProjectsSpec : Specification<Tenant>, ISingleResultSpecification
    {
        public TenantByIdWithProjectsSpec(Guid userId)
        {
            Query
                 .Where(tenat => tenat.HubUserId == userId)
                .Include(tenat => tenat.projects);
        }
    }
}
