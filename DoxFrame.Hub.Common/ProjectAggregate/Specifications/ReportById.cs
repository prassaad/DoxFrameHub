using Ardalis.Specification;
using System;

namespace DoxFrame.Hub.Core.ProjectAggregate.Specifications
{
    public class ReportById : Specification<Report>, ISingleResultSpecification
    {
        public ReportById(Guid reportId)
        {
            Query
                .Where(Report => Report.Id ==  reportId);
                
        }
    }
}
