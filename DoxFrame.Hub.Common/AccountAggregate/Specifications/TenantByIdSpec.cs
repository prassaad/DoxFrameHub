using Ardalis.Specification;
using System;

namespace DoxFrame.Hub.Core.AccountAggregate.Specifications
{
    public class TenantByIdSpec : Specification<Tenant>, ISingleResultSpecification
    {
        public TenantByIdSpec(Guid teantId)
        {
            Query
                .Where(tenat => tenat.Id == teantId)
                .Include(tenant => tenant.projects);
                
        }
    }
}
