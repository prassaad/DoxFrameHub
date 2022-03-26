using Ardalis.Specification;

namespace DoxFrame.Hub.Core.ProjectAggregate.Specifications
{
    public class UnpublishedFormsSpec : Specification<Form>
    {
        public UnpublishedFormsSpec()
        {
            Query.Where(item => !item.isPublished);
        }
    }
}
