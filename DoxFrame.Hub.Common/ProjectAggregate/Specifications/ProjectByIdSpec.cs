using Ardalis.Specification;
using DoxFrame.Hub.Core.ProjectAggregate;
using System;

namespace DoxFrame.Hub.Core.ProjectAggregate.Specifications
{
    public class ProjectByIdSpec : Specification<Project>, ISingleResultSpecification
    {
        public ProjectByIdSpec(Guid projectId)
        {
            Query
                .Where(project => project.Id == projectId);
                
        }
    }
}
