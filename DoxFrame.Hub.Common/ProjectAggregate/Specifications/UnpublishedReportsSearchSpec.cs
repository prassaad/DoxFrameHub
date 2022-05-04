using Ardalis.Specification;

namespace DoxFrame.Hub.Core.ProjectAggregate.Specifications
{
    public class UnpublishedReportsSearchSpec : Specification<Report>
    {
        public UnpublishedReportsSearchSpec(string searchString)
        {
            Query
                .Where(item => !item.isPublished &&
                (item.Title.Contains(searchString) ||
                item.Description.Contains(searchString)));
        }
    }
}
