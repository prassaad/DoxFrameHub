using Ardalis.Specification;

namespace DoxFrame.Hub.Core.ProjectAggregate.Specifications
{
    public class UnpublishedFormsSearchSpec : Specification<Form>
    {
        public UnpublishedFormsSearchSpec(string searchString)
        {
            Query
                .Where(item => !item.isPublished &&
                (item.Title.Contains(searchString) ||
                item.Description.Contains(searchString)));
        }
    }
}
