﻿using Ardalis.Specification;
using System;

namespace DoxFrame.Hub.Core.ProjectAggregate.Specifications
{
    public class ProjectByIdWithItemsSpec : Specification<Project>, ISingleResultSpecification
    {
        public ProjectByIdWithItemsSpec(Guid projectId)
        {
            Query
                .Where(project => project.Id == projectId)
                .Include(project => project.Forms)
                .Include(project => project.Processes);
        }
    }
}
