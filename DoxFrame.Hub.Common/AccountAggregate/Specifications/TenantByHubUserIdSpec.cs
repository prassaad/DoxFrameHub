using Ardalis.Specification;
using System;

namespace DoxFrame.Hub.Core.AccountAggregate.Specifications
{
    public class TenantByHubUserIdSpec : Specification<Tenant>, ISingleResultSpecification
    {
        public TenantByHubUserIdSpec(Guid userId)
        {
            Query
                .Where(tenat => tenat.HubUserId == userId);
                
        }
    }
}
