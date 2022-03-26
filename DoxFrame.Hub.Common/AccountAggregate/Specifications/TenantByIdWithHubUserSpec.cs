using Ardalis.Specification;
using System;

namespace DoxFrame.Hub.Core.AccountAggregate.Specifications
{
    public class TenantByIdWithHubUserSpec : Specification<Tenant>, ISingleResultSpecification
    {
        public TenantByIdWithHubUserSpec(Guid hubUserId)
        {
            Query
                .Where(tenant => tenant.HubUserId == hubUserId)
                .Include(tenant => tenant.projects);
        }
    }
}
