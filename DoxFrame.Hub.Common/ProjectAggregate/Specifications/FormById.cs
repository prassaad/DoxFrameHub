using Ardalis.Specification;
using System;

namespace DoxFrame.Hub.Core.ProjectAggregate.Specifications
{
    public class FormById : Specification<Form>, ISingleResultSpecification
    {
        public FormById(Guid formId)
        {
            Query
                .Where(Form => Form.Id == formId);
                
        }
    }
}
