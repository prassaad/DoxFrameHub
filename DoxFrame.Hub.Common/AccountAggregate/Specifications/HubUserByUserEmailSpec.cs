using Ardalis.Specification;
using DoxFrame.Hub.Core.AccountAggregate;
using System;

namespace DoxFrame.Hub.Core.AccountAggregate.Specifications
{
    public class HubUserByUserEmailSpec : Specification<HubUser>, ISingleResultSpecification
    {
        public HubUserByUserEmailSpec(string emailid)
        {
            Query
                .Where(user => user.Email == emailid);
                
        }
    }
}
