using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ardalis.Result;
using DoxFrame.Hub.Core.ProjectAggregate;
using DoxFrame.Hub.Core.ProjectAggregate.Specifications;
using DoxFrame.Hub.Core.Interfaces;
using DoxFrame.Hub.SharedKernel.Interfaces;
using System.Linq;
using System.Text;

namespace DoxFrame.Hub.Core.Services
{
    public class PagesRepository : IPagesRepository
    {
         
        private readonly IRepository<Project> _repository;

        public PagesRepository(IRepository<Project> repository)
        {
            _repository = repository;
        }
        public async Task<Result<List<Page>>> GetAllUnpublishedPagesAsync(Guid projectId, string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                var errors = new List<ValidationError>();
                errors.Add(new ValidationError()
                {
                    Identifier = nameof(searchString),
                    ErrorMessage = $"{nameof(searchString)} is required."
                });
                return Result<List<Page>>.Invalid(errors);
            }

            var projectSpec = new ProjectByIdWithItemsSpec(projectId);
            var project = await _repository.GetBySpecAsync(projectSpec);

            // TODO: Optionally use Ardalis.GuardClauses Guard.Against.NotFound and catch
            if (project == null) return Result<List<Page>>.NotFound();

            var incompleteSpec = new UnpublishedPagesSearchSpec(searchString);

            try
            {
                var items = incompleteSpec.Evaluate(project.Pages).ToList();

                return new Result<List<Page>>(items);
            }
            catch (Exception ex)
            {
                // TODO: Log details here
                return Result<List<Page>>.Error(new[] { ex.Message });
            }
        }
       
        public async Task<Page> GetPageByIdAsync(Guid projectId,Guid pageId)
        {
            var projSpec = new ProjectByIdWithItemsSpec(projectId);
            var project = await _repository.GetBySpecAsync(projSpec);

            var pageSpec = new PageById(pageId);

            var page = pageSpec.Evaluate(project.Pages).FirstOrDefault();

            if (pageSpec!=null)
            {
                return Result<Page>.NotFound();
            }

            return new Result<Page>(page);
        }

        public byte[] PageLayoutToByteArray(string pageLayout)
        {
            UTF8Encoding utf8 = new UTF8Encoding();
            byte[] layoutBytes = new byte[1024];
            layoutBytes = utf8.GetBytes(pageLayout);
            return layoutBytes;
        }
 

        public string PageLayoutToJson(byte[] pageLayout)
        {
            return System.Text.Encoding.Default.GetString(pageLayout);
        }
    }
}
