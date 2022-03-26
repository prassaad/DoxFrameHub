using Ardalis.Specification;
using System;

namespace DoxFrame.Hub.Core.ProjectAggregate.Specifications
{
    public class ProcessById : Specification<Form>, ISingleResultSpecification
    {
        public ProcessById(Guid processId)
        {
            Query
                .Where(Process => Process.Id == processId);
                
        }
    }
}
