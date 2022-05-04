using Ardalis.Specification;

namespace DoxFrame.Hub.Core.ProjectAggregate.Specifications
{
    public class UnpublishedPagesSearchSpec : Specification<Page>
    {
        public UnpublishedPagesSearchSpec(string searchString)
        {
            Query
                .Where(item => !item.isPublished &&
                (item.Title.Contains(searchString) ||
                item.Description.Contains(searchString)));
        }
    }
}
