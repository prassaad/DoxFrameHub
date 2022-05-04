using Ardalis.Specification;
using System;

namespace DoxFrame.Hub.Core.ProjectAggregate.Specifications
{
    public class PageById : Specification<Page>, ISingleResultSpecification
    {
        public PageById(Guid pageId)
        {
            Query
                .Where(Page => Page.Id == pageId);
                
        }
    }
}
